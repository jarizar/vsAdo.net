namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("HorarioAtencion")]
    public partial class HorarioAtencion
    {
        [Key]
        public int idHorarioAtencion { get; set; }

        public int idMedico { get; set; }

        public int idHoraInicio { get; set; }

        public DateTime? fecha { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaFin { get; set; }

        public bool? estado { get; set; }

        public int? idDiaSemana { get; set; }

        public virtual DiaSemana DiaSemana { get; set; }

        public virtual Hora Hora { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
