# Estágio de Build - Mude de 9.0 para 10.0
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# ... (restante igual)

# Estágio de Runtime - Mude de 9.0 para 10.0
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

# O Render define a porta via variável de ambiente PORT
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "SpaceShooterApi.dll"]