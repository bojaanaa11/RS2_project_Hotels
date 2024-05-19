#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Rating/Rating.API/Rating.API.csproj", "Services/Rating/Rating.API/"]
COPY ["Services/Rating/Rating.Application/Rating.Application.csproj", "Services/Rating/Rating.Application/"]
COPY ["Services/Rating/Rating.Domain/Rating.Domain.csproj", "Services/Rating/Rating.Domain/"]
COPY ["Services/Rating/Rating.Infrastructure/Rating.Infrastructure.csproj", "Services/Rating/Rating.Infrastructure/"]
RUN dotnet restore "./Services/Rating/Rating.API/./Rating.API.csproj"
COPY . .
WORKDIR "/src/Services/Rating/Rating.API"
RUN dotnet build "./Rating.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rating.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rating.API.dll"]