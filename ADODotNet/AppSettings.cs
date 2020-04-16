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

using System.Configuration;

namespace ADODotNet
{
    public static class AppSettings
    {
        
        public static string GetDataProviderName()
        {


            try
            {
                string providerName = ConfigurationManager.AppSettings["provider"];
                return providerName;
            }
            catch (ConfigurationErrorsException exp)
            {
                Console.WriteLine($"ConfigurationErrorsException: {exp}");
                throw exp;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException: Not Valid Provider!, {ex.Message}");
                throw ex;
            }


        }

        public static string GetConnectionString()
        {

            try
            {
                string connectionString =
                    ConfigurationManager.AppSettings["connectionString"];
                return connectionString;
            }
            catch (ConfigurationErrorsException exp)
            {
                Console.WriteLine($"Error: {exp}");
                throw exp;
            }

        }
    }
}
