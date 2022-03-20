#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["eVoting.Result.Api/eVoting.Result.Api.csproj", "eVoting.Result.Api/"]
COPY ["eVoting.Domain/eVoting.Domain.csproj", "eVoting.Domain/"]
COPY ["eVoting.Infra/eVoting.Infra.csproj", "eVoting.Infra/"]
COPY ["eVoting.Application/eVoting.Application.csproj", "eVoting.Application/"]
RUN dotnet restore "eVoting.Result.Api/eVoting.Result.Api.csproj"
COPY . .
WORKDIR "/src/eVoting.Result.Api"
RUN dotnet build "eVoting.Result.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "eVoting.Result.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eVoting.Result.Api.dll"]
