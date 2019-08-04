using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IDiagnosticoRepository:IGenericRepository<Diagnostico>
    {

        bool RegistrarDiagnostico(DiagnosticoQuery objDiagnostico);
    }
}
