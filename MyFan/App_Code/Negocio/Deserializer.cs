using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MyFan.App_Code.Negocio
{
    /// <summary>
    /// Clase para convertir las cadenas de caracteres JSon a objetos.
    /// </summary>
    public class Deserializer
    {
        private JavaScriptSerializer js;

        public Deserializer()
        {
            js = new JavaScriptSerializer();
        }

        /// <summary>
        /// Convierte una cadena de caracteres a un objeto para luego ser casteado.
        /// </summary>
        /// <param name="JSon">String en formato JSon</param>
        /// <param name="Target">Objeto destino del deserializer</param>
        /// <returns>Objeto convertido.</returns>
        public Object deserialize(String JSon, Type Target)
        {
            return (Object)js.Deserialize(JSon, Target);
        }
    }
}