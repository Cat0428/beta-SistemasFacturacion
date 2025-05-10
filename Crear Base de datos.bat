@echo off
setlocal

echo Restaurando paquetes...
dotnet restore

echo Compilando el proyecto...
dotnet build SggApp\SggApp.csproj
IF ERRORLEVEL 1 (
    echo Error en la compilación. Abortando...
    exit /b 1
)

echo Aplicando migraciones y creando la base de datos...
dotnet ef database update --project SistemaFactura.DAL --startup-project SggApp

IF %ERRORLEVEL% EQU 0 (
    echo Base de datos creada correctamente.
) ELSE (
    echo Error al crear la base de datos.
)

pause
endlocal
