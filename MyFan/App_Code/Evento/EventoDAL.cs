using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Code.Negocio;
using MyFan.App_Data;
using System.Data.SqlClient;



namespace MyFan.App_Code.Evento
{
    /// <summary>
    /// Handler of the class Evento. This saves and modifies an instance of Evento in the DataBase.
    /// </summary>
    public class EventoDAL : DAL
    {
        /// <summary>
        /// Gets the information of an event based on the id provided.
        /// </summary>
        /// <param name="id_evento_pk"></param>
        /// <returns></returns>
        public Evento get(int id_evento_pk)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an array of Events based of the id of a given city.
        /// </summary>
        /// <param name="id_ciudad_fk">The id of the city.</param>
        /// <returns>A list of events in the city.</returns>
        public List<Evento> getByIdCiudad(int id_ciudad_fk)
        {
            connection = new Connection();
            List<Evento> eventos = null;
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("EventosGetByIdCiudad",
                   new SqlParameter("@id_ciudad_fk", id_ciudad_fk));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader))
                    {
                        reader = (SqlDataReader)obj;
                        eventos = new List<Evento>();
                        while (reader.Read())
                        {
                            eventos.Add(new Evento(reader));
                        }
                    }
                }
                connection.closeConnection();
            }
            return eventos;
        }

        /// <summary>
        /// Saves a new event in the DataBase.
        /// </summary>
        /// <returns></returns>
        public bool add(Evento evento)
        {
            connection = new Connection();
            bool retorno = false;
            int id_set_list_fk;

            id_set_list_fk = evento.Id_set_list_fk; //Stores de id of the set list.
            String descripcion = evento.Descripcion;

            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("EventosAdd",
                    new SqlParameter("@titulo", evento.Titulo),
                    // if description is empty insert NULL
                    new SqlParameter("@descripcion", descripcion == "" ? (Object) DBNull.Value : descripcion),
                    new SqlParameter("@fecha", evento.Fecha),
                    new SqlParameter("@concierto", evento.Concierto),
                    new SqlParameter("@id_ciudad_fk", evento.Id_ciudad_fk),
                    // if the id is 0 insert NULL
                    new SqlParameter("@id_set_list_fk", id_set_list_fk == 0 ? (Object) DBNull.Value : id_set_list_fk),
                    new SqlParameter("@id_fanatico_fk", evento.Id_fanatico_fk));

                if (obj != null)
                {
                    retorno = true;
                }
                connection.closeConnection();
            }
            return retorno;
        }

        /// <summary>
        /// Updates the info of the event.
        /// </summary>
        /// <param name="id_evento_pk"></param>
        /// <param name="evento"></param>
        /// <returns></returns>
        public bool update(int id_evento_pk, Evento evento)
        {
            throw new NotImplementedException();
        }
    }
}