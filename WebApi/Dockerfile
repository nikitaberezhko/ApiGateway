FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5050
EXPOSE 5051

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["IdentityService.Contracts/IdentityService.Contracts.csproj", "IdentityService.Contracts/"]
COPY ["CommonModel.Contracts/CommonModel.Contracts.csproj", "CommonModel.Contracts/"]
COPY ["FinanceService.Contracts/FinanceService.Contracts.csproj", "FinanceService.Contracts/"]
COPY ["OrderService.Contracts/OrderService.Contracts.csproj", "OrderService.Contracts/"]
COPY ["ContainerService.Contracts/ContainerService.Contracts.csproj", "ContainerService.Contracts/"]
RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
