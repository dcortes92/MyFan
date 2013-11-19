using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Data;
using MyFan.App_Code.Negocio;
using System.Data.SqlClient;
using MyFan.App_Code.Fanatico;

namespace MyFan.App_Code.Fanatico
{
    /// <summary>
    /// Class used by the UI to fetch the user.
    /// </summary>
    public class FanaticoDAL : DAL
    {
        /// <summary>
        /// Logs in an user to the web page.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns></returns>
        public Fan getFanByID(int id_fan_pk)
        {
            connection = new Connection();
            Fan fan = null;

            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("FanaticosGetById",
                    new SqlParameter("@id_fanatico_pk", id_fan_pk));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader)) /* if the obj is instance of a DataReader */
                    {
                        reader = (SqlDataReader)obj; /* The obj is casted to a DataReader */

                        if (reader.Read()) /* Fetch the data. If if reads, user and password combination are correct. */
                        {
                            fan = new Fan(reader); /* Create the instance of fan, used through all operations in the web page. */
                        }
                    }
                }

                /* The connection is closed only if it was opened before. */
                connection.closeConnection();
            }

            /* The fan object is returned, if it's null the user can't log in. */
            fan.Id_pais_pk = getPais(fan.Id_ciudad_fk);
            return fan;

        }


        /// <summary>
        /// Gets the coutry id of the given city.
        /// </summary>
        /// <param name="id_ciudad_fk"></param>
        /// <returns></returns>
        private int getPais(int id_ciudad_fk)
        {
            connection = new Connection();
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("PaisesGetByIdCiuidad", new SqlParameter("@id_ciudad", id_ciudad_fk));

                if (obj != null)
                {
                    reader = (SqlDataReader)obj;
                    if (reader.Read())
                    {
                    
                        return int.Parse(reader[0].ToString());
                    }
                }
            }            
            return -1;
        }

        public List<MyListItem> getCiudades(int id_pais_fk)
        {
            List<MyListItem> ciudades = null;
            connection = new Connection();
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("CiudadesGetByIdPais", new SqlParameter("@id_pais_fk", id_pais_fk));

                if (obj != null)
                {
                    reader = (SqlDataReader)obj;
                    ciudades = new List<MyListItem>();
                    while (reader.Read())
                    {
                        ciudades.Add(new MyListItem(reader[1].ToString(), reader[0].ToString()));
                    }
                }
            }
            return ciudades;
        }

        /// <summary>
        /// Updates the info of the fan.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido1"></param>
        /// <param name="apellido2"></param>
        /// <param name="genero"></param>
        /// <param name="fecha_nacimiento"></param>
        /// <param name="id_ciudad_fk"></param>
        /// <param name="id_usuario"></param>
        /// <returns>True if success, false otherwise.</returns>
        public bool update(String nombre, String apellido1, String apellido2, 
            int genero, String fecha_nacimiento, int id_ciudad_fk, int id_usuario)
        {
            bool retorno = false;
            connection = new Connection();
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("FanaticosUpdate", 
                    new SqlParameter("@nombre", nombre != "" ? nombre : (Object) DBNull.Value),
                    new SqlParameter("@apellido1", apellido1 != "" ? apellido1 : (Object) DBNull.Value),
                    new SqlParameter("@apellido2", apellido2 != "" ? apellido2 : (Object) DBNull.Value),
                    new SqlParameter("@genero", genero != -1 ? genero : (Object) DBNull.Value),
                    new SqlParameter("@fecha_nacimiento", fecha_nacimiento != "" ? fecha_nacimiento : (Object) DBNull.Value),
                    new SqlParameter("@id_ciudad_fk", id_ciudad_fk != 0 ? id_ciudad_fk : (Object) DBNull.Value),
                    new SqlParameter("@id_usuario", id_usuario));

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