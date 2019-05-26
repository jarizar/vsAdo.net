namespace App.Data.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModelo : DbContext
    {
        public DBModelo()
            : base("name=DBModelo")
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.Sexo)
                .IsFixedLength();

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Notas)
                .WithRequired(e => e.Alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Notas)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grado>()
                .HasMany(e => e.Curso)
                .WithRequired(e => e.Grado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grado>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Grado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grado>()
                .HasMany(e => e.Seccion)
                .WithRequired(e => e.Grado)
                .WillCascadeOnDelete(false);
        }
    }
}
