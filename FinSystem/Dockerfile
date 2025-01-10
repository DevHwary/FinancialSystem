# Use Microsoft's official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinSystem.WebApi/FinSystem.WebApi.csproj", "FinSystem.WebApi/"]
COPY ["FinSystem.Application/FinSystem.Application.csproj", "FinSystem.Application/"]
COPY ["FinSystem.Domain/FinSystem.Domain.csproj", "FinSystem.Domain/"]
COPY ["FinSystem.Infrastructure/FinSystem.Infrastructure.csproj", "FinSystem.Infrastructure/"]

RUN dotnet restore "FinSystem.WebApi/FinSystem.WebApi.csproj"

# Copy the rest of your source files
COPY . .
WORKDIR "/src/FinSystem.WebApi"
RUN dotnet build "FinSystem.WebApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "FinSystem.WebApi.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinSystem.WebApi.dll"]
