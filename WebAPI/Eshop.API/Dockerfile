FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Eshop.API/Eshop.API.csproj", "Eshop.API/"]
RUN dotnet restore "Eshop.API/Eshop.API.csproj"
COPY . .
WORKDIR "/src/Eshop.API"
RUN dotnet build "Eshop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eshop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eshop.API.dll"]