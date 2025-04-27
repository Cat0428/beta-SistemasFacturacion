namespace SistemaFactura.DAL.Entities
{
    /// <summary>
    /// Representa una moneda utilizada para registrar gastos dentro del sistema.
    /// </summary>
    public class Moneda
    {
        /// <summary>
        /// Identificador único de la moneda.
        /// </summary>
        public int MonedaId { get; set; }

        /// <summary>
        /// Nombre de la moneda (por ejemplo, Peso Colombiano, Dólar Estadounidense).
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Símbolo asociado a la moneda (por ejemplo, $, €).
        /// </summary>
        public string Simbolo { get; set; }

        /// <summary>
        /// Colección de gastos asociados a esta moneda.
        /// </summary>
        public ICollection<Gasto> Gastos { get; set; }
    }
}
