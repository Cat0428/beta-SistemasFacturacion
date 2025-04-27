namespace SistemaFactura.DAL.Entities
{
    /// <summary>
    /// Representa un gasto realizado por un usuario dentro del sistema.
    /// </summary>
    public class Gasto
    {
        /// <summary>
        /// Identificador único del gasto.
        /// </summary>
        public int GastoId { get; set; }

        /// <summary>
        /// Monto asociado al gasto.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha en la que se realizó el gasto.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Descripción opcional del gasto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó el gasto (clave foránea).
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Usuario asociado al gasto.
        /// </summary>
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Identificador de la categoría del gasto (clave foránea).
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Categoría asociada al gasto.
        /// </summary>
        public Categoria Categoria { get; set; }

        /// <summary>
        /// Identificador de la moneda utilizada en el gasto (clave foránea).
        /// </summary>
        public int MonedaId { get; set; }

        /// <summary>
        /// Moneda asociada al gasto.
        /// </summary>
        public Moneda Moneda { get; set; }
    }
}
