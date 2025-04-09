# Aplica alterações de registro e reinicia o Explorer
Write-Output "[+] Iniciando aplicação de configurações..."
Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel' -Name '{20D04FE0-3AEA-1069-A2D8-08002B30309D}' -Type DWord -Value 1; Set-ItemProperty -Path 'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\ClassicStartMenu' -Name '{20D04FE0-3AEA-1069-A2D8-08002B30309D}' -Type DWord -Value 1
Remove-Item -Path 'HKCU:\SOFTWARE\CLASSES\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32' -Recurse -Force -ErrorAction SilentlyContinue
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\CabinetState' -Name 'FullPath' -Type DWord -Value 1
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'Hidden' -Type DWord -Value 2
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'HideFileExt' -Type DWord -Value 0
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'UseCompactMode' -Type DWord -Value 1
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'ShowEncryptCompressedColor' -Type DWord -Value 0
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarGlomLevel' -Type DWord -Value 1
Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarAl' -Type DWord -Value 0
# Reinício do Explorer
Stop-Process -Name explorer -Force -ErrorAction SilentlyContinue
Start-Sleep -Milliseconds 500
Start-Process explorer.exe
Write-Output "[+] Explorer reiniciado com sucesso."
