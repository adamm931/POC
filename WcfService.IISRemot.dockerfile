FROM adamm93/iis-remote

SHELL [ "powershell" ]

RUN Enable-WindowsOptionalFeature -Online -FeatureName "WCF-Services45" -All
RUN Enable-WindowsOptionalFeature -Online -FeatureName "WCF-HTTP-Activation45" -All