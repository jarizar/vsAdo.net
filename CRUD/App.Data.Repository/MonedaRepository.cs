using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class MonedaRepository : GenericRepository<Moneda>,IMonedaRepository
    {
        
        public MonedaRepository(DbContext context):base(context)
        {
   
        }
    }
}