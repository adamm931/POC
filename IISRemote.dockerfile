FROM microsoft/aspnet

SHELL [ "powershell" ]

RUN Install-WindowsFeature Web-Mgmt-Service;
RUN New-ItemProperty -Path HKLM:\software\microsoft\WebManagement\Server -Name EnableRemoteManagement -Value 1 -Force;
RUN Set-Service -Name wmsvc -StartupType automatic;

RUN net user iisadmin Password~1234 /add;
RUN net localgroup administrators iisadmin /add;