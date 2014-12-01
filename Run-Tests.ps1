$ScriptPath = Split-Path $MyInvocation.MyCommand.Path

Set-Alias nunit "$(Join-Path $ScriptPath 'packages\NUnit.Runners.2.6.3\tools\nunit-console.exe')"

$ProjectFile = Join-Path $ScriptPath "CertiPay.Taxes.Federal.Tests\bin\Debug\CertiPay.Taxes.Federal.Tests.dll"
 
nunit $ProjectFile