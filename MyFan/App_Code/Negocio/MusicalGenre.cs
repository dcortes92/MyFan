using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan.App_Code.Negocio
{
    /// <summary>
    /// This class stores the information about the Musical Genre of an Artist.
    /// The data is fecth from the Web Service.
    /// </summary>
    public class MusicalGenre
    {
        /// <summary>
        /// The id of the Musical Genre.
        /// </summary>
        private int id;
        /// <summary>
        /// Gets or sets the id of a Musical Genre.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// The name of the Musical Genre.
        /// </summary>
        private String name;
        /// <summary>
        /// Gets or sets the name of the Musical Genre.
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Description of the Musical Genre.
        /// </summary>
        private String description;
        /// <summary>
        /// Gets or sets the description of the Musical Genre.
        /// </summary>
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Empty constructor used when it's parsed from a JSon.
        /// </summary>
        public MusicalGenre()
        {

        }
    }
}