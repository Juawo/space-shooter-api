# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1. Copia apenas o .csproj para aproveitar o cache de camadas
COPY ["SpaceShooterApi.csproj", "./"]
RUN dotnet restore "./SpaceShooterApi.csproj"

# 2. Copia o restante dos arquivos
COPY . .

# 3. Publica em um caminho absoluto (/app/publish)
RUN dotnet publish "SpaceShooterApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# 4. Copia os arquivos publicados do estágio de build
COPY --from=build /app/publish .

# O Render precisa que a aplicação escute em uma porta específica
ENV ASPNETCORE_URLS=http://+:10000

# Certifique-se de que o nome da DLL é exatamente este
ENTRYPOINT ["dotnet", "SpaceShooterApi.dll"]