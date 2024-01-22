#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/ManagingRooms/RoomManaging.API/RoomManaging.API.csproj", "Services/ManagingRooms/RoomManaging.API/"]
RUN dotnet restore "./Services/ManagingRooms/RoomManaging.API/./RoomManaging.API.csproj"
COPY . .
WORKDIR "/src/Services/ManagingRooms/RoomManaging.API"
RUN dotnet build "./RoomManaging.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoomManaging.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomManaging.API.dll"]