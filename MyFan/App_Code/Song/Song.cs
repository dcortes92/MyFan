using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Code.Negocio;

namespace MyFan.App_Code.Song
{
    /// <summary>
    /// Stores the information of a Song. The information of this object is send and received via
    /// the web service.
    /// </summary>
    public class Song : JSon
    {
        private int id;
        /// <summary>
        /// Gets or sets the id of the Song.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;
        /// <summary>
        /// Gets or sets the name or the song.
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String time;
        /// <summary>
        /// Gets or sets the time of the song.
        /// </summary>
        public String Time
        {
            get { return time; }
            set { time = value; }
        }

        private String edition;
        /// <summary>
        /// Gets or sets the edition of the song.
        /// </summary>
        public String Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        private String songKind;
        /// <summary>
        /// Gets or sets the kind of the song.
        /// </summary>
        public String SongKind
        {
            get { return songKind; }
            set { songKind = value; }
        }

        /// <summary>
        /// Converts an Object to a JSon String.
        /// </summary>
        /// <returns>The resulting string of the convertion.</returns>
        public string toJSon()
        {
            throw new NotImplementedException();
        }
    }
}