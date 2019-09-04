using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class Tipo_DocumentoRepository : GenericRepository<Tipo_Documento>, ITipo_DocumentoRepository
    {
        
        public Tipo_DocumentoRepository(DbContext context):base(context)
        {
           
        }
    }
}