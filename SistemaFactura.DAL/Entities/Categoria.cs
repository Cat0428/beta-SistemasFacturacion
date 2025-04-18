namespace SistemaFactura.DAL.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        // Relación con Gasto
        public ICollection<Gasto> Gastos { get; set; }
    }
}
