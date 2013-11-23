using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Artista;
using MyFan.App_Code.Fanatico;

namespace MyFan.WebPages.Fans
{
    public partial class ArtistasSiguiendo : System.Web.UI.Page
    {
        private ArtistProxy artistProxy;
        private Artist artist;
        private Artist[] artists;
        private Fan fan;
        private FanaticoDAL fanaticoDAL;
        private List<int> siguiendo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Siguiendo";
            
            if (!IsPostBack)
            {
                fan = (Fan)Session["Fan"];
                if (fan != null)
                {
                    getArtists();
                }
                else
                {
                    lblArtistasSiguiendo.Text = "Ha ocurrido un error, intenta inciar sesión nuevamente";
                    lblArtistasSiguiendo.CssClass = "message-error";
                }
            }
        }

        private void getArtists()
        {
            fan = (Fan)Session["Fan"];
            if (fan != null)
            {
                String table = "";
                fanaticoDAL = new FanaticoDAL();
                siguiendo = fanaticoDAL.getArtistsFollowing(fan.Id_fanatico_pk);
                if (siguiendo != null)
                {
                    int largo = siguiendo.Count();
                    if (largo > 0)
                    {
                        table = "<div class='Events' style='overflow:auto;height:160px;width:250px'>";
                        table += "<table><tr><td>Siguiendo</td></tr>";
                        artistProxy = new ArtistProxy();
                        for (int i = 0; i < largo; i++)
                        {
                            artist = artistProxy.getById(siguiendo[i]);
                            table += "<tr><td><a href='/WebPages/Fans/ArtistasConsultar.aspx?Id=" + artist.Id + "'>" + artist.Artistname + "</a></td></tr>";
                        }
                        table += "</table></div>";
                        lblArtistasSiguiendo.Text = table;
                    }
                    else
                    {
                        lblArtistasSiguiendo.Text = "Aún no sigues a ningún artista.";
                        lblArtistasSiguiendo.CssClass = "message-success";
                    }
                }
                else
                {
                    lblArtistasSiguiendo.Text = "Error al leer las noticias.";
                    lblArtistasSiguiendo.CssClass = "message-error";
                }
            }
        }
    }
}