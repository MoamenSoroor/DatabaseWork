using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using static System.Environment;

using ADODotNet.Models;

namespace ADODotNet.DataOperations
{

    #region Working with Create, Update, and Delete Queries
    // ------------------------ Working with Create, Update, and Delete Queries -------------------------
    // However, when you want to submit
    // SQL statements that result in the modification of a given table(or any other nonquery SQL statement, such
    // as creating tables or granting permissions), you call the ExecuteNonQuery() method of your command
    // object. This single method performs inserts, updates, and deletes based on the format of your command text.

    //  ExecuteNonQuery()
    // returns an int that represents the number of rows affected, not a new set of records.

    public class InventoryDAL
    {
        public const string DefaultConnectionString =
            @"Data Source = localhost\SQLEXPRESS;
            Integrated Security=true;
            Initial Catalog=AutoLot";

        private readonly string connectionString;
        private SqlConnection connection = null;
        public InventoryDAL() : this(DefaultConnectionString)
        {

        }

        public InventoryDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public Car GetCar(int id)
        {
            OpenConnection();

            Car car = null;

            string sql = $"SELECT * FROM Inventory WHERE CarId = {id}";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        car = new Car
                        {
                            CarId = (int)reader["CarId"],
                            Color = (string)reader["Color"],
                            Make = (string)reader["Make"],
                            PetName = (string)reader["PetName"]
                        };
                    }
                }
            }

            return car;

        }


        public List<Car> GetAllInventory()
        {
            OpenConnection();

            List<Car> inventory = new List<Car>();

            string sql = $"SELECT * FROM Inventory";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        inventory.Add(new Car
                            {
                                CarId = (int)reader["CarId"],
                                Color = (string)reader["Color"],
                                Make = (string)reader["Make"],
                                PetName = (string)reader["PetName"]
                            }
                        );
                    }
                }
            }

            return inventory;

        }

        // ---------------<<< Note >>>-------------------
        // Note Building a SQL statement using string concatenation can be risky from a security point of view(think:
        // SQL injection attacks). The preferred way to build command text is to use a parameterized query, which you will
        // learn about later in this chapter.
        // ----------------------------------------------

        public void InsertCar(string color, string make, string petName)
        {
            OpenConnection();

            string sql = $"INSERT INTO Inventory (Make, Color, PetName) VALUES ({color}, {make}, {petName})";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                int affectedRows = command.ExecuteNonQuery();

            }

            CloseConnection();


        }


        // A better method uses the Car model to make a strongly typed method, ensuring all the
        // properties are passed into the method in the correct order.
        public void InsertCar(Car car)
        {
            OpenConnection();

            string sql = $"INSERT INTO Inventory (Make, Color, PetName) VALUES ({car.Color}, {car.Make}, {car.PetName})";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                int affectedRows = command.ExecuteNonQuery();

            }

            CloseConnection();


        }


        public void DeleteCar(int id)
        {
            OpenConnection();

            string sql = $"DELETE FROM Inventory WHERE CarId = {id})";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    int affectedRows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
                
            }

            CloseConnection();


        }


        public void UpdateCarPetName(int id, string newPetName)
        {
            OpenConnection();

            string sql = $"UPDATE Inventory SET PetName = {newPetName} WHERE CarId = {id})";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    int affectedRows = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception($"Error on Update Car with CarId= {id}", ex);
                    throw error;
                }

            }

            CloseConnection();


        }

    }


    #endregion
}
