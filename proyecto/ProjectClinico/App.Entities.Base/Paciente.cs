namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Cita = new HashSet<Cita>();
            HistoriaClinica = new HashSet<HistoriaClinica>();
        }

        [Key]
        public int idPaciente { get; set; }

        [StringLength(50)]
        public string nombres { get; set; }

        [StringLength(20)]
        public string apPaterno { get; set; }

        [StringLength(20)]
        public string apMaterno { get; set; }

        public int? edad { get; set; }

        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(8)]
        public string nroDocumento { get; set; }

        [StringLength(150)]
        public string direccion { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        public bool? estado { get; set; }

        [StringLength(500)]
        public string imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriaClinica> HistoriaClinica { get; set; }
    }
}
