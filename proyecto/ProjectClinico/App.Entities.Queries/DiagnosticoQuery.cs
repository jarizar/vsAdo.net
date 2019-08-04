using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class DiagnosticoQuery
    {

        public int idDiagnostico { get; set; }
        public int idHistoriaClinica { get; set; }
        public DateTime fechaEmision { get; set; }
        public string observacion { get; set; }
        public bool estado { get; set; }
        public int idPaciente { get; set; }
        public DateTime fechaApertura { get; set; }
    }
}
