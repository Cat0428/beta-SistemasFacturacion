using SistemaFactura.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Interfaces
{
    public interface IPresupuestoService
    {
        Task<IEnumerable<Presupuesto>> GetAllAsync();
        Task<Presupuesto> GetByIdAsync(int id);
        Task CreateAsync(Presupuesto presupuesto);
        Task UpdateAsync(Presupuesto presupuesto);
        Task DeleteAsync(int id);
    }
}
