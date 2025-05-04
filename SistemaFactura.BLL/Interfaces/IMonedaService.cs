using SistemaFactura.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Interfaces
{
    public interface IMonedaService
    {
        Task<IEnumerable<Moneda>> GetAllAsync();
        Task<Moneda> GetByIdAsync(int id);
        Task CreateAsync(Moneda moneda);
        Task UpdateAsync(Moneda moneda);
        Task DeleteAsync(int id);
    }
}
