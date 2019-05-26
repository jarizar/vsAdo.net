namespace App.Data.Entities.BaseMatricula
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Notas
    {
        [Key]
        public int NotaID { get; set; }

        public int AlumnoID { get; set; }

        public int CursoID { get; set; }

        public int Nota { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
