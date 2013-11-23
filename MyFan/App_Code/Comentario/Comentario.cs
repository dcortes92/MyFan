using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MyFan.App_Code.Comentario
{
    /// <summary>
    /// Handles all the comments of a disc.
    /// </summary>
    public class Comentario
    {
        private int id_usuario_fk;
        /// <summary>
        /// Gets or sets the id of the user that submits the comment.
        /// </summary>
        public int Id_usuario_fk
        {
            get { return id_usuario_fk; }
            set { id_usuario_fk = value; }
        }

        private int id_disco_fk;
        /// <summary>
        /// Gets or sets the id of the disc being commented.
        /// </summary>
        public int Id_disco_fk
        {
            get { return id_disco_fk; }
            set { id_disco_fk = value; }
        }

        private String comentario_usuario;
        /// <summary>
        /// Gets or sets the comment submited by the user.
        /// </summary>
        public String Comentario_usuario
        {
            get { return comentario_usuario; }
            set { comentario_usuario = value; }
        }


        private String nombre_usuario;
        /// <summary>
        /// Gets or sets the user name of the user that submited the comment.
        /// </summary>
        public String Nombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        /// <summary>
        /// Constructor when a comment is submited.
        /// </summary>
        /// <param name="id_usuario_fk">The user id.</param>
        /// <param name="id_disco_fk">The disc id.</param>
        /// <param name="comentario_usuario">The content of the comment.</param>
        public Comentario(int id_usuario_fk, int id_disco_fk, String comentario_usuario)
        {
            this.id_usuario_fk = id_usuario_fk;
            this.id_disco_fk = id_disco_fk;
            this.comentario_usuario = comentario_usuario;
        }

        /// <summary>
        /// This constructor is used when the comment is loaded from the DB
        /// </summary>
        /// <param name="reader">Active SQL Data Reader with the comment.</param>
        public Comentario(SqlDataReader reader)
        {
            this.comentario_usuario = reader[0].ToString();
            this.nombre_usuario = reader[1].ToString();
        }
    }
}