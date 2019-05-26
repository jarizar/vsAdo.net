namespace App.Data.Entities.BaseMatricula
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Matricula")]
    public partial class Matricula
    {
        public int MatriculaID { get; set; }

        public DateTime Fecha { get; set; }

        public int GradoID { get; set; }

        public int SeccionID { get; set; }

        public int AlumnoID { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Grado Grado { get; set; }
    }
}
