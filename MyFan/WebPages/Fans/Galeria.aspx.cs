using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp;
using FlickrNet;

namespace MyFan.WebPages.Fans
{
    public partial class Galeria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Galería de fotos";
            if (FlickrManager.OAuthToken != null)
            {
                loadGallery();
            }
            else
            {
                if (Request.QueryString["oauth_verifier"] != null && Session["RequestToken"] != null)
                {
                    Flickr f = FlickrManager.GetInstance();
                    OAuthRequestToken requestToken = Session["RequestToken"] as OAuthRequestToken;
                    OAuthAccessToken accessToken = f.OAuthGetAccessToken(requestToken, Request.QueryString["oauth_verifier"]);

                    FlickrManager.OAuthToken = accessToken;
                }
            }
        }

        /// <summary>
        /// Loads all the albums of the site's flickr account.
        /// </summary>
        private void loadGallery()
        {
            Flickr f = FlickrManager.GetAuthInstance();
            PhotosetCollection pc = f.PhotosetsGetList(FlickrManager.OAuthToken.UserId);
            List<Photoset> albums = pc.ToList();
            String table = "";

            if (albums != null)
            {
                table = "<div class='Events' style='overflow:auto;height:160px;widh:100px'>";
                table += "<table><tr><td>Concierto</td><td>Descripci&oacute;n</td></tr>";
                for (int i = 0; i < albums.Count; i++)
                {
                    table += "<tr><td><a href='" + albums[i].Url + "' target=_'blank'>" + albums[i].Title + "</a>" 
                             + "</td><td>" + albums[i].Description + "</td></tr>";

                    
                }
                table += "</table></div>";
                lblGalerias.Text = table;
            }
            else
            {
                lblGalerias.Text = "No hay álbumes para mostrar.";
                lblGalerias.CssClass = "message-succes";
            }
            
        }

        protected void Autenticar_Click(object sender, EventArgs e)
        {
            Flickr f = FlickrManager.GetInstance();
            OAuthRequestToken token = f.OAuthGetRequestToken(Request.Url.AbsoluteUri);

            Session["RequestToken"] = token;

            string url = f.OAuthCalculateAuthorizationUrl(token.Token, AuthLevel.Read);
            Autenticar.Visible = false;
            Response.Redirect(url);
        }
    }
}