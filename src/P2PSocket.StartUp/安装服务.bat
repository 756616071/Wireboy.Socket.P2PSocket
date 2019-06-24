cd /d %~dp0
set ServerName=P2PSocket
nssm install  %ServerName% "C:\Program Files\dotnet\dotnet.exe"
nssm set %ServerName% AppDirectory  %~dp0
nssm set %ServerName% AppParameters "P2PSocket.StartUp.dll"
nssm start %ServerName%
cmd

