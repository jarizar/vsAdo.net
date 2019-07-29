using App.Data.DataAccess;
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
    public class CitaRepository:GenericRepository<Cita>,ICitaRepository
    {
        public CitaRepository(DbContext context) : base(context)
        {

        }

        public bool ActualizarCita(Cita dato)
        {
            var result = false;

            using (var db = new DBModel())
            {
                db.Cita.Attach(dato);
                db.Entry(dato).Property(x => x.estado).IsModified = true;
                db.SaveChanges();
                result = true;
            }

            return result;
        }

    }
}
