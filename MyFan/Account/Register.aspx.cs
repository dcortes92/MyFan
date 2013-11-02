using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data.SqlClient;

namespace MyFan.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            if (connection.openConnection())
            {
                Object obj = connection.executeStoredProcedure("FanaticosAdd", 
                    new SqlParameter("@nombre_usuario", "daniel"),
                    new SqlParameter("@contrasenia", "1234567"),
                    new SqlParameter("@correo_electronico", "dcortes92@hotmail.com"));
            }

            /*FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);*/
        }
    }
}