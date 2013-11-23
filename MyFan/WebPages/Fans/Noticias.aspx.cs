using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Noticia;

namespace MyFan.WebPages.Fans
{
    public partial class Noticias : System.Web.UI.Page
    {

        private Fan fan;
        private FanaticoDAL fanaticoDAL;
        private News[] noticias;
        private NewsProxy noticiasProxy;
        private List<int> siguiendo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Noticias recientes";
            fan = (Fan)Session["Fan"];

            if (!IsPostBack)
            {
                if (fan != null)
                {
                    cargarNoticias();
                }
                else
                {
                    lblNoticias.Text = "Error al leer los datos del fanático.";
                    lblNoticias.CssClass = "message-error";
                }
            }
        }

        private void cargarNoticias()
        {
            fan = (Fan)Session["Fan"];
            if (fan != null)
            {
                fanaticoDAL = new FanaticoDAL();
                siguiendo = fanaticoDAL.getArtistsFollowing(fan.Id_fanatico_pk);
                if (siguiendo != null)
                {
                    int largo = siguiendo.Count();
                    if (largo > 0)
                    {
                        noticiasProxy = new NewsProxy();
                        for (int i = 0; i < largo; i++)
                        {
                            noticias = noticiasProxy.getByArtistId(siguiendo[i]);


                            for (int j = 0; j < noticias.Count(); j++)
                            {
                                lblNoticias.Text += "<b>T&iacute;tulo: </b>" + " " + noticias[j].Title + "<br/>";
                                lblNoticias.Text += "<i>Publicada el: "+ noticias[j].Date +"</i><br/>";
                                lblNoticias.Text += "<p>"+ noticias[j].Content +"</p><br/>";
                            }
                        }
                    }
                    else
                    {
                        lblNoticias.Text = "Aún no sigues a ningún artista.";
                        lblNoticias.CssClass = "message-success";
                    }
                }
                else
                {
                    lblNoticias.Text = "Error al leer las noticias.";
                    lblNoticias.CssClass = "message-error";
                }
            }
        }
    }
}