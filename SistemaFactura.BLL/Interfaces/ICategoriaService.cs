using SistemaFactura.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task CreateAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
    }
}
