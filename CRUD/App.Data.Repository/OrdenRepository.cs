using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class OrdenRepository : GenericRepository<Orden>,IOrdenRepository
    {

        public OrdenRepository(DbContext context):base(context)
        {
            
        }
    }
}