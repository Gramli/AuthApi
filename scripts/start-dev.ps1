[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'

# Check both prerequisites before opening either window.
Get-Command dotnet, npm.cmd -ErrorAction Stop | Out-Null
$repoRoot = Split-Path -Parent $PSScriptRoot
$frontendPath = Join-Path $repoRoot 'src\Auth.Frontend'
if (-not (Test-Path -LiteralPath (Join-Path $frontendPath 'node_modules\@angular\cli\bin\ng.js'))) {
    throw "Frontend dependencies are missing. Run npm ci in '$frontendPath' first."
}

& (Join-Path $PSScriptRoot 'start-backend.ps1')
& (Join-Path $PSScriptRoot 'start-frontend.ps1')
