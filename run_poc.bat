echo off

if not "%1" == "--build" ( 
	
	docker-compose up -d
	exit
)

echo "The build flag is present going to build image"
	
docker build -f POC.Build.dockerfile -t poc_build_nano .
docker tag poc_build_nano adamm93/poc_build_nano
docker push adamm93/poc_build_nano
docker-compose up --build -d

exit
