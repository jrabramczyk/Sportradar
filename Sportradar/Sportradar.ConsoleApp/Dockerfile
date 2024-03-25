FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sportradar.ConsoleApp/Sportradar.ConsoleApp.csproj", "Sportradar.ConsoleApp/"]
RUN dotnet restore "Sportradar.ConsoleApp/Sportradar.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Sportradar.ConsoleApp"
RUN dotnet build "Sportradar.ConsoleApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sportradar.ConsoleApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sportradar.ConsoleApp.dll"]
