﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MD_MVCEntities : DbContext
    {
        public MD_MVCEntities()
            : base("name=MD_MVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<Condiciones> Condiciones { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Orden_Detalle> Orden_Detalle { get; set; }
        public virtual DbSet<Orden_Tipo> Orden_Tipo { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Persona_Tipo> Persona_Tipo { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Producto_Tipo> Producto_Tipo { get; set; }
        public virtual DbSet<Tasa_Impuesto> Tasa_Impuesto { get; set; }
        public virtual DbSet<v_Orden> v_Orden { get; set; }
        public virtual DbSet<v_Orden_Completa> v_Orden_Completa { get; set; }
        public virtual DbSet<v_Persona> v_Persona { get; set; }
        public virtual DbSet<v_Producto> v_Producto { get; set; }
    }
}
