using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Artista;

namespace MyFan.WebPages.Fans
{
    public partial class Artistas : System.Web.UI.Page
    {

        private ArtistProxy artistProxy;
        private Artist artist;
        private Artist[] artists;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Buscar Artistas";
        }

        protected void btnBuscarArtistas_Click(object sender, EventArgs e)
        {
            getArtistas();
        }

        public void getArtistas()
        {
            lblResultados.Text = "";
            String table = "";
            String name = txtNombreArtista.Text;
            artistProxy = new ArtistProxy();
            artists = artistProxy.getByName(name);

            if (artists != null)
            {
                table = "<div class='Events' style='overflow:auto;height:160px;width:250px'>";
                table += "<table><tr><td>Resultados</td></tr>";

                for (int i = 0; i < artists.Length; i++)
                {
                    table += "<tr><td><a href='/WebPages/Fans/ArtistasConsultar.aspx?Id=" + artists[i].Id + "'>" + artists[i].Artistname + "</a></td></tr>";
                }

                table += "</table></div>";

                lblResultados.Text = table;
            }
            else
            {
                lblResultados.Text = "No hay resultados.";
            }
        }
    }
}