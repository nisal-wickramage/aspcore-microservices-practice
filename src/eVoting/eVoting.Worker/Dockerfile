#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["eVoting.Worker/eVoting.Worker.csproj", "eVoting.Worker/"]
COPY ["eVoting.Domain/eVoting.Domain.csproj", "eVoting.Domain/"]
COPY ["eVoting.Infra/eVoting.Infra.csproj", "eVoting.Infra/"]
COPY ["eVoting.Application/eVoting.Application.csproj", "eVoting.Application/"]
RUN dotnet restore "eVoting.Worker/eVoting.Worker.csproj"
COPY . .
WORKDIR "/src/eVoting.Worker"
RUN dotnet build "eVoting.Worker.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "eVoting.Worker.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eVoting.Worker.dll"]
