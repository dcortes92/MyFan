using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Data;

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
                            Fan fan = new Fan(reader);
                            
                            FormsAuthentication.RedirectFromLoginPage(fan.Nombre_Usuario, false);
                            Session["Fan"] = fan;
                        }
                        else
                        {
                            lblError.Text = "Nombre de usuario y/o contraseña incorrectos";                            
                        }
                    }
                    else if (obj.GetType() == typeof(string))
                    {
                        lblError.Text = "Ha ocurrido un error al leer los datos: " + (string)obj;
                    }
                    else
                    {
                        lblError.Text = "Error desconocido, por favor intente inciar sesión nuevamente.";
                    }
                }
                else
                {
                    lblError.Text = "Nombre de usuario y/o contraseña incorrectos";
                }
            }            
        }
    }
}