FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
EXPOSE 80

ARG NEXUS_URL

ENV NEXUS_REPO=${NEXUS_URL}/repository/nuget-hosted

COPY IdentityServer.sln IdentityServer.sln
COPY src/IdentityServer/IdentityServer.csproj src/IdentityServer/IdentityServer.csproj 

RUN dotnet nuget locals all -c
RUN dotnet nuget add source ${NEXUS_REPO} --name Nexus --username admin --password 1234 --store-password-in-clear-text

RUN dotnet restore src/IdentityServer/IdentityServer.csproj

COPY . .

WORKDIR /app/src/IdentityServer

RUN dotnet publish -c Release -o /app/src/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "IdentityServer.dll" ]