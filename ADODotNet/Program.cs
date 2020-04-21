using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


using ADODotNet.BulkImport;
using ADODotNet.Models;
using ADODotNet.DataOperations;


using static System.Environment;

namespace ADODotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSimpleDataProviderFactory();

            //TestDataProviderFactoryModel();

            //TestConnectedLayer();

            //TestConnectionStringBuilder();

            //TestDataReaders();

            //TestMultipleResultSetsUsingDataReaders();

            //TestInsert("make1","color1","name1");
            //TestInsertWithParameters("make2","color2","name2");
            //TestDataReaders();

            //TestDelete(8);
            //TestDeleteWithParameters(9);
            //TestDataReaders();

            //UpdateCarPetName(6,"Greeny");
            //UpdateCarPetNameWithParameters(6,"VGreeny");
            //TestDataReaders();


            //Console.WriteLine(LookUpPetName(1));
            //Console.WriteLine(LookUpPetName(2));
            //Console.WriteLine(LookUpPetName(3));


            //ProcessCreditRisk(true, 1);
            //ProcessCreditRisk(false, 1);

            TestBulkCopyWithCustomDataReader();


        }

        #region The Types of the System.Data Namespace
        // ------------------------ The Types of the System.Data Namespace -------------------------
        // This namespace contains types that are shared among all ADO.NET data providers, regardless of the underlying
        // data store. 
        // 
        // In addition to a number of database-centric exceptions (e.g., NoNullAllowedException,
        // RowNotInTableException, and MissingPrimaryKeyException), 
        // 
        // System.Data contains types that represent various database primitives (e.g., tables, rows,
        // columns, and constraints), as well as the common interfaces implemented by data provider objects. 
        // 
        // Table 21-4. Core Members of the System.Data Namespace
        // -----------------------------------------------------------------------------
        // Type             Meaning in Life
        // -----------------------------------------------------------------------------
        // 
        // Constraint           Represents a constraint for a given DataColumn object
        // 
        // DataColumn           Represents a single column within a DataTable object
        // 
        // DataRow              Represents a single row within a DataTable object
        // 
        // DataRelation         Represents a parent-child relationship between two DataTable objects
        // 
        // DataSet              Represents an in-memory cache of data consisting of any number 
        //                      of interrelated DataTable objects
        // 
        // DataTable            Represents a tabular block of in-memory data
        // 
        // DataTableReader      Allows you to treat a DataTable as a fire-hose cursor
        //                      (forward only, read-only data access)
        // 
        // DataView             Represents a customized view of a DataTable for sorting, filtering, 
        //                      searching, editing, and navigation
        // 
        // 
        // IDbCommand           Defines the core behavior of a command object
        // 
        // 
        // IDbConnection        Defines the core behavior of a connection object
        //                      
        // IDbTransaction       Defines the core behavior of a transaction object
        //                      
        // IDbCommand           Defines the core behavior of a connection object
        //                      
        // IDataParameter                            
        // IDbDataParameter     Defines the core behavior of a parameter object
        // 
        // IDataAdapter         Defines the core behavior of a data adapter object
        // IDbDataAdapter       Extends IDataAdapter to provide additional functionality of 
        //                      a data adapter object
        // 
        // IDataRecord          defines many members that allow you to extract a
        //                      strongly typed value from the stream
        // 
        // IDataReader          Extends IDataRecord, and Defines the core behavior 
        //                      of a data reader object
        // 
        // ----------------------------------------------------------------------------------------------
        // 
        // Key System.Data Interfaces:
        // -----------------------------------------------------------------------
        //  public interface IDbConnection : IDisposable
        //  {
        //      string ConnectionString { get; set; }
        //      int ConnectionTimeout { get; }
        //      string Database { get; }
        //      ConnectionState State { get; }
        //      IDbTransaction BeginTransaction();
        //      IDbTransaction BeginTransaction(IsolationLevel il);
        //      void ChangeDatabase(string databaseName);
        //      void Close();
        //      IDbCommand CreateCommand();
        //      void Open();
        //  }

        //  public interface IDbTransaction : IDisposable
        //  {
        //      IDbConnection Connection { get; }
        //      IsolationLevel IsolationLevel { get; }
        //      void Commit();
        //      void Rollback();
        //  }


        //  public interface IDbCommand : IDisposable
        //  {
        //      IDbConnection Connection { get; set; }
        //      IDbTransaction Transaction { get; set; }
        //      string CommandText { get; set; }
        //      int CommandTimeout { get; set; }
        //      CommandType CommandType { get; set; }
        //      IDataParameterCollection Parameters { get; }
        //      UpdateRowSource UpdatedRowSource { get; set; }
        //      void Prepare();
        //      void Cancel();
        //      IDbDataParameter CreateParameter();
        //      int ExecuteNonQuery();
        //      IDataReader ExecuteReader();
        //      IDataReader ExecuteReader(CommandBehavior behavior);
        //      object ExecuteScalar();
        //  }

        //  public interface IDbDataParameter : IDataParameter
        //  {
        //      byte Precision { get; set; }
        //      byte Scale { get; set; }
        //      int Size { get; set; }
        //  }

        //  public interface IDataParameter
        //  {
        //      DbType DbType { get; set; }
        //      ParameterDirection Direction { get; set; }
        //      bool IsNullable { get; }
        //      string ParameterName { get; set; }
        //      string SourceColumn { get; set; }
        //      DataRowVersion SourceVersion { get; set; }
        //      object Value { get; set; }
        //  }


        //  public interface IDbDataAdapter : IDataAdapter
        //  {
        //      IDbCommand SelectCommand { get; set; }
        //      IDbCommand InsertCommand { get; set; }
        //      IDbCommand UpdateCommand { get; set; }
        //      IDbCommand DeleteCommand { get; set; }
        //  }

        //  public interface IDataAdapter
        //  {
        //      MissingMappingAction MissingMappingAction { get; set; }
        //      MissingSchemaAction MissingSchemaAction { get; set; }
        //      ITableMappingCollection TableMappings { get; }
        //      DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType);
        //      int Fill(DataSet dataSet);
        //      IDataParameter[] GetFillParameters();
        //      int Update(DataSet dataSet);
        //  }


        //  public interface IDataReader : IDisposable, IDataRecord
        //  {
        //      int Depth { get; }
        //      bool IsClosed { get; }
        //      int RecordsAffected { get; }
        //      void Close();
        //      DataTable GetSchemaTable();
        //      bool NextResult();
        //      bool Read();
        //  }

        //  public interface IDataRecord
        //  {
        //      int FieldCount { get; }
        //      object this[int i] { get; }
        //      object this[string name] { get; }
        //      string GetName(int i);
        //      string GetDataTypeName(int i);
        //      Type GetFieldType(int i);
        //      object GetValue(int i);
        //      int GetValues(object[] values);
        //      int GetOrdinal(string name);
        //      bool GetBoolean(int i);
        //      byte GetByte(int i);
        //      long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length);
        //      char GetChar(int i);
        //      long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length);
        //      Guid GetGuid(int i);
        //      short GetInt16(int i);
        //      int GetInt32(int i);
        //      long GetInt64(int i);
        //      float GetFloat(int i);
        //      double GetDouble(int i);
        //      string GetString(int i);
        //      Decimal GetDecimal(int i);
        //      DateTime GetDateTime(int i);
        //      IDataReader GetData(int i);
        //      bool IsDBNull(int i);
        //  }

        // -------------------------------------------------------------------------
        #endregion

        #region Create a Simple Data Provider Factory
        // ------------------------ Create a Simple Data Provider Factory -------------------------
        // Create a Simple Factory Model
        // -----------------------------
        // The.NET data provider factory pattern allows you to build a single codebase using generalized data access
        // types.Furthermore, using application configuration files(and the <connectionStrings> subelement), you
        // can obtain providers and connection strings declaratively, without the need to recompile or redeploy the
        // assembly that uses the ADO.NET APIs.
        public static void TestSimpleDataProviderFactory()
        {
            Console.WriteLine("---------------- Very Simple Connection Factory ----------------");

            try
            {
                DataProviderFactory factory = new DataProviderFactory();


                IDbConnection connection = factory.GetConnection(ConfigurationManager.AppSettings["provider"]);

                connection.ConnectionString = ConfigurationManager.ConnectionStrings["master"].ConnectionString;

                Console.WriteLine(DbUtilities.GetInfo(connection));

                using (connection)
                {
                    connection.Open();

                    // Make your Ado.Net Operation here!
                    //...

                    Console.WriteLine(DbUtilities.GetInfo(connection));
                }
                Console.WriteLine(DbUtilities.GetInfo(connection));


            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.WriteLine("Main Exception");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Message:{0}", exp.Message);
                Console.WriteLine("StackTrace:{0}", exp.StackTrace);
                Console.WriteLine();

            }
        }
        // -------------------------------------------------------------------------
        #endregion

        #region The ADO.NET Data Provider Factory Model
        // ------------------------ The ADO.NET Data Provider Factory Model -------------------------
        //To understand the data provider factory implementation, recall from Table 21-1 that the classes within a
        //data provider all derive from the same base classes defined within the System.Data.Common namespace.

        //•	 DbCommand: The abstract base class for all command classes

        //•	 DbConnection: The abstract base class for all connection classes

        //•	 DbDataAdapter: The abstract base class for all data adapter classes

        //•	 DbDataRecorder: The abstract base class for all data recorder classes

        //•	 DbDataReader: The abstract base class for all data reader classes

        //•	 DbParameter: The abstract base class for all parameter classes

        //•	 DbParameterCollection: The abstract base class for all parameter collection classes

        //•	 DbTransaction: The abstract base class for all transaction classes


        // with the already made Provider Factory in System.Data.Common:
        // ---------------------------------------------------------------------------
        // DbProviderFactory: The abstract 
        // ------------------
        //      Represents a set of methods for creating instances of a provider's 
        //      implementation of the data source classes.

        // DbProviderFactories:
        // --------------------
        // Represents a set of static methods for creating one or more instances 
        // of System.Data.Common.DbProviderFactory classes.

        public static void TestDataProviderFactoryModel()
        {
            DbProviderFactory factory =
                DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["provider"]);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("NUll Connection!");
                    return;
                }

                // Connection String
                connection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["master"].ConnectionString;

                // Open Connection
                connection.Open();

                // print connection information to console
                Console.WriteLine(DbUtilities.GetInfo(connection));

                // Change Database from master to another one (AutoLot)
                connection.ChangeDatabase("AutoLot");

                Console.WriteLine(DbUtilities.GetInfo(connection));


                DbCommand command = factory.CreateCommand();

                // or Get from DbConnection object
                //DbCommand command2 = connection.CreateCommand();

                // if you get command from factory you should manualy assign connection object 
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Inventory";

                Console.WriteLine(DbUtilities.GetInfo(command));

                // Execute Command ...
                using (DbDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine(DbUtilities.GetInfo(reader));

                    Console.WriteLine("------------------ Inventory ---------------------");
                    Console.WriteLine("     CarID       PetName");
                    Console.WriteLine("----------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"     {reader["CarID"]}       {reader["PetName"]}");
                    }
                }


                // so if you need to a specific provider feature you can cast to it
                // but code will be harder to maintain and will be less flexable:

                //SqlConnection sqlServerConnection = connection as SqlConnection;

                // call specific SQLServer Connection Method:

                //Console.WriteLine(sqlServerConnection.ServerVersion);

            }



        }
        // -------------------------------------------------------------------------
        #endregion

        #region the Connected Layer of ADO.NET
        // ------------------------ the Connected Layer of ADO.NET -------------------------

        public static void TestConnectedLayer()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = "SELECT * FROM Inventory";

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("-------------------- Inventory --------------------");
                    Console.WriteLine($" CarId       Make        PetName");
                    Console.WriteLine("------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($" {reader["CarId"]}       {reader["Make"]}        {reader["PetName"]}");
                    }
                    Console.WriteLine("------------------------------------------");

                }

            }
        }



        // -------------------------------------------------------------------------
        #endregion

        #region Work With DBConnectionStringBuilder/ SqlConnectionStringBuilder
        // ------------------------ Work With DBConnectionStringBuilder/ SqlConnectionStringBuilder -------------------------

        public static void TestConnectionStringBuilder()
        {
            using (SqlConnection connection = new SqlConnection())
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // you define DataSource property as machinename\instance.
                // if you are in your machine you can use localhost\instance.
                builder.DataSource = @"DESKTOP-0GVLH4P\SQLEXPRESS";

                // your database
                builder.InitialCatalog = "AutoLot";

                // security
                builder.IntegratedSecurity = true;

                // timeout
                builder.ConnectTimeout = 20; // default 15 seconds


                connection.ConnectionString = builder.ConnectionString;

                Console.WriteLine(DbUtilities.GetInfo(connection));

                // you can also change in ConnectionString With SqlConnectionStringBuilder
                // after getting it from your .config file or what else.

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = "SELECT * FROM Inventory";

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("-------------------- Inventory --------------------");
                    Console.WriteLine($" CarId       Make        PetName");
                    Console.WriteLine("------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($" {reader["CarId"]}       {reader["Make"]}        {reader["PetName"]}");
                    }
                    Console.WriteLine("------------------------------------------");

                }

                Console.WriteLine("--------------------------- End ---------------------------");

            }
        }

        // -------------------------------------------------------------------------
        #endregion

        #region Working with Command Objects
        // ------------------------ Working with Command Objects -------------------------
        // The SqlCommand type(which derives from DbCommand)
        // is an OO representation of a SQL query, table name, or stored procedure.You specify the type of command
        // using the CommandType property, which can take any value from the CommandType enum, as shown here:
        // 
        // public enum CommandType
        // {
        //     StoredProcedure,
        //     TableDirect,
        //     Text // Default value.
        // }
        //
        // 
        // Table 21-6. Members of the DbCommand Type
        // Member               Meaning in Life
        // ------------------------------------------------------------------------------------------------
        // CommandTimeout       Gets or sets the time to wait while executing the command before terminating the
        //                      attempt and generating an error.The default is 30 seconds.
        // Connection           Gets or sets the DbConnection used by this instance of the DbCommand.
        //                      Parameters Gets the collection of DbParameter objects used for a parameterized query.
        // Cancel()             Cancels the execution of a command.
        // ExecuteReader()      Executes a SQL query and returns the data provider’s DbDataReader object, which
        //                      provides forward-only, read-only access for the result of the query.
        // ExecuteNonQuery()    Executes a SQL nonquery (e.g., an insert, update, delete, or create table).
        // ExecuteScalar()      A lightweight version of the ExecuteReader() method that was designed
        //                      specifically for singleton queries(e.g., obtaining a record count).
        // Prepare()            Creates a prepared(or compiled) version of the command on the data source.As you
        //                      might know, a prepared query executes slightly faster and is useful when you need to
        //                      execute the same query multiple times (typically with different parameters each time)



        public static void TestCommandObjects()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = "SELECT * FROM Inventory";

                // Differnet Ways to Init SqlCommand
                // ------------------------------------------------------------
                //SqlCommand command = new SqlCommand(sql, connection);
                //SqlCommand command = connection.CreateCommand();

                // Create another command object via properties.
                SqlCommand command = new SqlCommand();

                // Connection
                command.Connection = connection;
                // query or procedure
                command.CommandText = sql;

                // CommandType:
                // Can be StoredProcedure, TableDirect, Text 
                // Default value are Text: SQL Query
                command.CommandType = CommandType.Text;

                command.CommandTimeout = 25; // default is 30 seconds

                // Creates a prepared(or compiled) version of the command on the data source. As you
                // might know, a prepared query executes slightly faster and is useful when you need to
                // execute the same query multiple times(typically with different parameters each time).
                // command.Prepare(); 


                // The ExecuteReader() method extracts a data reader object that allows you to examine the results of a SQL
                // Select statement using a forward-only, read - only flow of information.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("-------------------- Inventory --------------------");
                    Console.WriteLine($" CarId       Make        PetName");
                    Console.WriteLine("------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($" {reader["CarId"]}       {reader["Make"]}        {reader["PetName"]}");
                    }
                    Console.WriteLine("------------------------------------------");

                }

            }
        }

        // -------------------------------------------------------------------------
        #endregion

        #region Working with Data Readers
        // ------------------------ Working with Data Readers -------------------------
        // The DbDataReader type(which implements IDataReader) is the simplest and fastest 
        // way to obtain information from a data store.
        // 
        // DataSet holds the entire result of the query in memory at the same time
        // 
        // Data readers are useful when you need to iterate over large amounts of data quickly and you do not
        // need to maintain an in-memory representation.
        // 
        // For example, if you request 20,000 records from a table to
        // store in a text file, it would be rather memory-intensive to hold this information in a DataSet (because a
        // DataSet holds the entire result of the query in memory at the same time).
        // 
        // Note: that data reader objects (unlike data adapter objects) maintain an open
        // connection to their data source until you explicitly close the connection.
        // 
        public static void TestDataReaders()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = "SELECT * FROM Inventory";

                SqlCommand command = new SqlCommand(sql, connection);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("-------------------- Inventory --------------------");
                    Console.WriteLine($" CarId       Make        PetName");
                    Console.WriteLine("------------------------------------------");
                    while (reader.Read())
                    {
                        // You can access the column either by name or by zero-based integer

                        // Access by name
                        //Console.WriteLine($" {reader["CarId"]}       {reader["Make"]}        {reader["PetName"]}");
                        // Access by zero-based column index
                        Console.WriteLine($" {reader[0]}       {reader[1]}        {reader[2]}");
                    }
                    Console.WriteLine("------------------------------------------");

                }


                // Thus, you can clean up the current reader logic
                // (and avoid hard-coded string names) 

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("-------------------- Inventory --------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("------------ Inventory Record ------------");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader.GetName(i) + " = " + reader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("------------------------------------------");

                }

            }
        }

        // -------------------------------------------------------------------------
        #endregion

        #region Obtaining Multiple Result Sets Using a Data Reader
        // ------------------------ Obtaining Multiple Result Sets Using a Data Reader -------------------------
        // Data reader objects can obtain multiple result sets using a single command object.
        // 
        public static void TestMultipleResultSetsUsingDataReaders()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = "SELECT * FROM Inventory;SELECT * FROM Customers";

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    do
                    {
                        Console.WriteLine("---------------- Table ----------------");
                        while (reader.Read())
                        {
                            Console.WriteLine("------------ Record ------------");
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetName(i) + " = " + reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("--------------------------------");

                    } while (reader.NextResult());
                }

            }
        }
        // -------------------------------------------------------------------------
        #endregion

        #region Insert, Update, Delete Queries
        // ------------------------ Insert Query -------------------------

        public static void TestInsert(string make, string color, string petName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = $"INSERT INTO Inventory (Make, Color, PetName) VALUES ('{make}', '{color}', '{petName}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    int affectedRows = command.ExecuteNonQuery();

                }

            }
        }

        public static void TestDelete(int carId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = $"DELETE FROM Inventory WHERE CarId = {carId}";

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

            }
        }

        public static void UpdateCarPetName(int id, string newPetName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = $"UPDATE Inventory SET PetName = '{newPetName}' WHERE CarId = {id}";

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

            }

        }


        // -------------------------------------------------------------------------
        #endregion

        #region Working with Parameterized Command Objects
        // ------------------------ Working with Parameterized Command Objects -------------------------
        //
        // parameterized queries typically execute much faster than a literal SQL string
        // because they are parsed exactly once(rather than each time the SQL string is assigned to the CommandText
        // property). Parameterized queries also help protect against SQL injection attacks(a well-known data access
        // security issue).


        // While building a parameterized query often requires more code, the end result is a more convenient
        // way to tweak SQL statements programmatically, as well as to achieve better overall performance.They also
        // are extremely helpful when you want to trigger a stored procedure.

        // Table 21-7. Key Members of the DbParameter Type
        // ---------------------------------------------------------------------------------------------------
        // Property         Meaning in Life
        // ---------------------------------------------------------------------------------------------------
        // DbType           Gets or sets the native data type of the parameter, represented as a CLR data type
        // Direction        Gets or sets whether the parameter is input-only, output-only, bidirectional, or a return
        //                  value parameter
        // IsNullable       Gets or sets whether the parameter accepts null values
        // ParameterName    Gets or sets the name of the DbParameter
        // Size             Gets or sets the maximum parameter size of the data in bytes; this is useful only for
        //                  textual data
        // Value            Gets or sets the value of the parameter
        // ---------------------------------------------------------------------------------------------------
        public static void TestInsertWithParameters(string make, string color, string petName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = $"INSERT INTO Inventory (Make, Color, PetName) VALUES (@make, @color, @petName)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter makeParameter = new SqlParameter()
                    {
                        ParameterName = "make",
                        Value = make,
                        SqlDbType = SqlDbType.NVarChar,

                    };

                    SqlParameter colorParameter = new SqlParameter()
                    {
                        ParameterName = "color",
                        Value = color,
                        SqlDbType = SqlDbType.NVarChar,

                    };

                    SqlParameter petNameParameter = new SqlParameter()
                    {
                        ParameterName = "petName",
                        Value = petName,
                        SqlDbType = SqlDbType.NVarChar,

                    };

                    command.Parameters.AddRange(new[] { makeParameter, colorParameter, petNameParameter });

                    command.CommandType = CommandType.Text;
                    int affectedRows = command.ExecuteNonQuery();

                }

            }
        }

        public static void TestDeleteWithParameters(int carId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = $"DELETE FROM Inventory WHERE CarId = @carId";



                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        command.Parameters.Add(new SqlParameter("carId", carId) { SqlDbType = SqlDbType.Int });
                        command.CommandType = CommandType.Text;
                        int affectedRows = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Sorry! That car is on order!", ex);
                        throw error;
                    }

                }

            }
        }

        public static void UpdateCarPetNameWithParameters(int id, string newPetName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string sql = $"UPDATE Inventory SET PetName = @newPetName WHERE CarId = @carId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        command.Parameters.Add(new SqlParameter("newPetName", newPetName));
                        command.Parameters.Add(new SqlParameter("carId", id));

                        command.CommandType = CommandType.Text;
                        int affectedRows = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Sorry! That car is on order!", ex);
                        throw error;
                    }

                }

            }

        }



        // ----------------------------------------------------------------------------------------------------
        #endregion

        #region Executing a Stored Procedure
        // ------------------------ Executing a Stored Procedure -------------------------
        public static string LookUpPetName(int carId)
        {
            string result;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                using (SqlCommand command = new SqlCommand("GetPetName", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@carID",
                        Value = carId,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    });

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@petName",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });

                    int affectedRows = command.ExecuteNonQuery();

                    result = (string)command.Parameters["@petName"].Value;
                    return result;

                }

            }

        }
        // -------------------------------------------------------------------------
        #endregion

        #region Understanding Database Transactions
        // ------------------------ Understanding Database Transactions -------------------------
        // a transaction is a set of database operations that must either all succeed or all fail as a collective unit.
        // 
        // transactions are quite important to ensure that table data is safe, valid, and consistent.
        // Transactions are important when a database operation involves interacting with multiple tables or multiple
        // stored procedures(or a combination of database atoms). 
        // 
        // the DBMS ensures that all related steps occur as a single unit.
        // If any part of the transaction fails, the entire operation is rolled back to the original 
        // state.On the other hand, if all steps succeed, the transaction is committed.

        // NOTE:
        // ------------------------------------------------------------------------------------------------------------------
        // Note You might be familiar with the acronym ACiD from looking at transactional literature.This represents
        // the four key properties of a prim-and-proper transaction: atomic (all or nothing), consistent(data remains stable
        // throughout the transaction), isolated(transactions do not step on each other’s feet), and durable(transactions
        // are saved and logged).
        // ------------------------------------------------------------------------------------------------------------------
        // 
        //  public interface IDbTransaction : IDisposable
        //  {
        //      IDbConnection Connection { get; }
        //      IsolationLevel IsolationLevel { get; }
        //      void Commit();
        //      void Rollback();
        //  }
        // 
        // 
        // You call
        // the Commit() method when each of your database operations have succeeded.Doing this causes each of
        // the pending changes to be persisted in the data store.Conversely, you can call the Rollback() method in
        // the event of a runtime exception, which informs the DMBS to disregard any pending changes, leaving the
        // original data intact.
        //
        // 
        // 
        public static void ProcessCreditRisk(bool throwEx, int custId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Server=localhost\SQLEXPRESS;
                      Database=AutoLot;
                      Trusted_Connection=True;".Replace(" ", "").Replace(NewLine, "");

                connection.Open();

                Console.WriteLine(DbUtilities.GetInfo(connection));

                string fName, lName;

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"SELECT * From Customers where CustId={custId}";

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            fName = (string)dataReader["FirstName"];
                            lName = (string)dataReader["LastName"];
                        }
                        else
                        {
                            connection.Close();
                            return;
                        }
                    }

                }

                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    using (SqlCommand deleteCommand = new SqlCommand())
                    using (SqlCommand insertCommand = new SqlCommand())
                    {
                        deleteCommand.Connection = connection;
                        insertCommand.Connection = connection;

                        deleteCommand.CommandType = CommandType.Text;
                        insertCommand.CommandType = CommandType.Text;

                        deleteCommand.CommandText = $"DELETE FROM Customers WHERE CustId = {custId}";
                        insertCommand.CommandText = $"INSERT INTO CreditRisks(FirstName ,LastName) VALUES ('{fName}', '{lName}')";

                        deleteCommand.Transaction = transaction;
                        insertCommand.Transaction = transaction;

                        deleteCommand.ExecuteNonQuery();
                        insertCommand.ExecuteNonQuery();

                        if (throwEx)
                            throw new Exception("Sorry! Database error! Tx failed...");

                        transaction.Commit();

                        Console.WriteLine("Transaction done Successfully!");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();
                    Console.WriteLine("Rollback:" + ex.Message);
                    // Any error will roll back transaction. Using the new conditional access operator to
                    // check for null.
                    transaction?.Rollback();

                }

            }
        }



        // -------------------------------------------------------------------------
        #endregion


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
