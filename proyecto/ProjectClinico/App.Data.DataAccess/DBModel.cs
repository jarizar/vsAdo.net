namespace App.Data.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using App.Entities.Base;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=cnxDBModel")
        {
            //Deshabilitando el carga pesada
            this.Configuration.LazyLoadingEnabled = false;

            this.Configuration.ProxyCreationEnabled = false;

            this.Configuration.AutoDetectChangesEnabled = false;

            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<DiaSemana> DiaSemana { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<HistoriaClinica> HistoriaClinica { get; set; }
        public virtual DbSet<Hora> Hora { get; set; }
        public virtual DbSet<HorarioAtencion> HorarioAtencion { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<Cita>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cita>()
                .Property(e => e.hora)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<DiaSemana>()
                .Property(e => e.nombreDiaSemana)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Medico)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.Medico)
                .WithRequired(e => e.Especialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HistoriaClinica>()
                .HasMany(e => e.Diagnostico)
                .WithRequired(e => e.HistoriaClinica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hora>()
                .Property(e => e.hora1)
                .IsUnicode(false);

            modelBuilder.Entity<Hora>()
                .HasMany(e => e.HorarioAtencion)
                .WithRequired(e => e.Hora)
                .HasForeignKey(e => e.idHoraInicio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.HorarioAtencion)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.apPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.apMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.nroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoEmpleado>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoEmpleado>()
                .HasMany(e => e.Empleado)
                .WithRequired(e => e.TipoEmpleado)
                .WillCascadeOnDelete(false);
        }
    }
}
