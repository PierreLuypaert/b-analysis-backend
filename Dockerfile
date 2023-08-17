# Utilisez l'image de base dotnet SDK pour construire l'application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiez les fichiers du projet et restaurez les dépendances
COPY ["B-Analysis-BackEnd.csproj", "./"]
RUN dotnet restore "B-Analysis-BackEnd.csproj"

# Copiez le reste du code source et construisez l'application
COPY . .
WORKDIR "/src/."
RUN dotnet build "B-Analysis-BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "B-Analysis-BackEnd.csproj" -c Release -o /app/publish

# Utilisez l'image d'exécution dotnet pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copiez les fichiers de la publication dans le conteneur
COPY --from=publish /app/publish .

# Démarrez l'application
ENTRYPOINT ["dotnet", "B_Analysis_BackEnd.dll"]
