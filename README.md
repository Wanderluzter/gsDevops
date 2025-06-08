# 🌩️ Weatherman - Containerização e Orquestração da API com Banco em Docker

## 📲 Resumo da Ideia

Weatherman é um aplicativo mobile inteligente que utiliza geolocalização para mapear regiões afetadas por eventos climáticos extremos, prever condições futuras, indicar locais seguros, permitir comunicação e colaboração entre usuários, e utilizar Inteligência Artificial para prever riscos e oferecer suporte contextual.

Este repositório contém a conteinerização da API desenvolvida em **.NET 9**, além do banco de dados **PostgreSQL**, usando **Docker** e **Docker Compose** para criar um ambiente integrado, robusto e fácil de executar.

---

## 🛠️ Tecnologias e Ferramentas Usadas

- **.NET 9 SDK & ASP.NET Core Runtime** — Construção e execução da API REST.
- **PostgreSQL (container oficial)** — Banco de dados relacional persistente.
- **Docker** — Para criação das imagens personalizadas e ambiente isolado.
- **Docker Compose** — Orquestração dos containers para API e banco.
- **Variáveis de Ambiente e Boas Práticas** — Usuário não root, diretório de trabalho, persistência via volumes nomeados.

---

## 📦 Estrutura do Projeto

- **Dockerfile** — Imagem personalizada da API, configurada para rodar com usuário não root e expor porta 80.
- **docker-compose.yml** — Define dois serviços:
  - `api` — Build da aplicação .NET, exposta na porta 8080, configurada para conexão com o banco via variável de ambiente.
  - `postgres-db` — Banco PostgreSQL com volume nomeado para persistência, variáveis para usuário, senha e banco definidos.

---

## 🚀 Como Executar

1. **Clone este repositório:**
   ````bash
   git clone https://github.com/seu-usuario/seu-projeto.git
   cd seu-projeto
   ````

2. **Configure variáveis sensíveis (opcional) no arquivo `.env`:**

   ```env
   POSTGRES_USER=postgres
   POSTGRES_PASSWORD=senha123
   POSTGRES_DB=meubanco
   ```

3. **Execute os containers em modo background:**

   ```bash
   docker-compose up -d
   ```

4. **Confira os logs dos containers (opcional):**

   ```bash
   docker-compose logs -f
   ```

5. **Acesse a API no navegador ou via cliente REST:**

   ```
   http://localhost:8080/swagger
   ```

---

## 📋 Requisitos do Projeto

- Docker instalado e rodando (versão recomendada 20+)
- Docker Compose instalado
- .NET 9 SDK (para desenvolvimento local, se necessário)
- Cliente REST (Insomnia, Postman, etc.)

---

## 📚 Observações Técnicas

- A API roda com usuário não root para seguir boas práticas de segurança.
- O banco PostgreSQL está configurado com volume nomeado para garantir persistência dos dados.
- A porta 8080 está mapeada para a porta 80 interna do container da API.
- Variáveis de ambiente são usadas para configurar conexões e modo da aplicação.
- Toda comunicação entre containers ocorre na rede docker personalizada rede-local.

---

## 🎯 Objetivos Cumpridos

- Container da aplicação .NET 9 construído via Dockerfile com boas práticas
- Container do banco de dados PostgreSQL configurado com volume persistente e variáveis de ambiente
- Orquestração via Docker Compose para facilitar execução conjunta
- Aplicação rodando com CRUD completo e conexão com banco persistente
- Uso de usuário não root e variáveis de ambiente para segurança e configuração

---

## 👥 Equipe

- Leonardo José - RM556110
- Raul Clauson - RM555006
- Mirian Bronzati - RM555041
