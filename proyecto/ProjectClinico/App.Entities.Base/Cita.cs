namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Cita")]
    public partial class Cita
    {
        [Key]
        public int idCita { get; set; }

        public int idMedico { get; set; }

        public int idPaciente { get; set; }

        public DateTime? fechaReserva { get; set; }

        [StringLength(350)]
        public string observacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(6)]
        public string hora { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
