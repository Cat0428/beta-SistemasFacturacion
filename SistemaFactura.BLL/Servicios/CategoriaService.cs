using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SistemaFactura.DAL.Repositories;

namespace SistemaFactura.BLL.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio relacionada con las categorías.
    /// </summary>
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;

        /// <summary>
        /// Constructor que inyecta el repositorio de categorías.
        /// </summary>
        /// <param name="categoriaRepository">Repositorio de categorías.</param>
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Obtiene todas las categorías registradas en la base de datos.
        /// </summary>
        /// <returns>Una lista de categorías.</returns>
        public async Task<IEnumerable<Categoria>> ObtenerTodosAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene una categoría específica por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la categoría.</param>
        /// <returns>La categoría encontrada o null si no existe.</returns>
        public async Task<Categoria> ObtenerPorIdAsync(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Crea una nueva categoría en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto de categoría a crear.</param>
        public async Task CrearAsync(Categoria categoria)
        {
            await _categoriaRepository.AddAsync(categoria);
        }

        /// <summary>
        /// Actualiza los datos de una categoría existente.
        /// </summary>
        /// <param name="categoria">Categoría con los datos actualizados.</param>
        public async Task ActualizarAsync(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
        }

        /// <summary>
        /// Elimina una categoría basada en su identificador.
        /// </summary>
        /// <param name="id">Identificador de la categoría a eliminar.</param>
        public async Task EliminarAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria != null)
                _categoriaRepository.Delete(categoria);
        }
    }
}
