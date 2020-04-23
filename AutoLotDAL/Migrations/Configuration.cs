namespace AutoLotDAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    using AutoLotDAL.Models;
    using AutoLotDAL.EF;
    
    
    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Seeding the Database
        protected override void Seed(AutoLotEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            #region Add Customers To AutoLot
            // ------------------------ Add Customers To AutoLot -------------------------
            var customers = new List<Customer>()
            {
            new Customer {FirstName = "Dave", LastName = "Brenner"},
            new Customer {FirstName = "Matt", LastName = "Walton"},
            new Customer {FirstName = "Steve", LastName = "Hagen"},
            new Customer {FirstName = "Pat", LastName = "Walton"},
            new Customer {FirstName = "Bad", LastName = "Customer"},
            };

            // any of the next two statements add customers to db
            context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, customers.ToArray());
            //customers.ForEach(cust => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName}, cust));

            // -------------------------------------------------------------------------
            #endregion

            #region Add Cars To AutoLot
            // ------------------------ Add Cars To AutoLot -------------------------

            var cars = new List<Inventory>()
            {
            new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
            new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
            new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
            new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
            new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
            new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
            new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
            new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
            new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
            };
            // any of the next two statements add cars to db
            context.Inventory.AddOrUpdate(c => new { c.Color, c.Make }, cars.ToArray());
            //cars.ForEach(car => context.Inventory.AddOrUpdate(c => new { c.Color, c.Make }, car));
            #endregion

            #region Add Orders To AutoLot
            // ------------------------ Add Orders To AutoLot -------------------------

            var orders = new List<Order>
            {
            new Order {Inventory= cars[0], Customer = customers[0]},
            new Order {Inventory= cars[1], Customer = customers[1]},
            new Order {Inventory= cars[2], Customer = customers[2]},
            new Order {Inventory= cars[3], Customer = customers[3]},
            };


            // any of the next two statements add orders to db
            //context.Orders.AddOrUpdate(order => new { order.CarId, order.CustId }, orders.ToArray());
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarId, c.CustId }, x));

            #endregion

            #region Add CreditRisk To AutoLot
            // ------------------------ Add CreditRisk To AutoLot -------------------------

            var creditRisk1 = new CreditRisk()
            {
                Id = customers[4].Id,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName,
            };

            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName }, creditRisk1);

            #endregion

        }
    }
}
