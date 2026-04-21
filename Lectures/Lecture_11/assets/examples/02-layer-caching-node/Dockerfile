FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Dependency restore layer changes rarely compared to source code.
COPY Demo2LayerCaching.csproj ./
RUN dotnet restore

# App source changes often.
COPY Program.cs ./
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

EXPOSE 8080
ENTRYPOINT ["dotnet", "Demo2LayerCaching.dll"]
