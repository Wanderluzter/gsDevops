FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

RUN groupadd -r appgroup && useradd -r -g appgroup appuser \
    && mkdir -p /app && chown -R appuser:appgroup /app

USER appuser

COPY --from=build /app/out ./

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "gsDotnet.dll"]
