using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MyFan.App_Code.Usuario
{
    /// <summary>
    /// Manages the user account of the fan.
    /// </summary>
    public class Usuario
    {
        private int id_usuario_pk;
        private String nombre_usuario;
        private String contrasenia;
        private String correo_electronico;
        private String fecha_creacion;

        /// <summary>
        /// Creates a new instance of User based on a sql data reader.
        /// </summary>
        /// <param name="reader">The resulting reader of a query.</param>
        public Usuario(SqlDataReader reader)
        {
            id_usuario_pk = int.Parse(reader[0].ToString());
            nombre_usuario = reader[1].ToString();
            contrasenia = ""; //The password is not read for security reasons.
            correo_electronico = reader[2].ToString();
            fecha_creacion = reader[3].ToString();
        }

        /// <summary>
        /// Creates a new instance of User when the user is creating a new account.
        /// </summary>
        /// <param name="nombre_usuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="correo_electronico"></param>
        /// <param name="fecha_creacion"></param>
        public Usuario(String nombre_usuario, String contrasenia, String correo_electronico, String fecha_creacion)
        {
            this.nombre_usuario = nombre_usuario;
            this.contrasenia = contrasenia;
            this.correo_electronico = correo_electronico;
            this.fecha_creacion = fecha_creacion;
        }

        /// <summary>
        /// Gets or sets the ID of the User
        /// </summary>
        public int Id_usuario_pk
        {
            get { return id_usuario_pk; }
            set { this.id_usuario_pk = value; }
        }

        /// <summary>
        /// Gets or sets the user name of the User.
        /// </summary>
        public String Nombre_Usuario
        {
            get { return nombre_usuario; }
            set { this.nombre_usuario = value; }
        }

        /// <summary>
        /// Gets or sets the password of the User
        /// </summary>
        public String Contrasenia
        {
            get { return contrasenia; }
            set { this.contrasenia = value; }
        }

        /// <summary>
        /// Gets or sets the e-mail of the User
        /// </summary>
        public String Correo_Electronico
        {
            get { return correo_electronico; }
            set { this.correo_electronico = value; }
        }

        /// <summary>
        /// Gets or sets the registration date of the User
        /// </summary>
        public String Fecha_Creacion
        {
            get { return fecha_creacion; }
            set { this.fecha_creacion = value; }
        }
    }
}