using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }


    }
}
