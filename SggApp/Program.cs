using Microsoft.EntityFrameworkCore;
using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Repositories;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// 👉 Configura la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 👉 Interfaces de servicios (BLL)
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMonedaService, MonedaService>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();

// 👉 Repositorios concretos (DAL)
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<MonedaRepository>();
builder.Services.AddScoped<PresupuestoRepository>();

// 👉 MVC
// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();