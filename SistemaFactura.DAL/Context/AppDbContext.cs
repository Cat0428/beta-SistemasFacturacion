using Microsoft.EntityFrameworkCore;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
    }
}
