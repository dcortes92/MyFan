using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Artista;
using MyFan.App_Code.Usuario;

namespace MyFan.WebPages.Fans
{
    public partial class ArtistasConsultar : System.Web.UI.Page
    {
        private Fan fan;
        private Usuario usuario;
        private int Id;
        private Artist artist;
        private ArtistProxy artistProxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Artistas";
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            String temp = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                if (temp != null)
                {
                    Id = int.Parse(temp);
                    getInfoArtist();
                }
                else
                {
                    btnFollow.Enabled = false;
                    Response.Redirect("/WebPages/Fans/Artistas.aspx");
                }
            }
        }

        /// <summary>
        /// Gets the information of an artist given the parameter.
        /// </summary>
        private void getInfoArtist()
        {
            artistProxy = new ArtistProxy();
            artist = artistProxy.getById(Id);
            Session["Artist"] = artist;
            lstMembers.Items.Clear();
            if (artist != null)
            {
                Title = artist.Artistname;
                lblArtistFollowers.Text = artist.Followers + "";                
                lblArtistDate.Text = artist.CreationYear + "";
                txtBio.Text = artist.Biography;

                if (artist.Members != null)
                {
                    for (int i = 0; i < artist.Members.Count; i++)
                    {
                        lstMembers.Items.Add(new ListItem(artist.Members[i].ToString()));
                    }
                }
                
            }
            else
            {
                btnFollow.Enabled = false;
            }
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            artist = (Artist)Session["Artist"];
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];

            if (artist == null || fan == null || usuario == null)
            {
                lblError.Text = "No se pudo obtener sus datos. Por favor intente inciar sesión nuevamente.";
            }
            else
            {
                artistProxy = new ArtistProxy();
                if (artistProxy.follow(1, usuario, fan, artist) == 1)
                {
                    btnFollow.Text = "Siguiendo";
                }
                else
                {
                    lblError.Text = "No se pudo seguir al artista."
                }
            }
        }
    }
}