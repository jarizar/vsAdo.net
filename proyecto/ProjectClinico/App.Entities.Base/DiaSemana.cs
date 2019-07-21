namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("DiaSemana")]
    public partial class DiaSemana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaSemana()
        {
            HorarioAtencion = new HashSet<HorarioAtencion>();
        }

        [Key]
        public int idDiaSemana { get; set; }

        [StringLength(50)]
        public string nombreDiaSemana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencion> HorarioAtencion { get; set; }
    }
}
