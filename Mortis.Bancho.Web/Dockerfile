FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mortis.Scores/Mortis.Scores.csproj", "Mortis.Scores/"]
RUN dotnet restore "Mortis.Scores/Mortis.Scores.csproj"
COPY . .
WORKDIR "/src/Mortis.Scores"
RUN dotnet build "Mortis.Scores.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mortis.Scores.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mortis.Scores.dll"]
