namespace App.Data.Entities.BaseMatricula
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Seccion")]
    public partial class Seccion
    {
        public int SeccionID { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre { get; set; }

        public int GradoID { get; set; }

        public virtual Grado Grado { get; set; }
    }
}
