# SggApp

Aplicación ASP.NET Core MVC para la gestión de gastos y presupuestos personales.

## Descripción Concisa

Esta aplicación permite gestionar gastos, presupuestos, usuarios, categorías y monedas. Implementa la arquitectura MVC con validaciones, navegación y vistas completas.

## Cómo Empezar (Getting Started)

### Prerrequisitos

- .NET 6 SDK o superior

### Instalación

```bash
git clone https://github.com/tuusuario/SggApp.git
cd SggApp
dotnet restore
dotnet run
```

## Funcionalidades

- CRUD para todas las entidades:
  - Usuarios
  - Gastos
  - Categorías
  - Monedas
  - Presupuestos
- Validaciones con DataAnnotations
- Navegación mediante Layout compartido
- Vistas Razor usando Razor Pages y TagHelpers

## Estructura del Proyecto

- Controllers/ : Controladores de cada entidad
- ViewModels/ : Modelos de presentación con validaciones
- Views/ : Vistas organizadas por entidad
- Views/Shared/ : Layout principal
- wwwroot/ : Archivos estáticos
- Program.cs : Configuración de la aplicación

## Video

Graba una demostración desde el navegador con las siguientes acciones:
- Crear, listar, editar, ver y eliminar gastos y presupuestos

## Link de Entrega

[Formulario de entrega](https://forms.gle/5JVtqxdRdr3a1j6f8)
