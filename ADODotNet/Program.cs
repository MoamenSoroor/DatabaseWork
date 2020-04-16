using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace ADODotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDataProviderFactory();
        }

        public static void TestDataProviderFactory()
        {
            Console.WriteLine("---------------- Very Simple Connection Factory ----------------");

            try
            {
                DataProviderFactory factory = new DataProviderFactory();


                IDbConnection connection = factory.GetConnection(AppSettings.GetDataProviderName());

                connection.ConnectionString = AppSettings.GetConnectionString();

                ConnectionUtilities.PrintConnectionInfo(connection);

                using (connection)
                {
                    connection.Open();

                    // Make your Ado.Net Operation here!
                    //...

                    ConnectionUtilities.PrintConnectionInfo(connection);
                }
                ConnectionUtilities.PrintConnectionInfo(connection);


            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.WriteLine("Main Exception");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Message:{0}",exp.Message);
                Console.WriteLine("StackTrace:{0}",exp.StackTrace);
                Console.WriteLine();

            }
        }

    }
}
