using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Negocio;

namespace MyFan.WebPages.Fans
{
    public partial class AgregarEvento : System.Web.UI.Page
    {
        Usuario usuario;
        UsuarioDAL usuarioDAL;
        Fan fan;
        FanaticoDAL fanaticoDAL;


        protected void Page_Load(object sender, EventArgs e)
        {
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            if (!IsPostBack)
            {
                if (fan == null || usuario == null)
                {
                    lblResult.Text = "Por favor, actualice su información de ubicación.";
                    btnCrearEvento.Enabled = false;
                }
                else
                {

                }
            }
        }

        protected void btnCrearEvento_Click(object sender, EventArgs e)
        {

        }
    }
}