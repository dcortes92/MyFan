using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MyFan.App_Code.Ubicacion
{
    /// <summary>
    /// Class that stores the information of a city.
    /// </summary>
    public class Ciudad
    {
        private int id_ciudad_pk;
        /// <summary>
        /// Gets the id of the city. Cannot be set.
        /// </summary>
        public int Id_ciudad_pk
        {
            get { return id_ciudad_pk; }
        }

        private int id_pais_fk;
        /// <summary>
        /// Gets or sets the id of the country of the city. 
        /// </summary>
        public int Id_pais_fk
        {
            get { return id_pais_fk; }
            set { id_pais_fk = value; }
        }

        private String ciudad;
        /// <summary>
        /// Gets or sets the name of the city. Cannot be set.
        /// </summary>
        public String Nombre
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        /// <summary>
        /// Creates a new instance based on a reader.
        /// </summary>
        /// <param name="reader"></param>
        public Ciudad(SqlDataReader reader)
        {
            this.id_ciudad_pk = int.Parse(reader[0].ToString());
            this.id_pais_fk = int.Parse(reader[1].ToString());
            this.ciudad = reader[2].ToString();
        }
    }
}