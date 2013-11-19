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