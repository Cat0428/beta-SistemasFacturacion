using SistemaFactura.DAL.Entities;

namespace SistemaFactura.BLL.Interfaces
{
    /// <summary>
    /// Interfaz de servicio para la gestión de categorías.
    /// </summary>
    /// <remarks>
    /// Define las operaciones básicas CRUD para la entidad Categoría.
    /// </remarks>
    public interface ICategoriaService
    {
        /// <summary>
        /// Obtiene todas las categorías de forma asíncrona.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado contiene
        /// una colección enumerable de todas las categorías.
        /// </returns>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task<IEnumerable<Categoria>> ObtenerTodosAsync();

        /// <summary>
        /// Obtiene una categoría por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">ID de la categoría a buscar (debe ser mayor a 0).</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado contiene
        /// la categoría encontrada o null si no existe.
        /// </returns>
        /// <exception cref="ArgumentException">Se lanza cuando el ID es menor o igual a 0.</exception>
        /// <exception cref="EntityNotFoundException">Se lanza cuando no se encuentra la categoría con el ID especificado.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task<Categoria> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Crea una nueva categoría de forma asíncrona.
        /// </summary>
        /// <param name="categoria">Objeto Categoria con los datos a crear (no puede ser nulo).</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro categoría es nulo.</exception>
        /// <exception cref="ValidationException">Se lanza cuando no se cumplen las reglas de validación de la categoría.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task CrearAsync(Categoria categoria);

        /// <summary>
        /// Actualiza una categoría existente de forma asíncrona.
        /// </summary>
        /// <param name="categoria">Objeto Categoria con los datos actualizados (no puede ser nulo).</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro categoría es nulo.</exception>
        /// <exception cref="ValidationException">Se lanza cuando no se cumplen las reglas de validación.</exception>
        /// <exception cref="EntityNotFoundException">Se lanza cuando no existe la categoría a actualizar.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        Task ActualizarAsync(Categoria categoria);

        /// <summary>
        /// Elimina una categoría por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">ID de la categoría a eliminar (debe ser mayor a 0).</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el ID es menor o igual a 0.</exception>
        /// <exception cref="EntityNotFoundException">Se lanza cuando no se encuentra la categoría con el ID especificado.</exception>
        /// <exception cref="DatabaseException">Se lanza cuando falla una operación con la base de datos.</exception>
        /// <exception cref="InvalidOperationException">Se lanza cuando la categoría no puede eliminarse por restricciones de integridad referencial.</exception>
        Task EliminarAsync(int id);
    }
}