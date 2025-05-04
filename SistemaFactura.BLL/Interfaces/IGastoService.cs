using SistemaFactura.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Interfaces
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> GetAllAsync();
        Task<Gasto> GetByIdAsync(int id);
        Task CreateAsync(Gasto gasto);
        Task UpdateAsync(Gasto gasto);
        Task DeleteAsync(int id);
    }
}
