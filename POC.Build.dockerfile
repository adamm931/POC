FROM  mcr.microsoft.com/dotnet/framework/sdk:4.8 as build

WORKDIR /app

COPY . .

RUN msbuild ./POC.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile -m

FROM mcr.microsoft.com/windows/nanoserver:1909

WORKDIR /app

COPY --from=build /app/POC.Web.Publish /app/POC.Web.Publish
COPY --from=build /app/POC.Todos.Service.Publish /app/POC.Todos.Service.Publish
COPY --from=build /app/POC.Identity.Service.Publish /app/POC.Identity.Service.Publish
COPY --from=build /app/POC.Identity.Web.Publish /app/POC.Identity.Web.Publish
COPY --from=build /app/POC.Accounts.Service.Publish /app/POC.Accounts.Service.Publish