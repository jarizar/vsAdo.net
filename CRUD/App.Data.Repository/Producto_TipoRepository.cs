using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class Producto_TipoRepository : GenericRepository<Producto_Tipo>, IProducto_TipoRepository
    {
        
        public Producto_TipoRepository(DbContext context):base(context)
        {
           
        }
    }
}