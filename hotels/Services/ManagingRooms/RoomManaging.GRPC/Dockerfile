#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/ManagingRooms/RoomManaging.GRPC/RoomManaging.GRPC.csproj", "Services/ManagingRooms/RoomManaging.GRPC/"]
COPY ["Services/ManagingRooms/RoomManaging.Common/RoomManaging.Common.csproj", "Services/ManagingRooms/RoomManaging.Common/"]
RUN dotnet restore "./Services/ManagingRooms/RoomManaging.GRPC/RoomManaging.GRPC.csproj"
COPY . .
WORKDIR "/src/Services/ManagingRooms/RoomManaging.GRPC"
RUN dotnet build "./RoomManaging.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoomManaging.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomManaging.GRPC.dll"]