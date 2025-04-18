namespace SistemaFactura.DAL.Entities
{
    public class Presupuesto
    {
        public int PresupuestoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
