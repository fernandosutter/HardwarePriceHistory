#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HardwarePriceHistory.WebAPI/HardwarePriceHistory.WebAPI.csproj", "HardwarePriceHistory.WebAPI/"]
RUN dotnet restore "HardwarePriceHistory.WebAPI/HardwarePriceHistory.WebAPI.csproj"
COPY . .
WORKDIR "/src/HardwarePriceHistory.WebAPI"
RUN dotnet build "HardwarePriceHistory.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HardwarePriceHistory.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HardwarePriceHistory.WebAPI.dll"]