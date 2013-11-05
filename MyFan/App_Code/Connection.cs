using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Security;
using System.Configuration;

namespace MyFan
{
    /// <summary>
    /// Access the database, used to execute stored procedures.
    /// </summary>
    public class Connection
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        /// <summary>
        /// This method created a new SQLConnection object.
        /// </summary>
        public Connection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyFanConnection"].ConnectionString);
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        /// <returns>True if the connection opens, false otherwise</returns>
        public bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                ex.ToString(); //In case of an error, debbug an inspect the exception.
                return false;
            }
        }

        /// <summary>
        /// Execute the given stored procedure with the optional parameters.
        /// </summary>
        /// <param name="storedProcedureName">The stored procedure name in the SQL Server Database.</param>
        /// <param name="parameters">List of parameters to attach to the stored procedure.</param>
        /// <returns>An object that can be parsed to a DataReader.</returns>
        public Object executeStoredProcedure(String storedProcedureName, params SqlParameter[] parameters)
        {
            try
            {
                command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter(parameter.ParameterName, parameter.Value));
                }

                reader = command.ExecuteReader();
                return (Object)reader;
            }
            catch (SqlException ex)
            {
                return (Object)ex.Message;
            }
        }

        /// <summary>
        /// Closes the connection object.
        /// </summary>
        public void closeConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}