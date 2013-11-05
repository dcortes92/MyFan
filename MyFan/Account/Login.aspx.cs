using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFan.Account
{
    public partial class Login : Page
    {
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
            Connection connection = new Connection();

            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("FanaticosLogin",
                    new SqlParameter("@nombre_usuario", txtUserName.Text),
                    new SqlParameter("@contrasenia", txtPassword.Text));

                if (obj != null)
                {
                    SqlDataReader reader;

                    if (obj.GetType() == typeof(SqlDataReader))
                    {
                        reader = (SqlDataReader)obj;
                        if (reader.Read())
                        {
                            //Usuario user = new Usuario(lector);
                            //FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                            FormsAuthentication.RedirectFromLoginPage("Daniel", false);
                            //Session["Usuario"] = user;
                        }
                        else
                        {
                            //LoginUser.FailureText = "Nombre de usuario y/o contraseña incorrectos";
                        }
                    }
                    else if (obj.GetType() == typeof(string))
                    {
                        //LoginUser.FailureText = "Ha ocurrido un error al leer los datos: " +
                        // (string)objeto;
                    }
                    else
                    {
                        //LoginUser.FailureText = "Error desconocido";
                    }
                }
                else
                {
                    //LoginUser.FailureText = "Nombre de usuario o contraseña incorrectos";
                }
            }
            
        }
    }
}