using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DBHelper
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:DbHelper
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class DbHelper
    {
        // The provider for SQL Server is System.Data.SqlClient, for MySQL is MySql.Data.MySqlClient, and for Oracle is Oracle.ManagedDataAccess.Client
        // DbProviderFactory is an abstract factory pattern in ADO.NET that supports different databases such as SQL Server, MySQL, Oracle, etc.
        // Here, we use the SqlClientFactory object for SQL Server database operations.
        private readonly DbProviderFactory _factory = SqlClientFactory.Instance;

      
        private readonly string _connectionString;

      
       
        public DbHelper()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)  
                .AddJsonFile("appsettings.json", optional: false) 
                .Build();

            
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Connection string not found.");
        }

       
        public int ExecuteNonQuery(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            try
            {
                
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, sql, commandType, parameters))
                {
                    connection.Open();  
                    return command.ExecuteNonQuery();  
                }
            }
            catch (DbException ex)  
            {
                throw new DbOperationException("An error occurred during ExecuteNonQuery", ex);
            }
        }

        
        public object ExecuteScalar(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, sql, commandType, parameters))
                {
                    connection.Open();
                    return command.ExecuteScalar(); 
                }
            }
            catch (DbException ex) 
            {
                throw new DbOperationException("An error occurred during ExecuteScalar", ex);
            }
        }
       
        public DataSet ExecuteDataSet(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, sql, commandType, parameters))
                using (DbDataAdapter adapter = _factory.CreateDataAdapter()) 
                {
                    connection.Open();
                    adapter.SelectCommand = command;  
                    DataSet dataSet = new DataSet();  
                    adapter.Fill(dataSet);  
                    return dataSet;  
                }
            }
            catch (DbException ex) 
            {
                throw new DbOperationException("An error occurred during ExecuteDataSet", ex);
            }
        }

        public DataTable ExecuteDataTable(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, sql, commandType, parameters))
                using (DbDataAdapter adapter = _factory.CreateDataAdapter())  
                {
                    connection.Open();
                    adapter.SelectCommand = command;  
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);  
                    return dataTable;
                }
            }
            catch (DbException ex)  
            {
                throw new DbOperationException("An error occurred during ExecuteDataTable", ex);
            }
        }

        public void ExecuteStoredProcedure(string procedureName, DbParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, procedureName, CommandType.StoredProcedure, parameters))
                {
                    connection.Open();
                    command.ExecuteNonQuery(); 
                }
            }
            catch (DbException ex) 
            {
                throw new DbOperationException("An error occurred during ExecuteStoredProcedure", ex);
            }
        }

        public int ExecuteStoredProcedureReturnValue(string procedureName, DbParameter[] parameters)
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, procedureName, CommandType.StoredProcedure, parameters))
                {
                    DbParameter returnValue = command.CreateParameter();
                    returnValue.ParameterName = "@ReturnValue"; 
                    returnValue.Direction = ParameterDirection.ReturnValue;  
                    returnValue.DbType = DbType.Int32; 
                    command.Parameters.Add(returnValue);

                    connection.Open();
                    command.ExecuteNonQuery(); 

                    int result = (int)returnValue.Value;
                    return result; 
                }
            }
            catch (DbException ex) 
            {
                throw new DbOperationException("An error occurred during ExecuteStoredProcedure", ex);
            }
        }

        public DataTable ExecuteStoredProcedureWithDataTable(string procedureName, DbParameter[] parameters) 
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, procedureName, CommandType.StoredProcedure, parameters))
                using (DbDataAdapter adapter = _factory.CreateDataAdapter())
                {
                    connection.Open();
                    adapter.SelectCommand = command;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); 
                    return dataTable;
                }
            }
            catch (DbException ex) 
            {
                throw new DbOperationException("An error occurred during ExecuteStoredProcedureWithDataTable", ex);
            }
        }
        public DataSet ExecuteStoredProcedureWithDataSet(string procedureName, DbParameter[] parameters)  // Edit为 DbParameter[] 类型
        {
            try
            {
                using (DbConnection connection = CreateConnection())
                using (DbCommand command = CreateCommand(connection, procedureName, CommandType.StoredProcedure, parameters))
                using (DbDataAdapter adapter = _factory.CreateDataAdapter())
                {
                    connection.Open();
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet(); 
                    adapter.Fill(dataSet); 
                    return dataSet;  
                }
            }
            catch (DbException ex)  
            {
                throw new DbOperationException("An error occurred during ExecuteStoredProcedureWithDataSet", ex);
            }
        }

        private DbConnection CreateConnection()
        {
            DbConnection connection = _factory.CreateConnection();  
            connection.ConnectionString = _connectionString;  
            return connection;
        }

        private DbCommand CreateCommand(DbConnection connection, string sql, CommandType commandType, params DbParameter[] parameters)
        {
            DbCommand command = connection.CreateCommand(); 
            command.CommandText = sql; 
            command.CommandType = commandType;  

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter ?? throw new ArgumentNullException(nameof(parameter)));
                }
            }

            return command;
        }
    }

    public class DbOperationException : Exception
    {
        public DbOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}