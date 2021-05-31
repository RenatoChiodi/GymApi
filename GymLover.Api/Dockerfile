#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GymLover.Api/GymLover.Api.csproj", "GymLover.Api/"]
COPY ["GymLover.Domain/GymLover.Domain.csproj", "GymLover.Domain/"]
COPY ["GymLover.DataAccess/GymLover.DataAccess.csproj", "GymLover.DataAccess/"]
RUN dotnet restore "GymLover.Api/GymLover.Api.csproj"
COPY . .
WORKDIR "/src/GymLover.Api"
RUN dotnet build "GymLover.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymLover.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymLover.Api.dll"]