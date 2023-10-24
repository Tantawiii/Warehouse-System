using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityLinQProject
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=SherkaTogerya")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public virtual DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrders> SalesOrders { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TransferDetails> TransferDetails { get; set; }
        public virtual DbSet<Transfers> Transfers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stores>()
                .HasMany(e => e.Transfers)
                .WithOptional(e => e.Stores)
                .HasForeignKey(e => e.FromStoreID);

            modelBuilder.Entity<Stores>()
                .HasMany(e => e.Transfers1)
                .WithOptional(e => e.Stores1)
                .HasForeignKey(e => e.ToStoreID);
        }
    }
}
