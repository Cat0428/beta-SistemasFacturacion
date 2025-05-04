using Microsoft.EntityFrameworkCore;
using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Repositories;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.BLL.Servicios;


/// <summary>
/// Punto de entrada de la aplicación web API.
/// Configura los servicios, el middleware y ejecuta la aplicación.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
/// <summary>
/// Agrega el contexto de la base de datos usando Entity Framework Core.
/// </summary>
/// <remarks>
/// Utiliza la cadena de conexión "DefaultConnection" del archivo de configuración (appsettings.json).
/// </remarks>
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositorios
/// <summary>
/// Registra los repositorios genéricos y específicos para inyección de dependencias.
/// </summary>
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<MonedaRepository>();
builder.Services.AddScoped<PresupuestoRepository>();

// Registro de servicios
/// <summary>
/// Registra los servicios de la capa de negocio para inyección de dependencias.
/// </summary>
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMonedaService, MonedaService>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();

// Configuración de controladores
/// <summary>
/// Agrega los controladores de la API.
/// </summary>
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
/// <summary>
/// Agrega servicios para la generación de documentación API con Swagger.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construcción de la aplicación
var app = builder.Build();

// Middleware para desarrollo
/// <summary>
/// Habilita Swagger y su interfaz UI solo en entorno de desarrollo.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de autenticación y enrutamiento
/// <summary>
/// Habilita la autorización y mapea los controladores.
/// </summary>
app.UseAuthorization();
app.MapControllers();

// Ejecución de la aplicación
/// <summary>
/// Inicia la aplicación y comienza a escuchar solicitudes HTTP.
/// </summary>
app.Run();