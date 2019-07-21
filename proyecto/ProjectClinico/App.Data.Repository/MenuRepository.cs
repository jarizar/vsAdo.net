using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class MenuRepository : GenericRepository<Menu>,IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {

        }

        public List<MenuQuery> ListarMenu(int id)
        {
            return _context.Database.SqlQuery<MenuQuery>(
               "spMenuPorEmpleado @prmIdEmpleado",
               new SqlParameter("@prmIdEmpleado", id)).ToList();
        }
    }
}
