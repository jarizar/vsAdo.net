namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Empleado")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            Medico = new HashSet<Medico>();
            Permisos = new HashSet<Permisos>();
        }

        [Key]
        public int idEmpleado { get; set; }

        public int idTipoEmpleado { get; set; }

        [StringLength(50)]
        public string nombres { get; set; }

        [StringLength(20)]
        public string apPaterno { get; set; }

        [StringLength(20)]
        public string apMaterno { get; set; }

        [StringLength(8)]
        public string nroDocumento { get; set; }

        public bool? estado { get; set; }

        [StringLength(500)]
        public string imagen { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }

        [StringLength(50)]
        public string clave { get; set; }

        public virtual TipoEmpleado TipoEmpleado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
