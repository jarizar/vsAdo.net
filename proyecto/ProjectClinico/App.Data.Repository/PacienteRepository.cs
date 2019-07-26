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

        public bool ActualizarPaciente(Paciente dato)
        {
            var result = false;

            using (var db = new DBModel())
            {
                db.Paciente.Attach(dato);
                db.Entry(dato).Property(x => x.direccion).IsModified = true;   
                db.SaveChanges();
                result = true;
            }
            
            return result;
        }

        public bool EliminarPaciente(Paciente dato)
        {
            var result = false;

            using (var db = new DBModel())
            {
                db.Paciente.Attach(dato);
                db.Entry(dato).Property(x => x.estado).IsModified = true;
                db.SaveChanges();
                result = true;
            }

            return result;
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

        public List<Paciente> ListarPacientes()
        {
            List<Paciente> lista=null;

            using (var db = new DBModel())
            {
                lista = db.Paciente.Where(x => x.estado == true).ToList();
            }
            return lista;

            }
    }
}
