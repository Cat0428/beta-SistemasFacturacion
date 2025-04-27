
# Sistema de Facturación - Proyecto N-Capas

Este proyecto implementa un sistema básico de facturación utilizando la arquitectura de **tres capas**:

- **Presentación (API)**: `SistemaFactura.API`
- **Lógica de Negocio (BLL)**: `SistemaFactura.BLL`
- **Acceso a Datos (DAL)**: `SistemaFactura.DAL`

---

## 🚀 Tecnologías Utilizadas

- **.NET 9.0**
- **Entity Framework Core 9.0.4**
- **SQL Server LocalDB**
- **Swagger para documentación de la API**

---

## 🏢 Estructura del Proyecto

```
SistemaFactura.API       --> API REST para interactuar con el sistema
SistemaFactura.BLL       --> Lógica de negocio: Interfaces y Servicios
SistemaFactura.DAL
  ├── Context            --> AppDbContext (conexión y configuración de entidades)
  ├── Entities           --> Entidades: Usuario, Gasto, Moneda, Categoria, Presupuesto
  └── Repositories       --> Repositorios genéricos y específicos
```

---

## 🛠️ Configuración del Proyecto

### 1. Conexión a Base de Datos

El proyecto utiliza **SQL Server LocalDB**.  
La cadena de conexión está ubicada en `SistemaFactura.API/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=SistemaFacturaDB;Trusted_Connection=True;"
}
```

### 2. Contexto de Datos

El `AppDbContext` registra los conjuntos (`DbSet`) de entidades y las relaciones uno-a-muchos.

---

## 🗄️ Migraciones

- Se creó la migración inicial `InitialCreate`.
- Se aplicó la migración usando `dotnet ef database update`.
- La base de datos `SistemaFacturaDB` fue generada con todas las tablas relacionadas.

Comandos utilizados:

```bash
dotnet ef migrations add InitialCreate --project SistemaFactura.DAL --startup-project SistemaFactura.API
dotnet ef database update --project SistemaFactura.DAL --startup-project SistemaFactura.API
```

---

## 📦 Patrón de Repositorios

Se implementó el patrón de repositorios:

- `GenericRepository<T>` contiene métodos CRUD básicos.
- Repositorios específicos como `UsuarioRepository`, `GastoRepository`, etc., heredan de `GenericRepository`.

Esto promueve la reutilización de código y facilita el mantenimiento.

---

## 📄 Capa BLL - Lógica de Negocio

La capa BLL incluye:

- **Interfaces** para definir los contratos de servicio (`IUsuarioService`, `IGastoService`, etc.).
- **Servicios** que implementan las reglas de negocio (`UsuarioService`, `GastoService`, etc.).

Cada servicio:
- Utiliza los repositorios DAL.
- Implementa métodos para crear, actualizar, eliminar y consultar datos.
- Está documentado con **comentarios XML** profesionales para mejorar la legibilidad y soporte de documentación Swagger.

### Comentarios XML

Todos los servicios e interfaces BLL fueron documentados utilizando comentarios XML. Esto permite:
- Mejorar la navegación en el código (IntelliSense).
- Generar documentación automática en Swagger.

Configuración de Swagger para leer XML:

```csharp
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
```

---

## 📓 Endpoints de Prueba

Swagger está configurado en `SistemaFactura.API` para probar los endpoints de manera rápida.

Acceso a Swagger:  
```
https://localhost:{puerto}/swagger/index.html
```

---

## 👨‍💻 Cómo Ejecutar

1. Clona el repositorio.
2. Restaura los paquetes:

```bash
dotnet restore
```

3. Corre la migración para crear la base de datos:

```bash
dotnet ef database update --project SistemaFactura.DAL --startup-project SistemaFactura.API
```

4. Ejecuta el proyecto API:

```bash
dotnet run --project SistemaFactura.API
```

5. Accede a Swagger para probar los endpoints.

---
