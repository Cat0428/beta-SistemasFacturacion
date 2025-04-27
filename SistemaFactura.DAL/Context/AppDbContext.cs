using Microsoft.EntityFrameworkCore;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Context
{
    /// <summary>
    /// Contexto de la base de datos que administra las entidades del sistema de facturación.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor que recibe las opciones de configuración del contexto.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Representa la tabla de usuarios en la base de datos.
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Representa la tabla de gastos en la base de datos.
        /// </summary>
        public DbSet<Gasto> Gastos { get; set; }

        /// <summary>
        /// Representa la tabla de categorías en la base de datos.
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }

        /// <summary>
        /// Representa la tabla de monedas en la base de datos.
        /// </summary>
        public DbSet<Moneda> Monedas { get; set; }

        /// <summary>
        /// Representa la tabla de presupuestos en la base de datos.
        /// </summary>
        public DbSet<Presupuesto> Presupuestos { get; set; }
    }
}
