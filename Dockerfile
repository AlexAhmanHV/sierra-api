# Byggsteg
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Kopiera projektfiler
COPY *.sln ./
COPY WebApplication1/*.csproj ./WebApplication1/
RUN dotnet restore

# Kopiera resten och bygg
COPY . ./
WORKDIR /app/WebApplication1
RUN dotnet publish -c Release -o out

# Körsteg
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/WebApplication1/out ./
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
