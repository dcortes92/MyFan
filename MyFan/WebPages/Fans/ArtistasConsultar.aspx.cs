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
        private FanaticoDAL fanaticoDAL;
        private Usuario usuario;
        private int Id;
        private Artist artist;
        private ArtistProxy artistProxy;
        private List<int> artistsFollowing;
        private int action;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Artistas";
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            String temp = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                if (fan != null)
                {
                    getArtistsFollowing();
                }
                else
                {
                    lblError.Text = "No se pudieron cargar los artistas que sigues. Intenta iniciar sesión nuevamente.";
                }
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
        /// Gets the ids of the artists a fan is already following.
        /// </summary>
        private void getArtistsFollowing()
        {
            fanaticoDAL = new FanaticoDAL();
            artistsFollowing = fanaticoDAL.getArtistsFollowing(fan.Id_fanatico_pk);
            Session["Following"] = artistsFollowing;
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
                /*Get the info of the artist.*/
                Title = artist.Artistname;
                lblArtistFollowers.Text = artist.Followers + "";                
                lblArtistDate.Text = artist.CreationYear + "";
                txtBio.Text = artist.Biography;
                lblArtistGenre.Text = artist.MusicalGenre.Name;

                if (artist.Members != null)
                {
                    for (int i = 0; i < artist.Members.Count; i++)
                    {
                        lstMembers.Items.Add(new ListItem(artist.Members[i].ToString()));
                    }
                }

                /*Check if the fan already follows the user*/
                artistsFollowing = (List<int>)Session["Following"];
                if (artistsFollowing != null)
                {
                    if (artistsFollowing.Contains(artist.Id))
                    {
                        btnFollow.Text = "Dejar de seguir";
                        action = -1;
                        Session["Action"] = action;
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
            

            /* No action read */
            if (Session["Action"] == null)
            {
                action = 1; // Follow
            }
            else
            {
                action = (int)Session["Action"];
            }

            if (artist == null || fan == null || usuario == null)
            {
                lblError.Text = "No se pudo obtener sus datos. Por favor intente inciar sesión nuevamente.";
            }
            else
            {
                artistProxy = new ArtistProxy();
                if (action == 1) //follow or unfollow
                {
                    if (artistProxy.follow(usuario, fan, artist) == 1)
                    {
                        artist.Followers += action;
                        btnFollow.Text = "Dejar de Seguir";
                    }
                    else
                    {
                        lblError.Text = "No se pudo seguir al artista.";
                    }
                }
                else
                {
                    if (artistProxy.unfollow(usuario, fan, artist) == 1)
                    {
                        artist.Followers -= action;
                        btnFollow.Text = "Seguir";
                    }
                    else
                    {
                        lblError.Text = "No se pudo dejar de seguir al artista.";
                    }
                }
            }
        }
    }
}