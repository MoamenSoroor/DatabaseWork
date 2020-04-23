namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL.Interception;
    using AutoLotDAL.Models;


    public partial class AutoLotEntities : DbContext
    {
        
        //public static readonly DatabaseLogger DbLogger = 
        //    new DatabaseLogger("AutoLotDbLogs.txt", true);
        
        
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            //Database.SetInitializer(new MyDataInitializer());



            //DbInterception.Add(new ConsoleWriterInterceptor());

            //DbLogger.StartLogging();
            //DbInterception.Add(DbLogger);


            //Interceptor code
            //var context = (this as IObjectContextAdapter).ObjectContext;
            //context.ObjectMaterialized += OnObjectMaterialized;
            //context.SavingChanges += OnSavingChanges;


        }

        private void OnSavingChanges(object sender, EventArgs e)
        {
            //Console.WriteLine("OnSavingChanges");
        }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            //Console.WriteLine("OnObjectMaterialized");
            
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Radio> Radios { get; set; }

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

        protected override void Dispose(bool disposing)
        {
            //DbLogger.StopLogging();
            //DbInterception.Remove(DbLogger);
            base.Dispose(disposing);
        }
    }
}
