namespace SistemaFactura.DAL.Entities
{
    /// <summary>
    /// Representa una categoría de gasto dentro del sistema.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Colección de gastos asociados a esta categoría.
        /// </summary>
        public ICollection<Gasto> Gastos { get; set; }
    }
}
