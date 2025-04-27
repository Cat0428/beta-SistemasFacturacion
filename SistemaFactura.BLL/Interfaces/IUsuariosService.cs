using SistemaFactura.DAL.Entities;

namespace SistemaFactura.BLL.Interfaces
{
    /// <summary>
    /// Interfaz de servicio para la gestión de usuarios del sistema
    /// </summary>
    /// <remarks>
    /// Define las operaciones básicas CRUD para la entidad Usuario,
    /// incluyendo validaciones específicas para la gestión de usuarios.
    /// </remarks>
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema
        /// </summary>
        /// <returns>
        /// Colección enumerable de objetos Usuario
        /// </returns>
        /// <exception cref="DatabaseException">
        /// Se produce cuando ocurre un error al acceder a la base de datos
        /// </exception>
        /// <exception cref="SecurityException">
        /// Se produce cuando el usuario no tiene permisos para esta operación
        /// </exception>
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();

        /// <summary>
        /// Obtiene un usuario específico por su ID
        /// </summary>
        /// <param name="id">Identificador único del usuario (debe ser mayor que 0)</param>
        /// <returns>
        /// Objeto Usuario correspondiente al ID proporcionado
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el ID proporcionado es inválido
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se produce cuando no se encuentra un usuario con el ID especificado
        /// </exception>
        /// <exception cref="DatabaseException">
        /// Se produce cuando ocurre un error al acceder a la base de datos
        /// </exception>
        Task<Usuario> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Crea un nuevo usuario en el sistema
        /// </summary>
        /// <param name="usuario">Objeto Usuario con los datos del nuevo usuario</param>
        /// <returns>Tarea asíncrona que representa la operación</returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando el objeto usuario es nulo
        /// </exception>
        /// <exception cref="ValidationException">
        /// Se produce cuando los datos del usuario no pasan las validaciones:
        /// - Email debe tener formato válido
        /// - Password debe cumplir con política de seguridad
        /// - Nombre no puede estar vacío
        /// </exception>
        /// <exception cref="DuplicateEntityException">
        /// Se produce cuando ya existe un usuario con el mismo email
        /// </exception>
        /// <exception cref="DatabaseException">
        /// Se produce cuando ocurre un error al acceder a la base de datos
        /// </exception>
        Task CrearAsync(Usuario usuario);

        /// <summary>
        /// Actualiza los datos de un usuario existente
        /// </summary>
        /// <param name="usuario">Objeto Usuario con los datos actualizados</param>
        /// <returns>Tarea asíncrona que representa la operación</returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando el objeto usuario es nulo
        /// </exception>
        /// <exception cref="ValidationException">
        /// Se produce cuando los datos del usuario no pasan las validaciones
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se produce cuando no se encuentra el usuario a actualizar
        /// </exception>
        /// <exception cref="DatabaseException">
        /// Se produce cuando ocurre un error al acceder a la base de datos
        /// </exception>
        Task ActualizarAsync(Usuario usuario);

        /// <summary>
        /// Elimina un usuario del sistema por su ID
        /// </summary>
        /// <param name="id">Identificador único del usuario a eliminar</param>
        /// <returns>Tarea asíncrona que representa la operación</returns>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el ID proporcionado es inválido
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se produce cuando no se encuentra el usuario con el ID especificado
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Se produce cuando el usuario no puede eliminarse porque:
        /// - Es el último usuario administrador
        /// - Tiene registros asociados (historial, transacciones, etc.)
        /// </exception>
        /// <exception cref="DatabaseException">
        /// Se produce cuando ocurre un error al acceder a la base de datos
        /// </exception>
        Task EliminarAsync(int id);
    }
}