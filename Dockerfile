# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy and restore as distinct layers
COPY ["EmployeeManagement/EmployeeManagement.csproj", "EmployeeManagement/"]
RUN dotnet restore "./EmployeeManagement/./EmployeeManagement.csproj"

# Copy the remaining files
COPY . .

WORKDIR "/src/EmployeeManagement"
RUN dotnet build "./EmployeeManagement.csproj" -c Release -o /app/build

# Publish Stage
FROM build AS publish
RUN dotnet publish "./EmployeeManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Node.js Installation Stage
FROM node:14 AS node-install
WORKDIR /app
COPY ["./package.json", "./package-lock.json", "/app/"]
RUN npm install

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Copy the published .NET Core application
COPY --from=publish /app/publish .

# Copy the node_modules from the node-install stage
COPY --from=node-install /app/node_modules /app/node_modules

ENTRYPOINT ["dotnet", "EmployeeManagement.dll"]
