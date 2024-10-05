FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

# copy all .cproj and restore as distinct layers. Use of the same COPY command
# For every dockrefile in the project to ttake advantage of docker caching

COPY IdentityServer.sln IdentityServer.sln
COPY src/IdentityServer/IdentityServer.csproj src/IdentityServer/IdentityServer.csproj

# Restore package deps
RUN dotnet restore IdentityServer.sln

# Copy the app folders over
COPY . src/IdentityServer

WORKDIR /app/src/IdentityServer
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "IdentityServer.dll" ]