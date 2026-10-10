[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
$repoRoot = Split-Path -Parent $PSScriptRoot
$frontendPath = Join-Path $repoRoot 'src\Auth.Frontend'

if (-not (Get-Command npm.cmd -ErrorAction SilentlyContinue)) {
    throw 'npm was not found. Install Node.js 24.21.0 and open a new PowerShell session.'
}

if (-not (Test-Path -LiteralPath (Join-Path $frontendPath 'node_modules\@angular\cli\bin\ng.js'))) {
    throw "Frontend dependencies are missing. Run npm ci in '$frontendPath' first."
}

Start-Process -FilePath $env:ComSpec `
    -ArgumentList '/k', 'title AuthApi - Frontend && npm.cmd start' `
    -WorkingDirectory $frontendPath `
    -WindowStyle Normal

Write-Host 'Frontend started in a separate command window: http://localhost:4200'
