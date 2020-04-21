using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Models;

//using AutoLotConsoleApp.Models;


namespace AutoLotDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with ADO.NET EF *****\n");
            
            //var car = new Car() { Make = "Honda", Color = "Brown", CarNickName = "MyHonda" };
            //var car2 = new Car() { Make = "BMW", Color = "Red", CarNickName = "MyReddy" };
            //int carId = AddNewCar(car);
            //Console.WriteLine(carId);

            //AddNewCars(new[] { car, car2 });


            PrintAllInventory();

            //PrintCars(1, 2, 3);
            //
            //
            //PrintCars(1008);

            //PrintWithLINQ();
            PrintWithLINQ2();
            





            // End
            Console.WriteLine();
            Console.WriteLine("Press any Key to Continue.");
            Console.ReadLine();
        }


        private static int AddNewCar(Car car)
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {

                    context.Cars.Add(car);

                    context.SaveChanges();

                    // On a successful save, EF populates the database generated identity field.
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }

        private static void AddNewCars(IEnumerable<Car> carsToAdd)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.AddRange(carsToAdd);
                context.SaveChanges();
            }
        }

        private static void PrintAllInventory()
        {
            Console.WriteLine($"-------------- All Cars ------------------");
            using (var context = new AutoLotEntities())
            {
                foreach (var item in context.Cars)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"------------------------------------------");
        }

        private static void PrintCars(string make)
        {
            using (var context = new AutoLotEntities())
            {

                Console.WriteLine($"-------------- Cars With Make={make} ------------------");
                foreach (var item in context.Cars.Where(c => c.Make == make))
                {
                    Console.WriteLine(item);
                }

            }
        }

        private static void PrintCars(string make, string color)
        {
            using (var context = new AutoLotEntities())
            {

                Console.WriteLine($"-------------- Cars With Make={make} And Color={color} ------------------");
                foreach (var item in context.Cars.Where(c => c.Make == make && c.Color == color))
                {
                    Console.WriteLine(item);
                }

            }
        }


        private static void PrintCars(params int[] keys)
        {
            Console.WriteLine($"-------------- Cars With Keys {string.Join(", ", keys)} ------------------");

            using (var context = new AutoLotEntities())
            {
                foreach (var item in context.Cars.Where(c => keys.Contains(c.CarId)))
                {
                    Console.WriteLine(item);

                }

            }

            Console.WriteLine($"------------------------------------------");
        }

        private static void PrintCar(int key)
        {
            Console.WriteLine($"-------------- Cars With Key = {key} ------------------");

            using (var context = new AutoLotEntities())
            {
                Console.WriteLine(context.Cars.Find(key));

            }

            Console.WriteLine($"------------------------------------------");
        }


        private static void PrintWithLINQ()
        {
            using (var context = new AutoLotEntities())
            {

                Console.WriteLine($"-------------- Cars Using LINQ ------------------");

                var query = from car in context.Cars
                            where car.CarId == 1 || car.CarId == 2
                            select car;

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

            }
        }


        private static void PrintWithLINQ2()
        {
            using (var context = new AutoLotEntities())
            {

                Console.WriteLine($"-------------- Cars Using LINQ ------------------");

                // Get a projection of new data.
                var shortCars = from car in context.Cars select new { car.CarNickName, car.Color };

                foreach (var item in shortCars)
                {
                    Console.WriteLine($"Anonymous Type: Name={item.CarNickName},\t Color={item.Color}");
                }

            }
        }


        // Chaining Linq Queries
        private static void ChainingLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                //Not executed
                DbSet<Car> allData = context.Cars;
                //Not Executed.
                var colorsMakes = from item in allData select new { item.Color, item.Make };
                //Now it's executed
                foreach (var item in colorsMakes)
                {
                    Console.WriteLine(item);
                }
            }
        }


        private static void PrintAllInventoryNonTrackableCode()
        {
            using (var context = new AutoLotEntities())
            {
                string sql = @"SELECT  CarId,Make,Color,PetName as CarNickName FROM Inventory";
                Console.WriteLine($"-------------- All Cars in Inventory ------------------");
                foreach (var item in context.Cars.SqlQuery(sql))
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void PrintCarsWithMakeNonTrackableCode(string make)
        {
            using (var context = new AutoLotEntities())
            {
                string sql =
                    @"SELECT CarId, Make, Color, PetName AS CarNickName
                      FROM Inventory 
                      WHERE Make= @P0
                     ";
                Console.WriteLine($"-------------- Cars With Make={make} ------------------");
                foreach (var item in context.Cars.SqlQuery(sql, make))
                {
                    Console.WriteLine(item);
                }

            }
        }


        #region The Role of Navigation Properties
        // ------------------------ The Role of Navigation Properties -------------------------
        // navigation properties allow you to find related data in other entities without having
        // to author complex JOIN queries.





        // -------------------------------------------------------------------------
        #endregion



    }



}
