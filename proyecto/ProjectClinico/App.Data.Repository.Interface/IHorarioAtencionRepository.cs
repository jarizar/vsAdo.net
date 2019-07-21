using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;

namespace App.Data.Repository.Interface
{
    public interface IHorarioAtencionRepository:IGenericRepository<HorarioAtencion>
    {
        List<HorarioAtencionQuery> ListarHorario(int idEspecialidad, DateTime fechaBusqueda);
    }

   
}
