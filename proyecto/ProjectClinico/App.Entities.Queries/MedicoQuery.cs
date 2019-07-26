using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class MedicoQuery
    {
        public int idMedico { get; set; }
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string nroDocumento { get; set; }
        public int idEspecialidad { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

    }
}
