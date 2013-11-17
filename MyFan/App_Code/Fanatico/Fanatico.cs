using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyFan.App_Code.Fanatico
{
    /// <summary>
    /// Manages a fan and all the actions he can do.
    /// </summary>
    public class Fan
    {
        private int id_fanatico_pk;
        private String nombre;
        private String apellido1;
        private String apellido2;
        private bool? genero;
        private String fecha_nacimiento;
        private int id_ciudad_fk;
        private int id_pais_pk;

        /// <summary>
        /// Creates a new instance of fan based on a sql data reader.
        /// </summary>
        /// <param name="reader">The resulting reader of a query.</param>
        public Fan(SqlDataReader reader)
        {
            id_fanatico_pk = int.Parse(reader[0].ToString());
            nombre = reader[2].ToString();
            apellido1 = reader[3].ToString();
            apellido2 = reader[4].ToString();
            genero = reader[5] as bool? ?? null;
            fecha_nacimiento = reader[6].ToString();
            id_ciudad_fk = reader[7].ToString() == "" ? -1 : int.Parse(reader[7].ToString()) ;
        }

        /// <summary>
        /// Creates a new instance of fan when the user is registered.
        /// </summary>
        public Fan()
        {
            this.id_fanatico_pk = -1;
            this.nombre = "";
            this.apellido1 = "";
            this.apellido2 = "";
            this.genero = null;
            this.fecha_nacimiento = "";
            this.id_ciudad_fk = -1;
        }

        /// <summary>
        /// Gets or sets the ID of the Fan
        /// </summary>
        public int Id_fanatico_pk
        {
            get { return id_fanatico_pk; }
            set { this.id_fanatico_pk = value; }
        }

        /// <summary>
        /// Gets or sets the Name of the Fan
        /// </summary>
        public String Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets the Last Name of the Fan
        /// </summary>
        public String Apellido1
        {
            get { return apellido1; }
            set { this.apellido1 = value; }
        }

        /// <summary>
        /// Gets or sets the second Last Name of the Fan
        /// </summary>
        public String Apellido2
        {
            get { return apellido2; }
            set { this.apellido2 = value; }
        }

        /// <summary>
        /// Gets or sets the gender of the Fan.
        /// </summary>
        public bool? Genero
        {
            get { return genero; }
            set { this.genero = value; }
        }

        /// <summary>
        /// Gets or sets the birthday of the Fan
        /// </summary>
        public String Fecha_Nacimiento
        {
            get { return fecha_nacimiento; }
            set { this.fecha_nacimiento = value; }
        }

        /// <summary>
        /// Gets or sets the city of the Fan, used to determine the country.
        /// </summary>
        public int Id_ciudad_fk
        {
            get { return id_ciudad_fk; }
            set { this.id_ciudad_fk = value; }
        }

        /// <summary>
        /// Gets or sets the country of the Fan, used to determine the country.
        /// </summary>
        public int Id_pais_pk
        {
            get { return id_pais_pk; }
            set { this.id_pais_pk = value; }
        }
    }
}
