using SistemaFactura.DAL.Entities;

namespace SistemaFactura.BLL.Interfaces
{
    /// <summary>
    /// Interfaz de servicio para la gestión de presupuestos
    /// </summary>
    /// <remarks>
    /// Define las operaciones CRUD para la entidad Presupuesto
    /// </remarks>
    public interface IPresupuestoService
    {
        /// <summary>
        /// Obtiene todos los presupuestos registrados
        /// </summary>
        /// <returns>
        /// Colección enumerable de todos los presupuestos
        /// </returns>
        /// <exception cref="DatabaseException">Error al acceder a la base de datos</exception>
        Task<IEnumerable<Presupuesto>> ObtenerTodosAsync();

        /// <summary>
        /// Obtiene un presupuesto específico por su ID
        /// </summary>
        /// <param name="id">Identificador único del presupuesto (debe ser mayor a 0)</param>
        /// <returns>
        /// El presupuesto encontrado o null si no existe
        /// </returns>
        /// <exception cref="ArgumentException">Cuando el ID es inválido</exception>
        /// <exception cref="EntityNotFoundException">Cuando no se encuentra el presupuesto</exception>
        /// <exception cref="DatabaseException">Error al acceder a la base de datos</exception>
        Task<Presupuesto> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Crea un nuevo presupuesto
        /// </summary>
        /// <param name="presupuesto">Datos del presupuesto a crear</param>
        /// <returns>Tarea asíncrona</returns>
        /// <exception cref="ArgumentNullException">Cuando el presupuesto es nulo</exception>
        /// <exception cref="ValidationException">Cuando fallan las validaciones de negocio</exception>
        /// <exception cref="DatabaseException">Error al acceder a la base de datos</exception>
        Task CrearAsync(Presupuesto presupuesto);

        /// <summary>
        /// Actualiza un presupuesto existente
        /// </summary>
        /// <param name="presupuesto">Datos actualizados del presupuesto</param>
        /// <returns>Tarea asíncrona</returns>
        /// <exception cref="ArgumentNullException">Cuando el presupuesto es nulo</exception>
        /// <exception cref="ValidationException">Cuando fallan las validaciones de negocio</exception>
        /// <exception cref="EntityNotFoundException">Cuando no se encuentra el presupuesto</exception>
        /// <exception cref="DatabaseException">Error al acceder a la base de datos</exception>
        Task ActualizarAsync(Presupuesto presupuesto);

        /// <summary>
        /// Elimina un presupuesto por su ID
        /// </summary>
        /// <param name="id">Identificador único del presupuesto</param>
        /// <returns>Tarea asíncrona</returns>
        /// <exception cref="ArgumentException">Cuando el ID es inválido</exception>
        /// <exception cref="EntityNotFoundException">Cuando no se encuentra el presupuesto</exception>
        /// <exception cref="DatabaseException">Error al acceder a la base de datos</exception>
        /// <exception cref="InvalidOperationException">Cuando el presupuesto no puede eliminarse por restricciones</exception>
        Task EliminarAsync(int id);
    }
}