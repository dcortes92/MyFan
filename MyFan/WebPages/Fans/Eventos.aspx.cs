using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Negocio;
using MyFan.App_Code.Ubicacion;
using MyFan.App_Code.Evento;

namespace MyFan.WebPages.Fans
{
    public partial class Eventos : System.Web.UI.Page
    {
        private Usuario usuario;
        private Fan fan;
        private CiudadDAL ciudadDAL;
        private EventoDAL eventoDAL;
        String res;


        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Eventos";
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            if (!IsPostBack)
            {
                if (fan == null || usuario == null)
                {
                    lblTable.Text = "Por favor, actualice su información de ubicación.";
                    lblTable.CssClass = "message-error";
                }
                else
                {
                    if (fan.Id_pais_pk == 0 || fan.Id_pais_pk == -1 || fan.Id_ciudad_fk == 0 || fan.Id_ciudad_fk == -1)
                    {
                        lblTable.Text = "Por favor, actualice su información de ubicación.";
                        lblTable.CssClass = "message-error";
                    }
                    else
                    {
                        getRegion();
                        populateTable();
                    }
                }
            }
        }

        /// <summary>
        /// Creates a table with the events of the fans region.
        /// </summary>
        private void populateTable()
        {
            String table = "";
            eventoDAL = new EventoDAL();
            List<Evento> eventos = eventoDAL.getByIdCiudad(fan.Id_ciudad_fk);
            if (eventos != null)
            {
                table = "<div class='Events' style='overflow:auto;height:160px'>";
                table += "<table><tr><td>T&iacute;tulo Evento</td><td>Descripci&oacute;n</td></tr>";
                for (int i = 0; i < eventos.Count(); i++)
                {
                    table += "<tr><td><a href='/WebPages/Fans/EventosConsultar.aspx?Id=" + eventos[i].Id_evento_pk + "&City="+res+"'>"
                        + eventos[i].Titulo + "</a></td><td>" + eventos[i].Descripcion + "</td></tr>";
                }
                table += "</table></div>";
                lblTable.Text = table;
            }
            else
            {
                lblTable.Text = "No hay eventos en su región.";
                lblTable.CssClass = "message-succes";
            }
        }

        /// <summary>
        /// Gets the fan region to display it in a component.
        /// </summary>
        private void getRegion()
        {
            ciudadDAL = new CiudadDAL();
            res = ciudadDAL.getCiudadPorId(fan.Id_ciudad_fk);
            if (res != "")
            {
                lblRegion.Text = "Mostrando eventos en " + res + ". <a href='/Account/Manage.aspx'>Cambiar ubicaci&oacute;n</a>";
            }
        }
    }
}