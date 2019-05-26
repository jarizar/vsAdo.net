namespace App.Data.Entities.BaseMatricula
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            Notas = new HashSet<Notas>();
        }

        public int CursoID { get; set; }

        public int GradoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public virtual Grado Grado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
