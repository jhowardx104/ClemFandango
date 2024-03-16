FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
RUN ls -al ..
COPY ["./ClemFandangoBot/ClemFandangoBot/ClemFandangoBot.csproj", "ClemFandangoBot/"]
COPY ["./ClemFandangoBot/ClemFandango.Common/ClemFandango.Common.csproj", "ClemFandango.Common/"]
RUN dotnet restore "ClemFandangoBot/ClemFandangoBot.csproj"
COPY . .
WORKDIR "/src/ClemFandangoBot"
RUN dotnet build "ClemFandangoBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClemFandangoBot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClemFandangoBot.dll"]
