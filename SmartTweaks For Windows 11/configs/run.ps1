# Aplica alterações de registro e reinicia o Explorer
Write-Output "[+] Iniciando aplicação de configurações..."
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarAl' -Type DWord -Value 0
# Reinício do Explorer
Stop-Process -Name explorer -Force -ErrorAction SilentlyContinue
Start-Sleep -Milliseconds 500
Start-Process explorer.exe
Write-Output "[+] Explorer reiniciado com sucesso."
