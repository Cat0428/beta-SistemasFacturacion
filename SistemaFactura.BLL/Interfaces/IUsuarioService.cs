using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<Usuario?> LoginAsync(string email, string password);

    }
}
