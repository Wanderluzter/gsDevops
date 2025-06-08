# Usar SDK do .NET 9 para build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar csproj e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar todo o conteúdo e buildar
COPY . ./
RUN dotnet publish -c Release -o out

# Usar imagem runtime do .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Criar grupo e usuário não root e dar permissão para /app
RUN addgroup -S appgroup && adduser -S appuser -G appgroup \
    && chown -R appuser:appgroup /app

USER appuser

# Copiar artefatos do build
COPY --from=build /app/out ./

# Configurar porta e variáveis de ambiente
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Executar o app
ENTRYPOINT ["dotnet", "gsDotnet.dll"]
