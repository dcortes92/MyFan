using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Data;
using System.Data;
using System.Data.SqlClient;

namespace MyFan.App_Code.Fanatico
{
    /// <summary>
    /// Class used by the UI to fetch the user.
    /// </summary>
    public class FanaticoDAL
    {
        /// <summary>
        /// Connection object to acces de data base.
        /// </summary>
        private Connection connection;

        /// <summary>
        /// Object used to fecth data from DB and casting it to a DataReader
        /// </summary>
        private Object obj;

        /// <summary>
        /// DataReader used to fecth data from DB and parsing it to the object needed.
        /// </summary>
        private SqlDataReader reader;

        /// <summary>
        /// Logs in an user to the web page.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns></returns>
        public Fan getFanByID(int id_fan_pk)
        {
            connection = new Connection();
            Fan fan = null;

            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("FanaticosGetById",
                    new SqlParameter("@@id_fanatico_pk", id_fan_pk));

                if (obj != null)
                {
                    if (obj.GetType() == typeof(SqlDataReader)) /* if the obj is instance of a DataReader */
                    {
                        reader = (SqlDataReader)obj; /* The obj is casted to a DataReader */

                        if (reader.Read()) /* Fetch the data. If if reads, user and password combination are correct. */
                        {
                            fan = new Fan(reader); /* Create the instance of fan, used through all operations in the web page. */
                        }
                    }
                }

                /* The connection is closed only if it was opened before. */
                connection.closeConnection();
            }

            /* The fan object is returned, if it's null the user can't log in. */
            return fan;

        }
    }
}