# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorCV.csproj", "./"]
RUN dotnet restore "BlazorCV.csproj"
COPY . ./
RUN dotnet publish "BlazorCV.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Viktigt: S�tter s� att appen lyssnar p� port 80 i containern
ENV ASPNETCORE_URLS=http://+:8081

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "BlazorCV.dll"]