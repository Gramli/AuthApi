[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
$repoRoot = Split-Path -Parent $PSScriptRoot
$backendPath = Join-Path $repoRoot 'src\Auth.Api'

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw 'dotnet was not found. Install the .NET 10 SDK and open a new PowerShell session.'
}

Start-Process -FilePath $env:ComSpec `
    -ArgumentList '/k', 'title AuthApi - Backend && dotnet build --configuration Debug && dotnet run --no-build --configuration Debug --launch-profile https' `
    -WorkingDirectory $backendPath `
    -WindowStyle Normal

Write-Host 'Backend build and startup launched in a separate command window: https://localhost:7190'
