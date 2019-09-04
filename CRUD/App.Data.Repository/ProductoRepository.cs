using System.Data.Entity;
using App.Data.Repository.Interface;
using App.Entities.Base;

namespace App.Data.Repository
{
    internal class ProductoRepository : GenericRepository<Producto>,IProductoRepository
    {
        
        public ProductoRepository(DbContext context):base(context)
        {
           
        }
    }
}