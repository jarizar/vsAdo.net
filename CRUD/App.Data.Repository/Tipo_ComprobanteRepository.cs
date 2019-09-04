using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class Tipo_ComprobanteRepository : GenericRepository<Tipo_Comprobante>, ITipo_ComprobanteRepository
    {
      
        public Tipo_ComprobanteRepository(DbContext context):base(context)
        {
            
        }
    }
}