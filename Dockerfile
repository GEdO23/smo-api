FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Setting the environment variables
USER $APP_UID

# Setting the working directory
WORKDIR /app

# Exposing the ports
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Setting the build configuration
ARG BUILD_CONFIGURATION=Release

# Setting the working directory
WORKDIR /src

# Copying csproj files
COPY ["smo-api/smo-api.csproj", "smo-api/"]
COPY ["domain/domain.csproj", "domain/"]
COPY ["data/data.csproj", "data/"]
COPY ["settings/settings.csproj", "settings/"]
COPY ["tests/tests.csproj", "tests/"]

# Restoring dependencies
RUN dotnet restore "smo-api/smo-api.csproj

# Copying the rest of the files
COPY . .

# Accessing the smo-api directory
WORKDIR "/src/smo-api"

# Building the project
RUN dotnet build "smo-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

# Setting the build configuration
ARG BUILD_CONFIGURATION=Release

# Publishing the project
RUN dotnet publish "smo-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

# Setting the working directory
WORKDIR /app

# Copying the published files
COPY --from=publish /app/publish .

# Running the application
ENTRYPOINT ["dotnet", "smo-api.dll"]