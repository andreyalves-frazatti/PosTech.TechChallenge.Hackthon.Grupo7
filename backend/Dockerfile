FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TechChallenge.Hackthon.API", "src/TechChallenge.Hackthon.API/"]
RUN dotnet restore "./src/TechChallenge.Hackthon.API/TechChallenge.Hackthon.API.csproj"
COPY . .
WORKDIR "/src/src/TechChallenge.Hackthon.API"
RUN dotnet build "./TechChallenge.Hackthon.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechChallenge.Hackthon.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallenge.Hackthon.API.dll"]