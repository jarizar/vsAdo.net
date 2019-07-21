using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class EmpleadoQuery
    {

        public int idEmpleado { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string clave { get; set; }
        public string nombres { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string nroDocumento { get; set; }
        public byte estado { get; set; }

       
    }
}
