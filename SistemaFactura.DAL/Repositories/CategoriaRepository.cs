using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

    }
}
