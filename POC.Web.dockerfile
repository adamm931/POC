FROM  mcr.microsoft.com/dotnet/framework/sdk:4.8 as build

WORKDIR /app

COPY . .

RUN msbuild ./POC.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

FROM adamm93/iis-remote as runtime

COPY --from=build /app/POC.Web.Publish/ /inetpub/wwwroot