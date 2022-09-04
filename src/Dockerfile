#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
COPY ["./src/TripsApp.Api/TripsApp.Api.csproj", "app/TripsApp.Api/"]
RUN dotnet restore "app/TripsApp.Api/TripsApp.Api.csproj"
COPY ./src /app
#WORKDIR "/src/TripsApp.Api"
RUN dotnet build "app/TripsApp.Api/TripsApp.Api.csproj" -c Release -o app/build

FROM build AS publish
RUN dotnet publish "app/TripsApp.Api/TripsApp.Api.csproj" -c Release -o app/publish

FROM base AS final
#WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TripsApp.Api.dll"]