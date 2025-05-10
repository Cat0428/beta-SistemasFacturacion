using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SistemaFactura.DAL.Repositories;

namespace SistemaFactura.BLL.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio relacionada con las monedas.
    /// </summary>
    public class MonedaService : IMonedaService
    {
        private readonly MonedaRepository _monedaRepository;

        /// <summary>
        /// Constructor que inyecta el repositorio de monedas.
        /// </summary>
        /// <param name="monedaRepository">Repositorio de monedas.</param>
        public MonedaService(MonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
        }

        /// <summary>
        /// Obtiene todas las monedas registradas en la base de datos.
        /// </summary>
        /// <returns>Una lista de monedas.</returns>
        public async Task<IEnumerable<Moneda>> GetAllAsync()
        {
            return await _monedaRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene una moneda específica por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la moneda.</param>
        /// <returns>La moneda encontrada o null si no existe.</returns>
        public async Task<Moneda> GetByIdAsync(int id)
        {
            return await _monedaRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Crea una nueva moneda en la base de datos.
        /// </summary>
        /// <param name="moneda">Objeto de moneda a crear.</param>
        public async Task CreateAsync(Moneda moneda)
        {
            await _monedaRepository.AddAsync(moneda);
        }

        /// <summary>
        /// Actualiza la información de una moneda existente.
        /// </summary>
        /// <param name="moneda">Moneda con los datos actualizados.</param>
        public async Task UpdateAsync(Moneda moneda)
        {
            await _monedaRepository.UpdateAsync(moneda);
        }

        /// <summary>
        /// Elimina una moneda de la base de datos basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador de la moneda a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var moneda = await _monedaRepository.GetByIdAsync(id);
            if (moneda != null)
               await _monedaRepository.DeleteAsync(moneda);
        }
    }
}
