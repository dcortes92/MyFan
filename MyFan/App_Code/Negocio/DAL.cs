using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MyFan.App_Data;

namespace MyFan.App_Code.Negocio
{
    /// <summary>
    /// Base class used to handle information of child classes.
    /// </summary>
    public class DAL
    {
        /// <summary>
        /// Connection object to acces de data base.
        /// </summary>
        protected Connection connection;

        /// <summary>
        /// Object used to fecth data from DB and casting it to a DataReader
        /// </summary>
        protected Object obj;

        /// <summary>
        /// DataReader used to fecth data from DB and parsing it to the object needed.
        /// </summary>
        protected SqlDataReader reader;
    }
}