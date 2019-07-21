using App.Data.DataAccess;
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
    public class EmpleadoRepository:GenericRepository<Empleado>,IEmpleadoRepository
    {

        public EmpleadoRepository(DbContext context) : base(context)
        {

        }

        public Empleado LoginEmpleado(string usuario, string clave)
        {
            var query = new Empleado();
           
            using (var db = new DBModel())
            {
                query = (db.Empleado.Where(c => c.usuario == usuario).Where(a=>a.clave==clave).FirstOrDefault());
            }

            return query;
                  
        }

    }
}
