# -----------------------------
# Runtime image
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# -----------------------------
# Build image
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files first (for Docker cache)
COPY ["ContactManagement.Presentation/ContactManagement.Presentation.csproj", "ContactManagement.Presentation/"]
COPY ["ContactManagement.Application/ContactManagement.Application.csproj", "ContactManagement.Application/"]
COPY ["ContactManagement.Domain/ContactManagement.Domain.csproj", "ContactManagement.Domain/"]
COPY ["ContactManagement.Infrastructure/ContactManagement.Infrastructure.csproj", "ContactManagement.Infrastructure/"]

# Restore
RUN dotnet restore "ContactManagement.Presentation/ContactManagement.Presentation.csproj"

# Copy everything else
COPY . .

# Build
WORKDIR "/src/ContactManagement.Presentation"
RUN dotnet build "ContactManagement.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# -----------------------------
# Publish
# -----------------------------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ContactManagement.Presentation.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# -----------------------------
# Final image
# -----------------------------
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ContactManagement.Presentation.dll"]
