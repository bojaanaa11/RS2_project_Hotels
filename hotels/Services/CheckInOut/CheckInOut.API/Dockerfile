#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/CheckInOut/CheckInOut.API/CheckInOut.API.csproj", "Services/CheckInOut/CheckInOut.API/"]
RUN dotnet restore "./Services/CheckInOut/CheckInOut.API/./CheckInOut.API.csproj"
COPY . .
WORKDIR "/src/Services/CheckInOut/CheckInOut.API"
RUN dotnet build "./CheckInOut.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CheckInOut.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckInOut.API.dll"]