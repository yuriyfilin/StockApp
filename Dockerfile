FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["StockApp.Web/StockApp.Web.csproj", "StockApp.Web/"]
COPY ["StockApp.Domain/StockApp.Domain.csproj", "StockApp.Domain/"]
COPY ["StockApp.Application/StockApp.Application.csproj", "StockApp.Application/"]
COPY ["StockApp.Infrastructure/StockApp.Infrastructure.csproj", "StockApp.Infrastructure/"]
RUN dotnet restore "StockApp.Web/StockApp.Web.csproj"
COPY . .
WORKDIR "/src/StockApp.Web"
RUN dotnet build "StockApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockApp.Web.dll"]
