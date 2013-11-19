using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MyFan.App_Code.Negocio;
using System.Web.Script.Serialization;

namespace MyFan.App_Code.Evento
{
    /// <summary>
    /// Stores the information of a single event. Also, when an event is created an instance of this
    /// class is created as well.
    /// </summary>
    public class Evento : JSon
    {
        private int id_evento_pk;
        /// <summary>
        /// Gets the Id of the event. This field cannot be set.
        /// </summary>
        public int Id_evento_pk
        {
            get { return id_evento_pk; }            
        }

        private String titulo;
        /// <summary>
        /// Gets or sets the title of the event.
        /// </summary>
        public String Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        private String descripcion;
        /// <summary>
        /// Gets or sets the description of the event.
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private String fecha;
        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private bool concierto;
        /// <summary>
        /// Gets or sets whether the event is a concert or not.
        /// </summary>
        public bool Concierto
        {
            get { return concierto; }
            set { concierto = value; }
        }

        private int id_ciudad_fk;
        /// <summary>
        /// Gets the id of the city of the concert. This field cannot be set.
        /// </summary>
        public int Id_ciudad_fk
        {
            get { return id_ciudad_fk; }
            set { id_ciudad_fk = value; }
        }

        private int id_set_list_fk;
        /// <summary>
        /// Gets the id of the set list. This field cannot be set.
        /// </summary>
        public int Id_set_list_fk
        {
            get { return id_set_list_fk; }
        }

        private int id_fanatico_fk;
        /// <summary>
        /// Gets the id of the fan that created the event. This field cannot be set.
        /// </summary>
        public int Id_fanatico_fk
        {
            get { return id_fanatico_fk; }
        }

        /// <summary>
        /// Empty constructor for the JSon serializer/deserializer
        /// </summary>
        public Evento()
        { 

        }

        /// <summary>
        /// Creats a new instace of the class event when a fan creates and saves a new Event.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="descripcion"></param>
        /// <param name="fecha"></param>
        /// <param name="concierto"></param>
        /// <param name="id_ciudad_fk"></param>
        /// <param name="id_set_list_fk"></param>
        /// <param name="id_fanatico_fk"></param>
        public Evento(String titulo, String descripcion, String fecha, bool concierto,
            int id_ciudad_fk, int id_set_list_fk, int id_fanatico_fk)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.concierto = concierto;
            this.id_ciudad_fk = id_ciudad_fk;
            this.id_set_list_fk = id_set_list_fk;
            this.id_fanatico_fk = id_fanatico_fk;
        }

        /// <summary>
        /// Creates a new instance of User based on a sql data reader.
        /// </summary>
        /// <param name="reader">The resulting reader of a query.</param>
        public Evento(SqlDataReader reader)
        {
            id_evento_pk = int.Parse(reader[0].ToString());
            titulo = reader[1].ToString();
            descripcion = reader[2].ToString();
            fecha = reader[3].ToString();
            concierto = bool.Parse(reader[4].ToString());
            id_ciudad_fk = int.Parse(reader[5].ToString());
            id_set_list_fk = int.Parse(reader[6].ToString());
            id_fanatico_fk = int.Parse(reader[7].ToString());
        }

        /// <summary>
        /// Converts the object to a JSon string.
        /// </summary>
        /// <returns>The resulting string of convertion.</returns>
        public string toJSon()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}