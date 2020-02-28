cd C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin

MSBuild.exe C:\Develop\POC\POC.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

cd C:\Develop\POC