FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
EXPOSE 80

ARG NEXUS_URL

ENV NEXUS_REPO=${NEXUS_URL}/repository/nuget-hosted

COPY Finances.sln Finances.sln
COPY src/FinanceController.Domain/FinanceController.Domain.csproj src/FinanceController.Domain/FinanceController.Domain.csproj 
COPY src/FinanceController.Domain.Api/FinanceController.Domain.Api.csproj src/FinanceController.Domain.Api/FinanceController.Domain.Api.csproj 
COPY src/FinanceController.Domain.Infra/FinanceController.Domain.Infra.csproj src/FinanceController.Domain.Infra/FinanceController.Domain.Infra.csproj 
COPY src/FinanceController.Domain.Shared/FinanceController.Domain.Shared.csproj src/FinanceController.Domain.Shared/FinanceController.Domain.Shared.csproj 
COPY src/FinanceController.Domain.Test/FinanceController.Domain.Test.csproj src/FinanceController.Domain.Test/FinanceController.Domain.Test.csproj 

RUN dotnet nuget locals all -c
RUN dotnet nuget add source ${NEXUS_REPO} --name Nexus --username admin --password 1234 --store-password-in-clear-text

RUN dotnet restore src/FinanceController.Domain.Api/FinanceController.Domain.Api.csproj

COPY . .

WORKDIR /app/src/FinanceController.Domain.Api

RUN dotnet publish -c Release -o /app/src/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "FinanceController.Domain.Api.dll" ]