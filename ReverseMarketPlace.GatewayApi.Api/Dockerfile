FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ReverseMarketPlace.GatewayApi.Api/ReverseMarketPlace.GatewayApi.Api.csproj", "ReverseMarketPlace.GatewayApi.Api/"]
RUN dotnet restore "ReverseMarketPlace.GatewayApi.Api/ReverseMarketPlace.GatewayApi.Api.csproj"
COPY . .
WORKDIR "/src/ReverseMarketPlace.GatewayApi.Api"
RUN dotnet build "ReverseMarketPlace.GatewayApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReverseMarketPlace.GatewayApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReverseMarketPlace.GatewayApi.Api.dll"]