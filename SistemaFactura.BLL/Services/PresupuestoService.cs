using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SistemaFactura.DAL.Repositories;

namespace SistemaFactura.BLL.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio relacionada con los presupuestos.
    /// </summary>
    public class PresupuestoService : IPresupuestoService
    {
        private readonly PresupuestoRepository _presupuestoRepository;

        /// <summary>
        /// Constructor que inyecta el repositorio de presupuestos.
        /// </summary>
        /// <param name="presupuestoRepository">Repositorio de presupuestos.</param>
        public PresupuestoService(PresupuestoRepository presupuestoRepository)
        {
            _presupuestoRepository = presupuestoRepository;
        }

        /// <summary>
        /// Obtiene todos los presupuestos registrados en la base de datos.
        /// </summary>
        /// <returns>Una lista de presupuestos.</returns>
        public async Task<IEnumerable<Presupuesto>> GetAllAsync()
        {
            return await _presupuestoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un presupuesto específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del presupuesto.</param>
        /// <returns>El presupuesto encontrado o null si no existe.</returns>
        public async Task<Presupuesto> GetByIdAsync(int id)
        {
            return await _presupuestoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Crea un nuevo presupuesto en la base de datos.
        /// </summary>
        /// <param name="presupuesto">Objeto de presupuesto a crear.</param>
        public async Task CreateAsync(Presupuesto presupuesto)
        {
            await _presupuestoRepository.AddAsync(presupuesto);
        }

        /// <summary>
        /// Actualiza la información de un presupuesto existente.
        /// </summary>
        /// <param name="presupuesto">Presupuesto con los datos actualizados.</param>
        public async Task UpdateAsync(Presupuesto presupuesto)
        {
           await _presupuestoRepository.UpdateAsync(presupuesto);
        }

        /// <summary>
        /// Elimina un presupuesto de la base de datos basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador del presupuesto a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var presupuesto = await _presupuestoRepository.GetByIdAsync(id);
            if (presupuesto != null)
              await  _presupuestoRepository.DeleteAsync(presupuesto);
        }
    }
}
