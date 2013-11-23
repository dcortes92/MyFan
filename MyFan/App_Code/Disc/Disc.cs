using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Code.Negocio;
using MyFan.App_Code.Artista;
using MyFan.App_Code.Song;

namespace MyFan.App_Code.Disc
{
    /// <summary>
    /// Stores the information of a Disc. The information of this object is send and received via
    /// the web service.
    /// </summary>
    public class Disc : JSon
    {
        private int id;
        /// <summary>
        /// Gets or sets the id of a disc.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String title;
        /// <summary>
        /// Gets or set the title of a Disc
        /// </summary>
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String description;
        /// <summary>
        /// Gets or sets the description of a Disc.
        /// </summary>
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private int year;
        /// <summary>
        /// Gets or sets the Year of a Disc.
        /// </summary>
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private String discographicLabel;
        /// <summary>
        /// Gets or sets the discographic Label of a Disc.
        /// </summary>
        public String DiscographicLabel
        {
            get { return discographicLabel; }
            set { discographicLabel = value; }
        }

        private MusicalGenre musicalGenre;
        /// <summary>
        /// Gets or sets the Musical Genre of a Disc.
        /// </summary>
        public MusicalGenre MusicalGenre
        {
            get { return musicalGenre; }
            set { musicalGenre = value; }
        }


        private Double rating;
        /// <summary>
        /// Gets or sets the rating of a disc.
        /// </summary>
        public Double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private List<Song.Song> songs;
        /// <summary>
        /// Gets or sets the songs of a disc.
        /// </summary>
        public List<Song.Song> Songs
        {
            get { return songs; }
            set { songs = value; }
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