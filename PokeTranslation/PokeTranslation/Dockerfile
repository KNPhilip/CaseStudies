# Start from MS .NET 8 SDK base image.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 8080

# Copy solution and csproj and restore as distinct layers
# We do this first to take advantage of Docker's caching.
COPY PokeTranslation.sln PokeTranslation.sln
COPY PokeTranslation/PokeTranslation.csproj PokeTranslation/PokeTranslation.csproj
COPY Tests/PokeTranslation.UnitTests/PokeTranslation.UnitTests.csproj Tests/PokeTranslation.UnitTests/PokeTranslation.UnitTests.csproj

# Restore package dependencies.
RUN dotnet restore PokeTranslation.sln

# Copy everything else and build.
COPY . .
WORKDIR /app
RUN dotnet publish -c Release -o out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PokeTranslation.dll"]