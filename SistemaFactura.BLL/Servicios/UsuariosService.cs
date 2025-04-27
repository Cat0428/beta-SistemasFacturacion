using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SistemaFactura.DAL.Repositories;

namespace SistemaFactura.BLL.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio relacionada con los usuarios.
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        /// <summary>
        /// Constructor que inyecta el repositorio de usuarios.
        /// </summary>
        /// <param name="usuarioRepository">Repositorio de usuarios.</param>
        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en la base de datos.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un usuario específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del usuario.</param>
        /// <returns>El usuario encontrado o null si no existe.</returns>
        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto de usuario a crear.</param>
        public async Task CrearAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="usuario">Usuario con los datos actualizados.</param>
        public async Task ActualizarAsync(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        /// <summary>
        /// Elimina un usuario de la base de datos basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        public async Task EliminarAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario != null)
                _usuarioRepository.Delete(usuario);
        }
    }
}
