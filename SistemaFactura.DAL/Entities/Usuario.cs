namespace SistemaFactura.DAL.Entities
{
    /// <summary>
    /// Representa un usuario dentro del sistema de facturación.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Clave o contraseña del usuario.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Colección de gastos registrados por el usuario.
        /// </summary>
        public ICollection<Gasto> Gastos { get; set; }

        /// <summary>
        /// Colección de presupuestos asignados al usuario.
        /// </summary>
        public ICollection<Presupuesto> Presupuestos { get; set; }
        public string Rol { get; set; } = "Usuario"; // por defecto

        
    }
}
