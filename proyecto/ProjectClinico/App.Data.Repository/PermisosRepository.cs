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
   public class PermisosRepository:GenericRepository<Permisos>,IPermisosRepository
    {
        public PermisosRepository(DbContext context) : base(context)
        {

        }
    }
}
