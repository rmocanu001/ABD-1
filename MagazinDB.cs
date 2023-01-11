using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MagazinElectronic
{
    public partial class MagazinDB : DbContext
    {
        public MagazinDB()
            : base("name=MagazinDB")
        {
        }

        public virtual DbSet<CategorieProduse> CategorieProduses { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Produse> Produses { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Inventar> Inventars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorieProduse>()
                .HasMany(e => e.Produses)
                .WithRequired(e => e.CategorieProduse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Costumer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Costumer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Produse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.Inventars)
                .WithRequired(e => e.Produse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.Bill_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inventar>()
                .Property(e => e.PretUnitar)
                .HasPrecision(19, 4);
        }
    }
}
