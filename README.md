# Space Shooter API

API RESTful desenvolvida em .NET 9 para gerenciamento de jogadores e pontuações de um jogo Space Shooter.

## 🎯 Objetivo

Fornecer endpoints para cadastro, consulta e atualização de jogadores, além de gerenciar suas pontuações no jogo, permitindo integração com aplicações front-end e sistemas de leaderboard.

## 🛠️ Tecnologias

- **.NET 9**
- **Entity Framework Core**
- **PostgreSQL**
- **ASP.NET Core Web API**

## 📋 Funcionalidades

- Gerenciamento completo de jogadores (CRUD)
- Registro e consulta de pontuações
- Validação de dados com DTOs
- Arquitetura em camadas (Controllers, Services, Repositories)

## 🚀 Como Executar

1. Configure a connection string no `appsettings.json`
2. Execute as migrations: `dotnet ef database update`
3. Inicie a aplicação: `dotnet run`

## 📦 Estrutura

```
├── Controllers/      # Endpoints da API
├── Services/         # Lógica de negócio
├── Repositories/     # Acesso a dados
├── Models/           # Entidades do domínio
├── DTOs/             # Objetos de transferência
├── Mappers/          # Conversão entre Models e DTOs
└── Database/         # Contexto EF Core
```

---

**Desenvolvido para o módulo WEB2 - ADS**
