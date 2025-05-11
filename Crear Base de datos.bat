@echo off
setlocal enabledelayedexpansion

:: Establecer ruta base del script
set "BASEDIR=%~dp0"
cd /d "%BASEDIR%"

:: Nombre del proyecto DAL y App
set "DAL_PROJECT=SistemaFactura.DAL"
set "APP_PROJECT=SggApp"

:: Nombre de la base de datos
set "DB_NAME=SistemaFacturaDB"

:: Nombre del servidor SQL
set "SQLSERVER=localhost\SQLEXPRESS"

echo ------------------------------
echo VERIFICANDO EF TOOLS...
echo ------------------------------
dotnet tool list -g | findstr "ef" >nul
if errorlevel 1 (
    echo ❌ Entity Framework Core Tools no está instalado.
    echo Ejecuta: dotnet tool install --global dotnet-ef
    pause
    exit /b
)

echo ------------------------------
echo ELIMINANDO MIGRACIONES ANTERIORES...
echo ------------------------------
set "MIGRATIONS_PATH=%BASEDIR%%DAL_PROJECT%\Migrations"
if exist "%MIGRATIONS_PATH%" (
    rmdir /s /q "%MIGRATIONS_PATH%"
    echo ✅ Migraciones eliminadas.
) else (
    echo ℹ️ No se encontraron migraciones.
)

echo ------------------------------
echo ELIMINANDO BASE DE DATOS "%DB_NAME%" SI EXISTE...
echo ------------------------------
sqlcmd -S %SQLSERVER% -Q "DROP DATABASE IF EXISTS [%DB_NAME%]"
if %errorlevel% neq 0 (
    echo ❌ Error al eliminar la base de datos. ¿SQL Server está activo?
    pause
    exit /b
)

echo ------------------------------
echo CREANDO NUEVA MIGRACIÓN PARA LOGIN (Email y Password)...
echo ------------------------------
dotnet ef migrations add Init_Login ^
    --project "%BASEDIR%%DAL_PROJECT%" ^
    --startup-project "%BASEDIR%%APP_PROJECT%" ^
    --output-dir Migrations
if %errorlevel% neq 0 (
    echo ❌ Error al crear migración.
    pause
    exit /b
)

echo ------------------------------
echo APLICANDO MIGRACIÓN...
echo ------------------------------
dotnet ef database update ^
    --project "%BASEDIR%%DAL_PROJECT%" ^
    --startup-project "%BASEDIR%%APP_PROJECT%"
if %errorlevel% neq 0 (
    echo ❌ Error al actualizar la base de datos.
    pause
    exit /b
)

echo ------------------------------
echo ✅ MIGRACIÓN COMPLETADA Y LOGIN IMPLEMENTADO.
echo ------------------------------
pause
