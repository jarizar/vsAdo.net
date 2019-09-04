using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class ClienteRepository : GenericRepository<Cliente>,IClienteRepository
    {
      
        public ClienteRepository(DbContext context):base(context)
        {
            
        }
    }
}