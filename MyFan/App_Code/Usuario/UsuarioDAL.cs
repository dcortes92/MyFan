using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Data;
using System.Data;
using System.Data.SqlClient;

namespace MyFan.App_Code.Usuario
{
    public class UsuarioDAL
    {
        /// <summary>
        /// Connection object to acces de data base.
        /// </summary>
        private Connection connection;

        /// <summary>
        /// Object used to fecth data from DB and casting it to a DataReader
        /// </summary>
        private Object obj;

        /// <summary>
        /// DataReader used to fecth data from DB and parsing it to the object needed.
        /// </summary>
        private SqlDataReader reader;

        /// <summary>
        /// Logs in an user to the web page and returns an object of the user info.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Usuario login(String username, String password)
        {
            connection = new Connection();
            Usuario usuario = null;

            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("UsuariosLogin",
                    new SqlParameter("@nombre_usuario", username),
                    new SqlParameter("@contrasenia", password));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader)) /* if the obj is instance of a DataReader */
                    {
                        reader = (SqlDataReader)obj; /* The obj is casted to a DataReader */

                        if (reader.Read()) /* Fetch the data. If if reads, user and password combination are correct. */
                        {
                            usuario = new Usuario(reader); /* Create the instance of fan, used through all operations in the web page. */
                        }
                    }
                }
                /* The connection is closed only if it was opened before. */
                connection.closeConnection();
            }

            return usuario;
        }
    }
}