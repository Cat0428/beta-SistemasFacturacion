using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SistemaFactura.DAL.Repositories;

namespace SistemaFactura.BLL.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio relacionada con los gastos.
    /// </summary>
    public class GastoService : IGastoService
    {
        private readonly GastoRepository _gastoRepository;

        /// <summary>
        /// Constructor que inyecta el repositorio de gastos.
        /// </summary>
        /// <param name="gastoRepository">Repositorio de gastos.</param>
        public GastoService(GastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }

        /// <summary>
        /// Obtiene todos los gastos registrados en la base de datos.
        /// </summary>
        /// <returns>Una lista de gastos.</returns>
        public async Task<IEnumerable<Gasto>> GetAllAsync()
        {
            return await _gastoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un gasto específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del gasto.</param>
        /// <returns>El gasto encontrado o null si no existe.</returns>
        public async Task<Gasto> GetByIdAsync(int id)
        {
            return await _gastoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Obtiene todos los gastos asociados a un usuario específico.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario.</param>
        /// <returns>Lista de gastos del usuario.</returns>
        public async Task<IEnumerable<Gasto>> GetByConditionAsync(int usuarioId)
        {
            return await _gastoRepository.GetByConditionAsync(g => g.UsuarioId == usuarioId);
        }

        /// <summary>
        /// Crea un nuevo gasto en la base de datos.
        /// </summary>
        /// <param name="gasto">Objeto de gasto a crear.</param>
        public async Task CreateAsync(Gasto gasto)
        {
            await _gastoRepository.AddAsync(gasto);
        }

        /// <summary>
        /// Actualiza la información de un gasto existente.
        /// </summary>
        /// <param name="gasto">Gasto con los datos actualizados.</param>
        public async Task UpdateAsync(Gasto gasto)
        {
            _gastoRepository.UpdateAsync(gasto);
        }

        /// <summary>
        /// Elimina un gasto de la base de datos basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador del gasto a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var gasto = await _gastoRepository.GetByIdAsync(id);
            if (gasto != null)
                _gastoRepository.DeleteAsync(gasto);
        }
    }
}
