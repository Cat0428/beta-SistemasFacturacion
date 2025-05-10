@echo off
setlocal enabledelayedexpansion

:: Establecer ruta base del script
set "BASEDIR=%~dp0"
cd /d "%BASEDIR%"

:: Nombre del proyecto DAL y App
set "DAL_PROJECT=SistemaFactura.DAL"
set "APP_PROJECT=SggApp"

:: Nombre de la base de datos (extraído de appsettings.json si quieres)
set "DB_NAME=SistemaFacturaDB"

:: Nombre del servidor SQL configurado
set "SQLSERVER=localhost\SQLEXPRESS"

echo ------------------------------
echo CERRANDO SERVICIOS SQL (opcional)...
echo ------------------------------
:: net stop MSSQL$SQLEXPRESS >nul 2>&1

echo ------------------------------
echo ELIMINANDO MIGRACIONES ANTERIORES...
echo ------------------------------
set "MIGRATIONS_PATH=%BASEDIR%%DAL_PROJECT%\Migrations"
if exist "%MIGRATIONS_PATH%" (
    rmdir /s /q "%MIGRATIONS_PATH%"
    echo ✅ Carpeta de migraciones eliminada.
) else (
    echo ℹ️ No se encontraron migraciones.
)

echo ------------------------------
echo ELIMINANDO BASE DE DATOS "%DB_NAME%" SI EXISTE...
echo ------------------------------
sqlcmd -S %SQLSERVER% -Q "DROP DATABASE IF EXISTS [%DB_NAME%]"
if %errorlevel% neq 0 (
    echo ❌ No se pudo eliminar la base de datos. Verifica que SQL Server esté en ejecución.
    pause
    exit /b
)

echo ------------------------------
echo CREANDO NUEVA MIGRACIÓN...
echo ------------------------------
dotnet ef migrations add Init ^
    --project "%BASEDIR%%DAL_PROJECT%" ^
    --startup-project "%BASEDIR%%APP_PROJECT%" ^
    --output-dir Migrations
if %errorlevel% neq 0 (
    echo ❌ Error al crear la migración.
    pause
    exit /b
)

echo ------------------------------
echo APLICANDO MIGRACIÓN A LA BASE DE DATOS...
echo ------------------------------
dotnet ef database update ^
    --project "%BASEDIR%%DAL_PROJECT%" ^
    --startup-project "%BASEDIR%%APP_PROJECT%"
if %errorlevel% neq 0 (
    echo ❌ Error al aplicar la migración.
    pause
    exit /b
)

echo ------------------------------
echo ✅ BASE DE DATOS REINICIADA Y ACTUALIZADA CON ÉXITO.
echo ------------------------------
pause
