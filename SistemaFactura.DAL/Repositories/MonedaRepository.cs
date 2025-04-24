using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Repositories
{
    public class MonedaRepository : GenericRepository<Moneda>
    {
        public MonedaRepository(AppDbContext context) : base(context)
        {
        }

  
    }
}
