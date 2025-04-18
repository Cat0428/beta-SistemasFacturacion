namespace SistemaFactura.DAL.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        // Relaciones
        public ICollection<Gasto> Gastos { get; set; }
        public ICollection<Presupuesto> Presupuestos { get; set; }
    }
}
