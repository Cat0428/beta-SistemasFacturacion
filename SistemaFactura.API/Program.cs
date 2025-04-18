
using Microsoft.EntityFrameworkCore;
using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Agregar conexión a la base de datos (ejemplo en memoria, si no tienes aún SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SistemaFacturaDB"));  // ✅ Usamos base de datos en memoria por ahora

// Agregar inyección de dependencias de los repositorios
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<MonedaRepository>();
builder.Services.AddScoped<PresupuestoRepository>();

// Agregar controladores
builder.Services.AddControllers();

// Agregar swagger para pruebas
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware para rutas
app.UseAuthorization();
app.MapControllers();
app.Run();
