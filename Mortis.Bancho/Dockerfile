FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mortis.Bancho/Mortis.Bancho.csproj", "Mortis.Bancho/"]
RUN dotnet restore "Mortis.Bancho/Mortis.Bancho.csproj"
COPY . .
WORKDIR "/src/Mortis.Bancho"
RUN dotnet build "Mortis.Bancho.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mortis.Bancho.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mortis.Bancho.dll"]
