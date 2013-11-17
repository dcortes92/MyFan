using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Data;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Usuario;

namespace MyFan.Account
{
    public partial class Login : Page
    {

        UsuarioDAL usuarioDAL;
        Usuario usuario;
        FanaticoDAL fanaticoDAL;
        Fan fan;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            usuarioDAL = new UsuarioDAL();
            usuario = usuarioDAL.login(txtUserName.Text, txtPassword.Text);
            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                fanaticoDAL = new FanaticoDAL();
                fan = fanaticoDAL.getFanByID(usuario.Id_usuario_pk);
                if (usuario != null)
                {
                    Session["Fan"] = fan;
                    FormsAuthentication.RedirectFromLoginPage(usuario.Nombre_Usuario, false);
                }
                else
                {
                    lblError.Text = "Ha ocurrido un error al obtener la información del fanático. Por favor, inténtelo de nuevo.";
                }
            }
            else
            {
                lblError.Text = "Nombre de usuario y/o contraseña incorrectos.";
            }
        }
    }
}