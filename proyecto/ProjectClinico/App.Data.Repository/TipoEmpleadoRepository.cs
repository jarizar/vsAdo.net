using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class TipoEmpleadoRepository:GenericRepository<TipoEmpleado>,ITipoEmpleadoRepository
    {
        public TipoEmpleadoRepository(DbContext context) : base(context)
        {

        }
    }
}
