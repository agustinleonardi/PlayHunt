# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar sln y csproj para restaurar
COPY F2KProject.sln ./
COPY backend/API/API.csproj backend/API/
COPY backend/Application/Application.csproj backend/Application/
COPY backend/Domain/Domain.csproj backend/Domain/
COPY backend/Infrastructure/Infrastructure.csproj backend/Infrastructure/

RUN dotnet restore backend/API/API.csproj

# Copiar el resto del código y publicar
COPY backend/ ./backend/
WORKDIR /src/backend/API
RUN dotnet publish -c Release -o /app/publish

# Etapa runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Railway expone la app en $PORT; bindear a 0.0.0.0
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
# Puerto por defecto local (fallback)
ENV PORT=8080

COPY --from=build /app/publish ./
# Opcional: expone un puerto para documentación local
EXPOSE 8080

ENTRYPOINT ["dotnet", "API.dll"]