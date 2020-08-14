#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WarrantyTracking.WebAPI/WarrantyTracking.WebAPI.csproj", "WarrantyTracking.WebAPI/"]
COPY ["WarrantyTracking.Business/WarrantyTracking.Business.csproj", "WarrantyTracking.Business/"]
COPY ["WarrantyTracking.DataAccess/WarrantyTracking.DataAccess.csproj", "WarrantyTracking.DataAccess/"]
COPY ["WarrantyTracking.Entities/WarrantyTracking.Entities.csproj", "WarrantyTracking.Entities/"]
COPY ["WarrantyTracking.Core/WarrantyTracking.Core.csproj", "WarrantyTracking.Core/"]
RUN dotnet restore "WarrantyTracking.WebAPI/WarrantyTracking.WebAPI.csproj"
COPY . .
WORKDIR "/src/WarrantyTracking.WebAPI"
RUN dotnet build "WarrantyTracking.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WarrantyTracking.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WarrantyTracking.WebAPI.dll"]