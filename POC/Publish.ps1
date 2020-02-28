# Define
$msbuild = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
$options = "/p:PublishProfile='Default' /p:VisualStudioVersion=14.0  /p:AspnetMergePath='C:\Program` Files` (x86)\Microsoft` SDKs\Windows\v10.0A\bin\NETFX` 4.8` Tools' /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True"
$proj = "C:\Develop\POC\POC\POC.csproj"

# Execute
$build = $msbuild + " $proj " + $options


Invoke-Expression $build