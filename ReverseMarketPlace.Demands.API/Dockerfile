FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ReverseMarketPlace.Demands.API/ReverseMarketPlace.Demands.API.csproj", "ReverseMarketPlace.Demands.API/"]
RUN dotnet restore "ReverseMarketPlace.Demands.API/ReverseMarketPlace.Demands.API.csproj"
COPY . .
WORKDIR "/src/ReverseMarketPlace.Demands.API"
RUN dotnet build "ReverseMarketPlace.Demands.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReverseMarketPlace.Demands.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReverseMarketPlace.Demands.API.dll"]