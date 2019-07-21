namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            Permisos = new HashSet<Permisos>();
        }

        [Key]
        public int idMenu { get; set; }

        [Required]
        [StringLength(200)]
        public string nombre { get; set; }

        public bool isSubmenu { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        public int? idMenuParent { get; set; }

        public bool? estado { get; set; }

        public bool? show { get; set; }

        public int? orden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
