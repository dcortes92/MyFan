using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Data;
using MyFan.App_Code.Negocio;
using System.Data;
using System.Data.SqlClient;

namespace MyFan.App_Code.Usuario
{
    /// <summary>
    /// Handler of the class Usuario. This saves and modifies an instance of Usuario in the DataBase.
    /// </summary>
    public class UsuarioDAL : DAL
    {
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
                obj = connection.executeStoredProcedure("UsuariosLogin",
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

        /// <summary>
        /// Registers a new user in the systen
        /// </summary>
        /// <param name="nombre_usuario">The user name to be registered.</param>
        /// <param name="contrasenia">The password of the user.</param>
        /// <param name="correo_electronico">The e-mail of the user</param>
        public bool add(String nombre_usuario, String contrasenia, String correo_electronico)
        {
            connection = new Connection();
            bool retorno = false;
            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("UsuariosAdd",
                     new SqlParameter("@nombre_usuario", nombre_usuario),
                     new SqlParameter("@contrasenia", contrasenia),
                     new SqlParameter("@fecha_creacion", DateTime.Now.Date.ToShortDateString()),
                     new SqlParameter("@correo_electronico", correo_electronico));

                if (obj != null)
                {
                    retorno = true;
                }
                connection.closeConnection();
            }
            return retorno;
        }


        /// <summary>
        /// Updates the user info in the DB.
        /// </summary>
        /// <param name="nombre_usuario">The new user name.</param>
        /// <param name="correo_electronico">The new e-mail.</param>
        /// <returns>true if success, false otherwise.</returns>
        public bool update(int id_usuario_pk, String nombre_usuario, String correo_electronico)
        {
            connection = new Connection();
            bool retorno = false;
            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("UsuariosUpdate",
                    new SqlParameter("@id_usuario_pk", id_usuario_pk),
                    new SqlParameter("@nombre_usuario", nombre_usuario),
                    new SqlParameter("@correo_electronico", correo_electronico));

                if (obj != null)
                {
                    retorno = true;
                }
                connection.closeConnection();
            }
            return retorno;
        }
    }
}