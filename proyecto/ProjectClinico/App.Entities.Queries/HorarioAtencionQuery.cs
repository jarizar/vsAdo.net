using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class HorarioAtencionQuery
    {
        public int idHorarioAtencion { get; set; }
        public DateTime fecha { get; set; }
        public int idMedico { get; set; }
        public string nombres { get; set; }
        public int idHora { get; set; }
        public string hora { get; set; }
    }
}
