using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL.BulkImport;
using AutoLotDAL.Models;
using AutoLotDAL.DataOperations;

namespace AutoLotDAL
{
    class Program
    {

        public static void Main(string[] args)
        {
            TestBulkCopyWithCustomDataReader();


        }


        #region Executing Bulk Copies with ADO.NET
        // ------------------------ Executing Bulk Copies with ADO.NET -------------------------
        // In cases where you need to load lots of records into the database, the methods shown so far would be rather
        // inefficient.SQL Server has a feature called bulk copy that is designed specifically for this scenario, and it’s wrapped
        // up in ADO.NET with the SqlBulkCopy class. 

        public static void TestBulkCopyWithCustomDataReader()
        {
            Console.WriteLine(" ************** Do Bulk Copy ************** ");
            var cars = new List<Car>
            {
            new Car() {Color = "Blue", Make = "Honda", PetName = "MyCar1"},
            new Car() {Color = "Red", Make = "Volvo", PetName = "MyCar2"},
            new Car() {Color = "White", Make = "VW", PetName = "MyCar3"},
            new Car() {Color = "Yellow", Make = "Toyota", PetName = "MyCar4"}
            };
            ProcessBulkImport.ExecuteBulkImport(cars, "Inventory");
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            Console.WriteLine(" ************** All Cars ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (var itm in list)
            {
                Console.WriteLine($"{itm.CarId}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
            }
            Console.WriteLine();
        }



        // -------------------------------------------------------------------------
        #endregion
    }
}
