﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace alytalomob.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlyTaloEntities : DbContext
    {
        public AlyTaloEntities()
            : base("name=AlyTaloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HuoneLampo> HuoneLampo { get; set; }
        public virtual DbSet<HuoneLampotila> HuoneLampotila { get; set; }
        public virtual DbSet<Sauna> Sauna { get; set; }
        public virtual DbSet<Valot> Valot { get; set; }
    }
}