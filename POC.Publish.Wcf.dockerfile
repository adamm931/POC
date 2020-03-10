FROM  mcr.microsoft.com/dotnet/framework/sdk:4.8 as build

WORKDIR /app

COPY . .

RUN msbuild ./POC.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

FROM adamm93/iis-remote-wcf as runtime

ARG publish_folder

COPY --from=build /app/${publish_folder} /inetpub/wwwroot