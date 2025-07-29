# Byggsteg
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Kopiera sln och csproj
COPY WebApplication1.sln ./
COPY WebApplication1.csproj ./
RUN dotnet restore

# Kopiera allt och bygg
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Körsteg
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
