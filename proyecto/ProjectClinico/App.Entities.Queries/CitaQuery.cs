using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
   public class CitaQuery
    {

        public int idCita { get; set; }
        public int idMedico { get; set; }
        public int idPaciente { get; set; }
        public DateTime fechaReserva { get; set; }
        public string hora { get; set; }
        public string nombres { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public string nroDocumento { get; set; }
        public string direccion { get; set; }
    }
}
