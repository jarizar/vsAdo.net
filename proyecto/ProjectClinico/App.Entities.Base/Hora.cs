namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Hora")]
    public partial class Hora
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hora()
        {
            HorarioAtencion = new HashSet<HorarioAtencion>();
        }

        [Key]
        public int idHora { get; set; }

        [Column("hora")]
        [StringLength(6)]
        public string hora1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencion> HorarioAtencion { get; set; }
    }
}
