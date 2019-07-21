using App.Data.DataAccess;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork:IAppUnitOfWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork()
        {

            _context = new DBModel();
            this.EmpleadoRepository = new EmpleadoRepository(_context);
            this.CitaRepository = new CitaRepository(_context);
            this.DiagnosticoRepository = new DiagnosticoRepository(_context);
            this.DiaSemanaRepository = new DiaSemanaRepository(_context);
            this.EspecialidadRespository=new EspecialidadRespository(_context);
            this.HistoriaClinicaRepository = new HistoriaClinicaRepository(_context);
            this.HoraRepository=new HoraRepository(_context);
            this.HorarioAtencionRepository = new HorarioAtencionRepository(_context);
            this.MedicoRepository = new MedicoRepository(_context);
            this.MenuRepository = new MenuRepository(_context);
            this.PacienteRepository = new PacienteRepository(_context);
            this.PermisosRepository = new PermisosRepository(_context);
            this.TipoEmpleadoRepository = new TipoEmpleadoRepository(_context);
    }

        public IEmpleadoRepository EmpleadoRepository { get; set; }
        public ICitaRepository CitaRepository { get; set;}
        public IDiagnosticoRepository DiagnosticoRepository { get; set;}
        public IDiaSemanaRepository DiaSemanaRepository { get; set;}
        public IEspecialidadRespository EspecialidadRespository { get; set;}
        public IHistoriaClinicaRepository HistoriaClinicaRepository { get; set;}
        public IHoraRepository HoraRepository { get; set;}
        public IHorarioAtencionRepository HorarioAtencionRepository { get; set;}
        public IMedicoRepository MedicoRepository { get; set;}
        public IMenuRepository MenuRepository { get; set;}
        public IPacienteRepository PacienteRepository { get; set;}
        public IPermisosRepository PermisosRepository { get; set;}
        public ITipoEmpleadoRepository TipoEmpleadoRepository { get; set;}

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
