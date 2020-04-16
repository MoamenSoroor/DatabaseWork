using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace ADODotNet
{
    public static class ConnectionUtilities
    {
        public static void PrintConnectionInfo(IDbConnection connection)
        {
            Console.WriteLine();
            Console.WriteLine("Connection Info:");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"type    :{connection.GetType()}");
            Console.WriteLine($"string  :{connection.ConnectionString}");
            Console.WriteLine($"State   :{connection.State}");
            Console.WriteLine($"Database:{connection.Database}");
            Console.WriteLine($"Timeout :{connection.ConnectionTimeout}");
            Console.WriteLine("------------------------------------------");
        }

    }
}
