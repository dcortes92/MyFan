using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MyFan.App_Code.Negocio
{
    /// <summary>
    /// Interface para convertir los objetos a JSON.
    /// </summary>
    interface JSon
    {
        /// <summary>
        /// Convierte un objeto a JSON
        /// </summary>
        /// <param name="obj">El objeto a convetir.</param>
        /// <returns>Cadena de caracteres convertido a JSON.</returns>
        String toJSon();
    }
}
