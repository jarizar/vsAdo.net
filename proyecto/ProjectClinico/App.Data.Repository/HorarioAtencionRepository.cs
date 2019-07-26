using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace App.Data.Repository
{
    public class HorarioAtencionRepository:GenericRepository<HorarioAtencion>, IHorarioAtencionRepository
    {
        public HorarioAtencionRepository(DbContext context) : base(context)
        {

        }

        public List<HorarioAtencionQuery> AgregarHorario(int idMedico, string hora,DateTime Fecha)
        {
            
             return _context.Database.SqlQuery<HorarioAtencionQuery>(
            "spRegistrarHorarioAtencion @prmIdMedico,@prmHora,@prmFecha",
            new SqlParameter("@prmIdMedico", idMedico),
            new SqlParameter("@prmHora", hora),
              new SqlParameter("@prmFecha", Fecha)).ToList();

           

        }

        public List<HorarioAtencionQuery> ListarHorario(int idEspecialidad, DateTime fechaBusqueda)
        {
            return _context.Database.SqlQuery<HorarioAtencionQuery>(
             "spListarHorariosAtencionPorFecha @prmIdEspecialidad, @prmFecha",
             new SqlParameter("@prmIdEspecialidad", idEspecialidad),
             new SqlParameter("@prmFecha", fechaBusqueda)).ToList();
        }

        public List<HorarioAtencionQuery> ListarHorariosAtencion(string idmedico)
        {
            return _context.Database.SqlQuery<HorarioAtencionQuery>(
              "spListaHorariosAtencion @prmIdMedico",
              new SqlParameter("@prmIdMedico", idmedico)).ToList();
        }
    }
}
