using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Code.Negocio;
using MyFan.App_Data;
using System.Data.SqlClient;

namespace MyFan.App_Code.Ubicacion
{
    /// <summary>
    /// Handler of the class Ciudad.
    /// </summary>
    public class CiudadDAL : DAL
    {
        /// <summary>
        /// Gets a list of cities based of the id of a country.
        /// </summary>
        /// <param name="id_pais_fk"></param>
        /// <returns></returns>
        public List<Ciudad> getCiudadesPorIdPais(int id_pais_fk)
        {
            connection = new Connection();
            List<Ciudad> ciudades = null;
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("CiudadesGetByIdPais",
                    new SqlParameter("@id_pais_fk", id_pais_fk));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader))
                    {
                        reader = (SqlDataReader)obj;
                        ciudades = new List<Ciudad>();
                        while (reader.Read())
                        {
                            ciudades.Add(new Ciudad(reader));
                        }
                    }
                }
                connection.closeConnection();
            }
            return ciudades;
        }
    }
}