set poc_dir=POC%random%

cd ../

mkdir %poc_dir%

cd %poc_dir%

git clone https://github.com/adamm931/POC.git

cd POC

docker-compose up -d

cd ../../

rmdir /s /q %poc_dir%



