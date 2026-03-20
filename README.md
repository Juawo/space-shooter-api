# 🧠 OuterSpace - Backend API
![C#](https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-Web%20API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-ORM-68217A?style=for-the-badge)
![Rider](https://img.shields.io/badge/Rider-IDE-000000?style=for-the-badge&logo=jetbrains&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-336791?style=for-the-badge&logo=postgresql&logoColor=white)
![REST](https://img.shields.io/badge/REST-API-black?style=for-the-badge)
![ngrok](https://img.shields.io/badge/ngrok-Tunneling-1F1E37?style=for-the-badge&logo=ngrok&logoColor=white)

A RESTful ASP.NET Web API responsible for managing players and scores for the OuterSpace mobile game.

This API enables player registration, score tracking, and leaderboard functionality, supporting a competitive gameplay experience.

---

## 📚 Table of Contents

- [Features](#features)
- [Architecture Overview](#architecture-overview)
- [ Architecture Diagram](#architecture-diagram)
- [Technical Decisions](#technical-decisions)
- [Tech Stack](#tech-stack)
- [How to Run](#how-to-run)
- [Project Status](#project-status)
- [Differentials](#differentials)
- [Future Improvements](#future-improvements)
- [Related Projects](#related-projects)

---

## Features

- Player registration and management
- Score submission and tracking
- Leaderboard data support
- Data validation using DTOs
- Layered architecture (Controller → Service → Repository)

---

## Architecture Overview

The API follows a layered architecture pattern:

```text
Controller → Service → Repository → Database
```
Controllers handle HTTP requests

Services implement business logic

Repositories manage database access

DTOs ensure safe and structured data transfer

## Architecture Diagram
```
Game Client → API → Service → Repository → Database
```
## Technical Decisions

**Layered Architecture (Separation of Concerns)**
Clear separation between API layers improves maintainability and scalability.

**DTO-Based Validation**
DTOs are used to validate and control incoming/outgoing data, reducing coupling between layers.

**Global Error Handling Middleware**
A centralized middleware handles exceptions and ensures consistent API responses.

**Route Access Based on Resource Ownership**
Access to certain endpoints is controlled using player ID and score ID, ensuring correct data access patterns.

**Database Integration via Entity Framework**
EF Core is used for ORM, simplifying data access and migrations.

## Tech Stack
![C#](https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-Web%20API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-ORM-68217A?style=for-the-badge)
![Rider](https://img.shields.io/badge/Rider-IDE-000000?style=for-the-badge&logo=jetbrains&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-336791?style=for-the-badge&logo=postgresql&logoColor=white)
![REST](https://img.shields.io/badge/REST-API-black?style=for-the-badge)
![ngrok](https://img.shields.io/badge/ngrok-Tunneling-1F1E37?style=for-the-badge&logo=ngrok&logoColor=white)

## How to Run
```
Clone the repository:

git clone <REPO_URL>

Navigate to the project folder:

cd OuterSpace.API

Configure the database connection string in appsettings.json

Apply migrations:

dotnet ef database update

Run the application:

dotnet run
```
## Project Status

In development — core features (player and score management) are implemented, with authentication and security improvements planned.
> This API is currently in the prototype stage and is not deployed to a production environment yet.  
> For integration and testing with the mobile game client, the API is exposed using **ngrok**, allowing temporary public access to the local server.

## Differentials

- Backend designed specifically for game integration (mobile client)

- Leaderboard-driven architecture for competitive gameplay

- Clean and scalable layered structure

- Real-world API patterns (DTOs, middleware, EF Core)

## Future Improvements

- Authentication and authorization (JWT)

- Score validation and anti-cheat mechanisms

- Global and weekly leaderboards

- Request validation and rate limiting

- Logging and monitoring

- API documentation (Swagger)

- Deployment pipeline (CI/CD)

## Related Projects

🎮 Game Client (Godot): https://github.com/Juawo/space-shooter