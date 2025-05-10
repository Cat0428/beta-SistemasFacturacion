@echo off
setlocal

:: Configuración del proyecto
set PROJECT=SistemaFactura.DAL
set STARTUP=SggApp
set MIGRATION=Inicial
set DB_NAME=SistemaFacturacionDB

:: Ruta de SQLCMD (asegúrate de tenerlo instalado si quieres validación por SQL)
set SQLCMD=sqlcmd

:: Eliminar carpeta Migrations si existe
if exist "%PROJECT%\Migrations" (
    echo Eliminando carpeta de migraciones...
    rmdir /s /q "%PROJECT%\Migrations"
)

:: Crear nueva migración
echo Creando migración '%MIGRATION%'...
dotnet ef migrations add %MIGRATION% --project %PROJECT% --startup-project %STARTUP%

:: Verificar si existe la base de datos (reemplaza con tu instancia si es diferente)
echo Verificando si existe la base de datos '%DB_NAME%'...

%SQLCMD% -Q "IF DB_ID(N'%DB_NAME%') IS NULL PRINT 'NO_EXISTE' ELSE PRINT 'EXISTE'" -h -1 > db_status.txt

set /p DBSTATUS=<db_status.txt
del db_status.txt

if /I "%DBSTATUS%"=="NO_EXISTE" (
    echo La base de datos no existe. Creándola...
    dotnet ef database update --project %PROJECT% --startup-project %STARTUP%
) else (
    echo ⚠ La base de datos '%DB_NAME%' ya existe. No se aplicó 'database update'.
)

endlocal
pause
