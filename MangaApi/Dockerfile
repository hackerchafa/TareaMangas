# Usa la imagen oficial de .NET 9 SDK (preview o nightly)
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build

WORKDIR /app

# Copia los archivos del proyecto
COPY . ./

# Restaura paquetes
RUN dotnet restore

# Publica el proyecto en modo release
RUN dotnet publish -c Release -o out

# Imagen final con runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime

WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "MangaApi.dll"]
