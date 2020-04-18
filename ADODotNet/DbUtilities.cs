using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;

using static System.Environment;

namespace ADODotNet
{
    public static class DbUtilities
    {
        public static string GetInfo(DbConnection connection)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Connection Info:");
            builder.AppendLine("------------------------------------------");
            builder.AppendLine($"type--------------:{connection.GetType()}");
            builder.AppendLine($"connectionString--:{connection.ConnectionString}");
            builder.AppendLine($"ServerVersion-----:{connection.ServerVersion}");
            builder.AppendLine($"DataSource--------:{connection.DataSource}");
            builder.AppendLine($"Database----------:{connection.Database}");
            builder.AppendLine($"State-------------:{connection.State}");
            builder.AppendLine($"Timeout ----------:{connection.ConnectionTimeout}");
            builder.AppendLine("------------------------------------------");
            return builder.ToString();
        }

        public static string GetInfo(IDbConnection connection)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("IDbConnection Info:");
            builder.AppendLine("------------------------------------------");
            builder.AppendLine($"type    :{connection.GetType()}");
            builder.AppendLine($"string  :{connection.ConnectionString}");
            builder.AppendLine($"State   :{connection.State}");
            builder.AppendLine($"Database:{connection.Database}");
            builder.AppendLine($"Timeout :{connection.ConnectionTimeout}");
            builder.AppendLine("------------------------------------------");
            return builder.ToString();
        }

        public static string GetInfo(DbDataReader reader)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DbDataReader Info:");
            builder.AppendLine("------------------------------------------");
            builder.AppendLine($"GetType()       : {reader.GetType()}");
            builder.AppendLine($"HasRows         : {reader.HasRows}");
            builder.AppendLine($"FieldCount      : {reader.FieldCount}");
            builder.AppendLine($"RecordsAffected : { reader.RecordsAffected}");
            builder.AppendLine("------------------------------------------");
            return builder.ToString();
        }


        public static string GetInfo(DbCommand command)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DbCommand Info:");
            builder.AppendLine("------------------------------------------");
            builder.AppendLine($"GetType()      :{command.GetType()}");
            builder.AppendLine($"CommandType    :{command.CommandType}");
            builder.AppendLine($"CommandText    :{command.CommandText}");
            builder.AppendLine($"CommandTimeout :{command.CommandTimeout}");
            builder.AppendLine("------------------------------------------");
            return builder.ToString();
        }


        public static string GetInfo(DbParameterCollection parCollection)
        {

            var parameters = from p in parCollection.OfType<DbParameter>()
                             select $"ParamterInfo: Name= { p.ParameterName}, DbType= {p.DbType}, Size= { p.Size}";
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DbParameterCollection Info:");
            builder.AppendLine("------------------------------------------");
            builder.AppendLine(string.Join(NewLine,parameters));
            builder.AppendLine("------------------------------------------");
            return builder.ToString();
        }


        public static string GetInfo(DbParameter parameter)
        {

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DbParameter Info:");
            builder.AppendLine("------------------------------------------");
            builder.AppendLine($"GetType()     :{parameter.GetType()}");
            builder.AppendLine($"DbType        :{parameter.DbType}");
            builder.AppendLine($"Name          :{parameter.ParameterName}");
            builder.AppendLine($"Size          :{parameter.Size}");
            builder.AppendLine($"Value         :{parameter.Value}");
            builder.AppendLine("------------------------------------------");
            return builder.ToString();
        }

    }
}
