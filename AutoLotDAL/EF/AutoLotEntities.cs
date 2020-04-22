namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure.Interception;
    
    using AutoLotDAL.Interception;
    using AutoLotDAL.Models;


    public partial class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            Database.SetInitializer(new MyDataInitializer());

            DbInterception.Add(new ConsoleWriterInterceptor());


        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasMany(p => p.Orders)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(p => p.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);
        }
    }
}
