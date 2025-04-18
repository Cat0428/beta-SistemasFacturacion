using SistemaFactura.DAL.Context;
using SistemaFactura.DAL.Entities;

namespace SistemaFactura.DAL.Repositories
{
    public class PresupuestoRepository : GenericRepository<Presupuesto>
    {
        public PresupuestoRepository(AppDbContext context) : base(context)
        {
        }

        // Métodos específicos para Presupuesto
    }
}
