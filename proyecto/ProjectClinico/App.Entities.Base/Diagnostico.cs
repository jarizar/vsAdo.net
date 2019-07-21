namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Diagnostico")]
    public partial class Diagnostico
    {
        [Key]
        public int idDiagnostico { get; set; }

        public int idHistoriaClinica { get; set; }

        public DateTime? fechaEmision { get; set; }

        [StringLength(500)]
        public string observacion { get; set; }

        public bool? estado { get; set; }

        public virtual HistoriaClinica HistoriaClinica { get; set; }
    }
}
