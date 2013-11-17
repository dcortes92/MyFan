using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data.SqlClient;
using MyFan.App_Data;
using MyFan.App_Code.Fanatico;

namespace MyFan.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            /*Connection connection = new Connection();

            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("FanaticosAdd",
                    new SqlParameter("@nombre_usuario", txtUserName.Text),
                    new SqlParameter("@contrasenia", txtPassword.Text),
                    new SqlParameter("@fecha_creacion", DateTime.Now.Date.ToShortDateString()),
                    new SqlParameter("@correo_electronico", txtEmail.Text));

                Fan fan = new Fan(txtUserName.Text, txtPassword.Text, DateTime.Now.Date.ToShortDateString(), txtEmail.Text);

                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
                Session["Fan"] = fan;
            }*/
        }
    }
}