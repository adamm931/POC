echo off

if not "%1" == "--build" ( 
	
	docker-compose up -d --remove-orphans
	exit
)

echo "The build flag is present going to build image"

@rem remove old image
docker rmi adamm93/poc_build_nano

@rem rebuild new one
docker build -f POC.Build.dockerfile -t poc_build_nano .
docker tag poc_build_nano adamm93/poc_build_nano
docker push adamm93/poc_build_nano

@rem compose
docker-compose up --build -d --remove-orphans

echo Finished