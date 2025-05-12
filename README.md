
# Sistema de Gestión de Gastos - FinApp

Este proyecto es una aplicación ASP.NET Core MVC con arquitectura en capas (DAL, BLL, API, MVC) para la gestión de gastos personales, presupuestos, categorías, monedas y usuarios.

---

## 🛠 Requisitos Previos

Antes de ejecutar la solución, asegúrate de tener instalado:

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server Express / LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)
- Visual Studio o un editor compatible con proyectos .NET

---

## ⚙️ Crear la Base de Datos

Se proporciona un archivo por lotes para automatizar el reinicio de la base de datos:

1. **Ejecutar el archivo** `Crear Base de datos.bat` como administrador.
2. Este archivo:
   - Elimina la base de datos anterior (`SggDb`) si existe.
   - Borra la carpeta de migraciones.
   - Cierra servicios de SQL si están en uso.
   - Crea una nueva migración.
   - Aplica la migración a la base de datos.

> **Nota:** Si usas una instancia distinta a `(localdb)\MSSQLLocalDB`, modifica la cadena de conexión en `appsettings.json` dentro de `SggApp`.

---

## ▶️ Ejecutar el Proyecto

1. Abre una terminal (cmd o PowerShell).
2. Navega al proyecto MVC:

```bash
cd beta-SistemasFacturacion/SggApp
```

3. Ejecuta la aplicación:

```bash
dotnet run
```

4. Abre el navegador y visita `https://localhost:xxxx` (la consola indicará el puerto exacto).

---

## 📦 Estructura del Proyecto

- `SistemaFactura.DAL` → Capa de acceso a datos (Entity Framework)
- `SistemaFactura.BLL` → Lógica de negocio
- `SistemaFactura.API` → API REST (opcional)
- `SggApp` → Capa de presentación (MVC)
- `Crear Base de datos.bat` → Automatiza la preparación de la base de datos

---

## 👤 Autor

Desarrollado por **Brian Cadavid Y Cristian López** 

---

## 📄 Licencia

Este proyecto se distribuye bajo fines educativos.
prueba