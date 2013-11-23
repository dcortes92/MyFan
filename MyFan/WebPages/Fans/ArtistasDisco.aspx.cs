using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Artista;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Disc;
using MyFan.App_Code.Song;

namespace MyFan.WebPages.Fans
{
    public partial class ArtistasDisco : System.Web.UI.Page
    {
        private DiscProxy discProxy;
        private Disc disc;
        private Usuario usuario;
        private Artist artist;
        private int Id;
        private List<Song> canciones;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];
            artist = (Artist)Session["Artist"];
            String temp = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                if (usuario != null)
                {
                    if (temp != null)
                    {
                        Id = int.Parse(temp);
                        getInfoDisc();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the information about the disc.
        /// </summary>
        private void getInfoDisc()
        {
            discProxy = new DiscProxy();
            disc = discProxy.getById(Id);
            String table = "";

            if (disc != null)
            {
                Title = disc.Title;
                Title = Title + " ("+disc.Year+") ";
                lblLabel.Text = "Publicado por: " + disc.DiscographicLabel;
                lblGenero.Text = "Género: " + disc.MusicalGenre.Name;
                lblCalifiacion.Text = "Calificación: " + disc.Rating + "/10";
                table = "<div class='Events' style='overflow:auto;height:160px;width:450px'>";
                table += "<table><tr><td>Nombre</td><td>Duraci&oacute;n</td><td>Edici&oacute;n</td><td>Tipo</td></tr>";

                canciones = disc.Songs;

                for (int i = 0; i < canciones.Count; i++)
                {
                    table += "<tr>"+
                                 "<td>"+ canciones[i].Name +"</td>" +
                                 "<td>"+ canciones[i].Time +"</td>" +
                                 "<td>"+ canciones[i].Edition +"</td>" +
                                 "<td>"+ canciones[i].SongKind +"</td>"+
                            "</tr>";
                }

                table += "</table></div>";

                lblCanciones.Text = table;
            }
        }
    }
}