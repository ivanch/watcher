FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Watcher.csproj", "."]
RUN dotnet restore "./Watcher.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Watcher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watcher.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watcher.dll"]