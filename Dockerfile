# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar arquivos e restaurar dependências
COPY *.sln .
COPY *.csproj .
RUN dotnet restore

# Copiar tudo e publicar
COPY . .
RUN dotnet publish -c Release -o out

# Estágio de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# O Render define a porta via variável de ambiente PORT
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "SpaceShooterApi.dll"]