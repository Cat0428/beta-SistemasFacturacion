using SistemaFactura.DAL.Entities; // Namespace corregido

namespace SistemaFactura.BLL.Interfaces
{
    /// <summary>
    /// Interfaz de servicio para la gestión de monedas.
    /// </summary>
    /// <remarks>
    /// Define las operaciones básicas CRUD para la entidad Moneda.
    /// </remarks>
    public interface IMonedaService
    {
        /// <summary>
        /// Obtiene todas las monedas registradas de forma asíncrona.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado contiene
        /// una colección enumerable de todas las monedas.
        /// </returns>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task<IEnumerable<Moneda>> ObtenerTodoAsync(); // Nombre del método corregido

        /// <summary>
        /// Obtiene una moneda específica por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">ID de la moneda a buscar (debe ser mayor a 0).</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado contiene
        /// la moneda encontrada o null si no existe.
        /// </returns>
        /// <exception cref="ArgumentException">Se lanza cuando el ID es menor o igual a 0.</exception>
        /// <exception cref="EntityNotFoundException">Se lanza cuando no se encuentra la moneda con el ID especificado.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task<Moneda> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Crea una nueva moneda de forma asíncrona.
        /// </summary>
        /// <param name="moneda">Objeto Moneda con los datos a crear (no puede ser nulo).</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro moneda es nulo.</exception>
        /// <exception cref="ValidationException">Se lanza cuando no se cumplen las reglas de validación de la moneda.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task CrearAsync(Moneda moneda);

        /// <summary>
        /// Actualiza los datos de una moneda existente de forma asíncrona.
        /// </summary>
        /// <param name="moneda">Objeto Moneda con los datos actualizados (no puede ser nulo).</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro moneda es nulo.</exception>
        /// <exception cref="ValidationException">Se lanza cuando no se cumplen las reglas de validación.</exception>
        /// <exception cref="EntityNotFoundException">Se lanza cuando no existe la moneda a actualizar.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task ActualizarAsync(Moneda moneda);

        /// <summary>
        /// Elimina una moneda específica por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">ID de la moneda a eliminar (debe ser mayor a 0).</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el ID es menor o igual a 0.</exception>
        /// <exception cref="EntityNotFoundException">Se lanza cuando no se encuentra la moneda con el ID especificado.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        /// <exception cref="InvalidOperationException">Se lanza cuando la moneda no puede eliminarse por estar siendo utilizada en otras entidades.</exception>
        Task EliminarAsync(int id);
    }
}