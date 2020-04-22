using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;


namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllInventory();

            TestConcurrency();

            GetAllInventory();


        }

        public static void GetAllInventory()
        {
            Console.WriteLine("***** Using a Repository *****\n");
            using (var repo = new InventoryRepo())
            {
                foreach (Inventory c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }
        }

        public static void AddNewRecord(Inventory inventory)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(inventory);
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                // Grab the car, change it, save!
                var carToUpdate = repo.GetOne(carId);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Blue";
                repo.Save(carToUpdate);
            }
        }


        private static void RemoveRecordByCar(Inventory carToDelete)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carToDelete);
            }
        }
        private static void RemoveRecordById(int carId, byte[] timeStamp)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carId, timeStamp);
            }
        }


        private static void TestConcurrency()
        {
            InventoryRepo repo = new InventoryRepo(); 
            InventoryRepo repo2 = new InventoryRepo();

            Inventory car1 = repo.GetOne(1);
            Inventory car2 = repo2.GetOne(1);

            car1.PetName = "Zippy";
            repo.Save(car1);

            try
            {
                car2.PetName = "Other Name";
                repo2.Save(car2);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var currentValues = entry.CurrentValues;
                var originalValues = entry.OriginalValues;
                var dbValues = entry.GetDatabaseValues();
                Console.WriteLine(" ******** Concurrency ************");
                Console.WriteLine("Type\tPetName");
                Console.WriteLine($"Current:\t{currentValues[nameof(Inventory.PetName)]}");
                Console.WriteLine($"Orig:\t{originalValues[nameof(Inventory.PetName)]}");
                Console.WriteLine($"db:\t{dbValues[nameof(Inventory.PetName)]}");
            }

            finally
            {
                repo.Dispose();
                repo2.Dispose();
            }

        }

    }
}
