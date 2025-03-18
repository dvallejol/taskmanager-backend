# Etapa 1: Construcci�n de la aplicaci�n
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar los archivos de la soluci�n y del proyecto
COPY *.sln ./
COPY API/API.csproj API/
COPY Data/Data.csproj Data/
COPY Models/Models.csproj Models/

# Restaurar dependencias
RUN dotnet restore

# Copiar el resto del c�digo fuente y compilar
COPY . .
RUN dotnet publish API/API.csproj -c Release -o /publish

# Etapa 2: Ejecuci�n de la aplicaci�n
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

# Exponer el puerto en el que corre la API
EXPOSE 5000


# Comando para ejecutar la API
CMD ["dotnet", "API.dll"]