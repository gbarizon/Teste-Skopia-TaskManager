FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY src/TaskManager.Api/TaskManager.Api.csproj TaskManager.Api/
COPY src/TaskManager.Application/TaskManager.Application.csproj TaskManager.Application/
COPY src/TaskManager.Domain/TaskManager.Domain.csproj TaskManager.Domain/
COPY src/TaskManager.Infrastructure/TaskManager.Infrastructure.csproj TaskManager.Infrastructure/

WORKDIR /src/TaskManager.Api
RUN dotnet restore

COPY . .



RUN dotnet publish src/TaskManager.Api/TaskManager.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TaskManager.Api.dll"]
