using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Migrations;

using AutoLotDAL.Models;

namespace AutoLotDAL.EF
{

    // the data initializer drops and re-creates the database
    public class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            //base.Seed(context);

            // add Customers
            // ------------------------------------------------------------
            var customers = new List<Customer>()
            {
            new Customer {FirstName = "Dave", LastName = "Brenner"},
            new Customer {FirstName = "Matt", LastName = "Walton"},
            new Customer {FirstName = "Steve", LastName = "Hagen"},
            new Customer {FirstName = "Pat", LastName = "Walton"},
            new Customer {FirstName = "Bad", LastName = "Customer"},
            };

            // any of the next two statements add customers to db
            context.Customers.AddOrUpdate( c => new { c.FirstName, c.LastName }, customers.ToArray());
            //customers.ForEach(cust => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName}, cust));




            // add Cars
            // ------------------------------------------------------------

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


            // add Orders
            // ------------------------------------------------------------

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




            // add CreditRisk
            // ------------------------------------------------------------

            var creditRisk1 = new CreditRisk()
            {
                Id = customers[4].Id,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName,
            };

            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName }, creditRisk1);



        }

        public override void InitializeDatabase(AutoLotEntities context)
        {
            base.InitializeDatabase(context);
        }
    }
}
