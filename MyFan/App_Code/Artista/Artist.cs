using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Code.Negocio;
using System.Web.Script.Serialization;

namespace MyFan.App_Code.Artista
{
    /// <summary>
    /// Stores the information of an artist. The information of this object is send and received via
    /// the web service.
    /// </summary>
    public class Artist : JSon
    {
        private int id;
        /// <summary>
        /// Gets or sets the id of an artist.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String artistname;
        /// <summary>
        /// Gets or sets the name of an artist.
        /// </summary>
        public String Artistname
        {
            get { return artistname; }
            set { artistname = value; }
        }

        private String biography;
        /// <summary>
        /// Gets or sets the biography of an artis.
        /// </summary>
        public String Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        private int creationYear;
        /// <summary>
        /// Gets or sets the year of foundation of an artis.
        /// </summary>
        public int CreationYear
        {
            get { return creationYear; }
            set { creationYear = value; }
        }

        private List<String> members;
        /// <summary>
        /// Gets or sets the members of a Band.
        /// </summary>
        public List<String> Members
        {
            get { return members; }
            set { members = value; }
        }

        //private MusicalGenre musicalGenre;

        private String kindOfArtist;
        /// <summary>
        /// Gets or sets the kind of artist (Band, Soloist).
        /// </summary>
        public String KindOfArtist
        {
            get { return kindOfArtist; }
            set { kindOfArtist = value; }
        }

        private int followers;
        /// <summary>
        /// Gets or sets the number of followers of an artist.
        /// </summary>
        public int Followers
        {
            get { return followers; }
            set { followers = value; }
        }

        private MusicalGenre musicalGenre;
        /// <summary>
        /// Gets or sets the Musical Genre of an artist.
        /// </summary>
        public MusicalGenre MusicalGenre
        {
            get { return musicalGenre; }
            set { musicalGenre = value; }
        }


        /// <summary>
        /// Empty constructor used when the object is parsed from a JSon string.
        /// </summary>
        public Artist()
        {

        }

        /// <summary>
        /// Converts an Artist object to a JSon string.
        /// </summary>
        /// <returns>The resulting string of the convertion.</returns>
        public string toJSon()
        {
            throw new NotImplementedException();
        }
    }
}