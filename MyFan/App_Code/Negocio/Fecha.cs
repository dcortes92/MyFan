using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan.App_Code.Negocio
{
    /// <summary>
    /// Clase used to parse Dates from database
    /// </summary>
    public class Fecha
    {

        public Fecha()
        {

        }

        /// <summary>
        /// Creates a new date string to be stored in the database
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="mes"></param>
        /// <param name="anio"></param>
        /// <returns></returns>
        public String contriur(String fecha, String mes, String anio)
        {
            if (fecha == "" || mes == "" || anio == "")
            {
                return "";
            }
            else
            {
                return fecha + "-" + mes + "-" + anio;
            }
        }

        /// <summary>
        /// Converts a date in the form yyyy-mm-dd in an array
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string[] parsear(String fecha)
        {
            return fecha.Split('-');
        }
    }
}