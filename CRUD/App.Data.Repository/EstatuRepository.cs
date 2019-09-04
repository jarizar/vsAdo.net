using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class EstatuRepository : GenericRepository<Estatu>,IEstatuRepository
    {
        

        public EstatuRepository(DbContext context):base(context)
        {
           
        }
    }
}