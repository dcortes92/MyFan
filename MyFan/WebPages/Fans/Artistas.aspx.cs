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
            /*int id = int.Parse(txtNombreArtista.Text); Obtener un artista2
            artistDAL = new ArtistProxy();
            artist = artistDAL.getById(id);

            if (artist != null)
            {
                lblResultados.Text = artist.Artistname;
            }*/

            /*String name = txtNombreArtista.Text; Obtener muchos artistas
            artistDAL = new ArtistProxy();
            artists = artistDAL.getByName(name);
            for (int i = 0; i < artists.Length; i++)
            {
                lblResultados.Text += artists[i].Artistname + "\n";
            }*/

            /*artistDAL = new ArtistProxy(); Follow unfollow
            if (artistDAL.follow(8, -1) == 1)
            {
                lblResultados.Text = "Seguido correctamente";
            }*/
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
                table = "<div class='Events' style='overflow:auto;height:160px'>";
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