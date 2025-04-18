namespace SistemaFactura.DAL.Entities
{
    public class Moneda
    {
        public int MonedaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Simbolo { get; set; }

        // Relación con Gasto
        public ICollection<Gasto> Gastos { get; set; }
    }
}
