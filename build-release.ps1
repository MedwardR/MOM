#!/usr/bin/env pwsh

$exitCode = 0

# Define the path to your application's directory relative to the script
# Adjust 'App' if your application folder has a different name
$appDirectory = "App" 

# Define the publish profile name (without extension)
# Common names: PublishProfiles\FolderProfile.pubxml, PublishProfiles\Release.pubxml
$publishProfile = "FolderProfile"

Write-Host "Releasing .NET application with publish profile..." -ForegroundColor Green

# Save current directory
$currentDir = Get-Location

# Change to the application directory
Set-Location $appDirectory

# Build and publish using the specified publish profile
dotnet publish -c Release -p:PublishProfile=$publishProfile

if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to publish .NET application. Exit code: $LASTEXITCODE" -ForegroundColor Red
    $exitCode = $LASTEXITCODE
}
else {
    Write-Host "Publish completed successfully!" -ForegroundColor Green

    # Change back to the script's original directory before running Inno Setup
    Set-Location $currentDir

    Write-Host "Building installer with Inno Setup..." -ForegroundColor Green
    iscc installer.iss

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Failed to build installer. Exit code: $LASTEXITCODE" -ForegroundColor Red
        $exitCode = $LASTEXITCODE
    }
    else {
        Write-Host "Installer build completed successfully!" -ForegroundColor Green
        Write-Host "Installer created at: Installer\MOMInstaller.exe" -ForegroundColor Cyan
    }
}

# Pause only if there was an error
if ($exitCode -ne 0) {
    Read-Host
}

exit $exitCode
