using App.Data.DataAccess;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class PacienteRepository:GenericRepository<Paciente>,IPacienteRepository
    {
        public PacienteRepository(DbContext context) : base(context)
        {

        }

        public Paciente BuscarDni(string dni)
        {
            var query = new Paciente();

            using (var db = new DBModel())
            {
                query = (db.Paciente.Where(c => c.nroDocumento == dni).FirstOrDefault());
            }

            return query;
        }
    }
}
