using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitOfWork:IDisposable
    {
        IEmpleadoRepository EmpleadoRepository { get; set; }
        ICitaRepository CitaRepository { get; set; }
        IDiagnosticoRepository DiagnosticoRepository { get; set; }
        IDiaSemanaRepository DiaSemanaRepository { get; set; }
        IEspecialidadRespository EspecialidadRespository { get; set; }
        IHistoriaClinicaRepository HistoriaClinicaRepository { get; set; }
        IHoraRepository HoraRepository { get; set; }
        IHorarioAtencionRepository HorarioAtencionRepository { get; set; }
        IMedicoRepository MedicoRepository { get; set; }
        IMenuRepository MenuRepository { get; set; }
        IPacienteRepository PacienteRepository { get; set; }
        IPermisosRepository PermisosRepository { get; set; }
        ITipoEmpleadoRepository TipoEmpleadoRepository { get; set; }

        int Complete();

    }
}
