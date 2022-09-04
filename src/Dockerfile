#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
COPY ["src/TripsApp.Api/TripsApp.Api.csproj", "app/TripsApp.Api/"]
RUN dotnet restore "TripsApp.Api/TripsApp.Api.csproj"
COPY . .
#WORKDIR "/src/TripsApp.Api"
RUN dotnet build "src/TripsApp.Api/TripsApp.Api.csproj" -c Release -o app/build

FROM build AS publish
RUN dotnet publish "TripsApp.Api.csproj" -c Release -o app/publish

FROM base AS final
#WORKDIR /app
COPY --from=app/publish /app/publish .
ENTRYPOINT ["dotnet", "TripsApp.Api.dll"]