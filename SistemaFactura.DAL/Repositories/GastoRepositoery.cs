using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Repositories
{
    public class GastoRepository : GenericRepository<Gasto>
    {
        public GastoRepository(AppDbContext context) : base(context)
        {
        }

        // Métodos específicos para Gasto
    }
}
