FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mortis.Router/Mortis.Router.csproj", "Mortis.Router/"]
RUN dotnet restore "Mortis.Router/Mortis.Router.csproj"
COPY . .
WORKDIR "/src/Mortis.Router"
RUN dotnet build "Mortis.Router.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mortis.Router.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mortis.Router.dll"]
