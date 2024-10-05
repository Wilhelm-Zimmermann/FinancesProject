clear
cd ./FinancesLibrary

echo -e "\e[32mPacking Library...\e[0m"
dotnet pack

cd ./FinancesLibrary/bin/Release

echo -e "\e[32mPushing Library to repository...\e[0m"
dotnet nuget push FinancesLibrary.1.0.0.nupkg --source Nexus

cd ../../../../

cd ./Finances

echo -e "\e[32mBuilding finances-api image\e[0m"
docker buildx build --build-arg NEXUS_URL=http://127.0.0.1:8081 --load -t finances-api .

cd ../
cd ./FinancesIdentityServer

echo -e "\e[32mBuilding finances-identity image\e[0m"
docker buildx build --build-arg NEXUS_URL=http://127.0.0.1:8081 --load -t finances-identity .

cd ../

echo -e "\e[35mCreating finances containers...\e[0m"
docker compose up -d
echo -e "\e[32mDone\e[0m"