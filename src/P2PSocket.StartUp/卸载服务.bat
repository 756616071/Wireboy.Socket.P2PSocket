cd /d %~dp0
set ServerName=P2PSocket
nssm stop %ServerName%
nssm remove %ServerName% confirm
