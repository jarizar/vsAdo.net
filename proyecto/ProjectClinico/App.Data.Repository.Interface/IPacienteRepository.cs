﻿using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IPacienteRepository:IGenericRepository<Paciente>
    {
        Paciente BuscarDni(string dni);

        bool ActualizarPaciente(Paciente p);

        bool EliminarPaciente(Paciente p);

        List<Paciente> ListarPacientes();
    }
}
