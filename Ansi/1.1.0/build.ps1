Set-Location (Split-Path -Parent $MyInvocation.MyCommand.Definition)
docker rmi ansi:1.1.0
docker build -t ansi:1.1.0 .
