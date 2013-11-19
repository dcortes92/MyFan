using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MyFan.App_Code.Negocio;
using System.Web.Script.Serialization;

namespace MyFan.App_Code.Usuario
{
    /// <summary>
    /// Manages the user account of the fan.
    /// </summary>
    public class Usuario : JSon
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
            correo_electronico = reader[1].ToString();
            nombre_usuario = reader[2].ToString();
            contrasenia = ""; //The password is not read for security reasons.
            fecha_creacion = reader[4].ToString();
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
        /// Constructor vacío se ocupa cuando se deserializa un JSon a este objeto.
        /// </summary>
        public Usuario()
        {

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

        /// <summary>
        /// Médoto implementado de la interface JSon para convertir el objeto a una cadena de caracteres.
        /// </summary>
        /// <returns>Cadena de caracteres JSon con la información del objeto</returns>
        public String toJSon()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}