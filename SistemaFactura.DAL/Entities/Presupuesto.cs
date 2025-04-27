namespace SistemaFactura.DAL.Entities
{
    /// <summary>
    /// Representa un presupuesto asignado a un usuario dentro del sistema.
    /// </summary>
    public class Presupuesto
    {
        /// <summary>
        /// Identificador único del presupuesto.
        /// </summary>
        public int PresupuestoId { get; set; }

        /// <summary>
        /// Monto asignado para el presupuesto.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha de inicio del periodo del presupuesto.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de fin del periodo del presupuesto.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Identificador del usuario al que pertenece el presupuesto (clave foránea).
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Usuario asociado a este presupuesto.
        /// </summary>
        public Usuario Usuario { get; set; }
    }
}
