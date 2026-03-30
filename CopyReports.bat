@echo off
setlocal

set REPORTS_DIR=Reports

if not exist "bin\Debug\Reports" mkdir "bin\Debug\Reports"
if not exist "bin\Release\Reports" mkdir "bin\Release\Reports"

copy /Y "%REPORTS_DIR%\ClientsCarsReport.rdlc" "bin\Debug\Reports\" >nul
copy /Y "%REPORTS_DIR%\ClientsCarsReport.rdlc" "bin\Release\Reports\" >nul

echo RDLC files copied successfully
endlocal
