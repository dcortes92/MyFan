using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFan.App_Code.Negocio;

namespace MyFan.App_Code.Noticia
{
    /// <summary>
    /// Stores the information of news. The information of this object is send and received via
    /// the web service.
    /// </summary>
    public class News : JSon
    {
        private int id;
        /// <summary>
        /// Gets or sets the id of News.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String title;
        /// <summary>
        /// Gets or sets the title of News.
        /// </summary>
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String content;
        /// <summary>
        /// Gets or sets the content of News.
        /// </summary>
        public String Content
        {
            get { return content; }
            set { content = value; }
        }

        private String date;
        /// <summary>
        /// Gets or sets the date of News.
        /// </summary>
        public String Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Empty constructor used when the object is parsed from a JSon string.
        /// </summary>
        public News()
        {

        }

        /// <summary>
        /// Converts a News object to a JSon string.
        /// </summary>
        /// <returns>The resulting string of the convertion.</returns>
        public string toJSon()
        {
            throw new NotImplementedException();
        }
    }
}