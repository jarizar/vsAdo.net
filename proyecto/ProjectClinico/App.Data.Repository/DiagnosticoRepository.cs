using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queries;
using System.Data.Entity;
using System.Data.SqlClient;

namespace App.Data.Repository
{
    public class DiagnosticoRepository:GenericRepository<Diagnostico>,IDiagnosticoRepository
    {
        public DiagnosticoRepository(DbContext context) : base(context)
        {
            
           
        }

        public bool RegistrarDiagnostico(DiagnosticoQuery objDiagnostico)
        {
            var query = false;
           

            try
            {
                _context.Database.SqlQuery<DiagnosticoQuery>(
            "spRegistrarDiagnostico @prmIdPaciente , @prmObservacion",
            new SqlParameter("@prmIdEmpleado", objDiagnostico.idPaciente));
                new SqlParameter("@prmObservacion", objDiagnostico.observacion);
 ;
                query = true;
            }
            catch (System.Exception)
            {

                throw;
            }

            return query;

        }

    }
}
