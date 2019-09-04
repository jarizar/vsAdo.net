using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class Detalle_OrdenRepository : GenericRepository<Detalle_Orden>, IDetalle_OrdenRepository
    {
        public Detalle_OrdenRepository(DbContext context):base(context)
        {
          
        }
    }
}