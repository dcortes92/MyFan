using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MyFan.App_Code.Negocio;
using MyFan.App_Data;
using MyFan.MyMusicCenterService;
using MyFan.App_Code.Twitter;
using MyFan.App_Code.Disc;

namespace MyFan.App_Code.Comentario
{
    /// <summary>
    /// Handler of the class Comentario. Stores the comment to the DB and retrieves the info from it.
    /// </summary>
    public class ComentarioDAL : DAL
    {

        private MyMusicCenterWSClient mmc;

        /// <summary>
        /// Inserts a new comment to the data base.
        /// </summary>
        /// <param name="comentario">The comment object.</param>
        /// <returns>True if inserted successfully, false otherwise.</returns>
        public float add(Comentario comentario)
        {
            connection = new Connection();
            float retorno = 0;
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("ComentariosAdd",
                    new SqlParameter("@id_usuario_fk", comentario.Id_usuario_fk),
                    new SqlParameter("@id_disco_fk", comentario.Id_disco_fk),
                    new SqlParameter("@comentario", comentario.Comentario_usuario),
                    new SqlParameter("@calificacion", comentario.Calificacion));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader))
                    {
                        reader = (SqlDataReader)obj;
                        reader.Read();
                        retorno = float.Parse(reader[0].ToString());
                    }
                }
                connection.closeConnection();
            }
            return retorno;
        }

        /// <summary>
        /// Gets the comments of a given disc.
        /// </summary>
        /// <param name="id_disco_fk">The id of the disc.</param>
        /// <returns>List of comments.</returns>
        public List<Comentario> get(int id_disco_fk)
        {
            List<Comentario> comentarios = null;
            connection = new Connection();
            if (connection.openConnection())
            {
                obj = connection.executeStoredProcedure("ComentariosGetByDiscId",
                    new SqlParameter("@id_disco_fk", id_disco_fk));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader))
                    {
                        reader = (SqlDataReader)obj;
                        comentarios = new List<Comentario>();
                        while (reader.Read())
                        {
                            comentarios.Add(new Comentario(reader));
                        }
                    }
                }
                connection.closeConnection();
            }
            return comentarios;
        }

        /// <summary>
        /// Sends the rating of the user to MyMusicCenter
        /// </summary>
        /// <param name="calificacion">Users rating</param>
        /// <param name="cantidad_comentarios">Number of comments, to obtain the average rating.</param>
        public void send(String usuario, Disc.Disc disco)
        {
            mmc = new MyMusicCenterWSClient();
            mmc.UpdateDiscRating(disco.Id, disco.Rating);
            TwitterClient tc = new TwitterClient();
            tc.tweet(usuario + " ha calificado " + disco.Title);
        }
    }
}