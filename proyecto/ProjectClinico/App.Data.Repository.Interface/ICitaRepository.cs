using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface ICitaRepository : IGenericRepository<Cita>
    {
        bool ActualizarCita(Cita dato);

        List<CitaQuery> ListarCita();

        PacienteQuery BuscarPacienteIdCita(int idcita);
    }

    
}
