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
    public class MedicoRepository:GenericRepository<Medico>,IMedicoRepository
    {
        public MedicoRepository(DbContext context) : base(context)
        {

        }

        public MedicoQuery BuscarMedicoDni(string dni)
        {
            

            return _context.Database.SqlQuery<MedicoQuery>(
                "spBuscarMedico @prmDni",
                new SqlParameter("@prmDni", dni)
                ).FirstOrDefault();

            
        }
    }
}
