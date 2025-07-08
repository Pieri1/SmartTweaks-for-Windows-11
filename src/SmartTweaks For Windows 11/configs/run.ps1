# Aplica alterações de registro e reinicia o Explorer
Write-Output "[+] Iniciando aplicação de configurações..."
# Reinício do Explorer
Stop-Process -Name explorer -Force -ErrorAction SilentlyContinue
Start-Sleep -Milliseconds 500
Write-Output "[+] Explorer reiniciado com sucesso."
