using App.Entities.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Alumno
    {
        public int AlumnoID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Sexo  { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public List<Notas> notas { get; set; }
    }
}
