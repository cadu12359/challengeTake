FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["challengeTake/challengeTake.csproj", "challengeTake/"]
RUN dotnet restore "challengeTake/challengeTake.csproj"
COPY ./challengeTake ./challengeTake
WORKDIR "/src/challengeTake"
RUN dotnet build "challengeTake.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "challengeTake.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet challengeTake.dll