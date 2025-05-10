@echo off
setlocal

:: Configura los nombres de los proyectos
set DAL_PROJECT=SistemaFactura.DAL
set STARTUP_PROJECT=SggApp
set MIGRATION_NAME=Inicial

echo ==============================================
echo == CREAR MIGRACIONES Y ACTUALIZAR LA BD ==
echo ==============================================

:: 1. Eliminar carpeta Migrations si existe
echo Eliminando carpeta de migraciones anterior (si existe)...
rmdir /S /Q %DAL_PROJECT%\Migrations 2>nul

:: 2. Crear nueva migración
echo Creando nueva migración '%MIGRATION_NAME%'...
dotnet ef migrations add %MIGRATION_NAME% --project %DAL_PROJECT% --startup-project %STARTUP_PROJECT%

:: 3. Aplicar migración
echo Aplicando migraciones a la base de datos existente...
dotnet ef database update --project %DAL_PROJECT% --startup-project %STARTUP_PROJECT%

echo ----------------------------------------------
echo Migraciones creadas y base de datos actualizada.
pause
