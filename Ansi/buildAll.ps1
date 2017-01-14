$children = Get-ChildItem . -Directory
$children | forEach-Object { 
     Start-Process -FilePath powershell.exe -ArgumentList "-File $_/build.ps1"  
}
