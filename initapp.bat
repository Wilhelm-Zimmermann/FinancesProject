@echo off
cls

cd FinancesLibrary

echo Packing Library...
dotnet pack

cd FinancesLibrary\bin\Release

echo Pushing Library to repository...
dotnet nuget push FinancesLibrary.1.0.0.nupkg --source Nexus

cd ..\..\..\..\

cd Finances

echo Building finances-api image
docker buildx build --build-arg NEXUS_URL=http://127.0.0.1:8081 --load -t finances-api .

cd ..

cd FinancesIdentityServer

echo Building finances-identity image
docker buildx build --build-arg NEXUS_URL=http://127.0.0.1:8081 --load -t finances-identity .

cd ..

echo Creating finances containers...
docker-compose up -d
echo Done
