using SistemaFactura.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Interfaces
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
