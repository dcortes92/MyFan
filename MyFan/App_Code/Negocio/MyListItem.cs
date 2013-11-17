using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan.App_Code.Negocio
{
    /// <summary>
    /// Object that stores the text and value of an sql query
    /// </summary>
    public class MyListItem
    {
        /// <summary>
        /// The text of the list item
        /// </summary>
        private String text;
        /// <summary>
        /// The value of the list item
        /// </summary>
        private String value;

        public MyListItem(String text, String value)
        {
            this.text = text;
            this.value = value;
        }

        public String Text
        {
            get { return text; }
            set { this.text = value; }
        }

        public String Value
        {
            get { return value; }
            set { this.value = value; }
        }

    }
}