param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"

$dbMigratorFolder = Join-Path $slnFolder "src/CmvApp.DbMigrator"

Write-Host "********* BUILDING DbMigrator *********" -ForegroundColor Green
Set-Location $dbMigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/cmvapp-db-migrator:$version .




$webFolder = Join-Path $slnFolder "src/CmvApp.Web"

Write-Host "********* BUILDING Web Application *********" -ForegroundColor Green
Set-Location $webFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/cmvapp-web:$version .



### ALL COMPLETED
Write-Host "COMPLETED" -ForegroundColor Green
Set-Location $currentFolder