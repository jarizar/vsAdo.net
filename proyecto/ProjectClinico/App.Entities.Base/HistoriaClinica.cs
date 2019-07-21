namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("HistoriaClinica")]
    public partial class HistoriaClinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HistoriaClinica()
        {
            Diagnostico = new HashSet<Diagnostico>();
        }

        [Key]
        public int idHistoriaClinica { get; set; }

        public int? idPaciente { get; set; }

        public DateTime? fechaApertura { get; set; }

        public bool? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnostico> Diagnostico { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
