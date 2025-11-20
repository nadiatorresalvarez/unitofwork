# Usamos la imagen oficial de .NET 9 (la misma de tu PC)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos todo el código al contenedor
COPY . .

# Restauramos y publicamos usando la ruta que ya arreglamos antes
# Ajuste clave: Apuntamos a la carpeta y archivo correctos
RUN dotnet restore Lab4-NadiaTorres/Lab4-NadiaTorres.csproj
RUN dotnet publish Lab4-NadiaTorres/Lab4-NadiaTorres.csproj -c Release -o /app/out

# Imagen final para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Configuración de puertos para Render
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Arrancar la app
ENTRYPOINT ["dotnet", "Lab4-NadiaTorres.dll"]
