﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazinElectronic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Magazin_ElectroniceEntities : DbContext
    {
        public Magazin_ElectroniceEntities()
            : base("name=Magazin_ElectroniceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategorieProduse> CategorieProduse { get; set; }
        public virtual DbSet<Costumer> Costumer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Produse> Produse { get; set; }
        public virtual DbSet<sysdiagram> sysdiagram { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Inventar> Inventar { get; set; }
    }
}
