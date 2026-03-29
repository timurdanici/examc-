@echo off
setlocal

set REPORTS_DIR=Reports

if not exist "bin\Debug\Reports" mkdir "bin\Debug\Reports"
if not exist "bin\Release\Reports" mkdir "bin\Release\Reports"

copy /Y "%REPORTS_DIR%\AllProducts.rdlc" "bin\Debug\Reports\" >nul
copy /Y "%REPORTS_DIR%\CategoriesSummary.rdlc" "bin\Debug\Reports\" >nul
copy /Y "%REPORTS_DIR%\SuppliersSummary.rdlc" "bin\Debug\Reports\" >nul

copy /Y "%REPORTS_DIR%\AllProducts.rdlc" "bin\Release\Reports\" >nul
copy /Y "%REPORTS_DIR%\CategoriesSummary.rdlc" "bin\Release\Reports\" >nul
copy /Y "%REPORTS_DIR%\SuppliersSummary.rdlc" "bin\Release\Reports\" >nul

echo RDLC files copied successfully
endlocal
