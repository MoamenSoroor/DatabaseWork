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
    public class DataProviderFactory
    {

        public DataProviderFactory()
        {

        }


        public IDbConnection GetConnection(string providerName)
        {
            IDbConnection connection = null;
            switch (providerName)
            {
                case DataProviders.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProviders.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProviders.Odbc:
                    connection = new OdbcConnection();
                    break;
                case DataProviders.None:
                default:
                    connection = null;
                    break;
            }

            return connection;
        }





    }
}
