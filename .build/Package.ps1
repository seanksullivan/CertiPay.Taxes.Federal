param (
	[string]$Configuration = 'Debug'
)

$ErrorActionPreference = "Stop"

$Here = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"

$SolutionRoot = (Split-Path -parent $Here)

$NuGet = Join-Path $SolutionRoot ".nuget\nuget.exe"

. $NuGet pack "$SolutionRoot\CertiPay.Taxes.Federal\CertiPay.Taxes.Federal.nuspec" -Properties Configuration=$Configuration -OutputDirectory "$SolutionRoot"

EXIT $LASTEXITCODE