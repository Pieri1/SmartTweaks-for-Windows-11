param (
    [string]$Key
)

if (Test-Path $Key) {
    Write-Output "1"
} else {
    Write-Output "0"
}