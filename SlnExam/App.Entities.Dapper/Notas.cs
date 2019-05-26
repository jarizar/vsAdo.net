using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Dapper
{
   public class Notas
    {
        public int NotaID { get; set; }
        public int AlumnoID { get; set; }
        public int CursoID { get; set; }
        public int Nota { get; set; }

        public Alumno alumno { get; set; }
    }
}
