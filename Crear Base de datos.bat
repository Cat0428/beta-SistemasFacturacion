@echo off
setlocal

echo ============================
echo INICIANDO PROCESO EF MIGRATION
echo ============================

echo Restaurando paquetes...
dotnet restore

echo Compilando el proyecto...
dotnet build SggApp\SggApp.csproj
IF ERRORLEVEL 1 (
    echo Error en la compilación. Abortando...
    exit /b 1
)

:: Eliminar carpeta de migraciones si existe
IF EXIST "SistemaFactura.DAL\Migrations" (
    echo Eliminando carpeta de migraciones existente...
    rmdir /s /q "SistemaFactura.DAL\Migrations"
)

:: Crear migración limpia
echo Creando nueva migración Inicial...
dotnet ef migrations add Inicial --project SistemaFactura.DAL --startup-project SggApp

:: Eliminar la base de datos si ya existe
echo Eliminando la base de datos existente...
dotnet ef database drop --project SistemaFactura.DAL --startup-project SggApp --force --no-build --yes

:: Crear y aplicar la nueva base de datos
echo Aplicando migraciones y creando nueva base de datos...
dotnet ef database update --project SistemaFactura.DAL --startup-project SggApp

IF %ERRORLEVEL% EQU 0 (
    echo Base de datos recreada correctamente.
) ELSE (
    echo Error al crear la base de datos.
)

pause
endlocal
