cd C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin

MSBuild.exe C:\Dev\POC\POC.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

cd C:\Dev\POC 