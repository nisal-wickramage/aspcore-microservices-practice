#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["eVoting.Api/eVoting.Api.csproj", "eVoting.Api/"]
COPY ["eVoting.Domain/eVoting.Domain.csproj", "eVoting.Domain/"]
RUN dotnet restore "eVoting.Api/eVoting.Api.csproj"
COPY . .
WORKDIR "/src/eVoting.Api"
RUN dotnet build "eVoting.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eVoting.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eVoting.Api.dll"]
