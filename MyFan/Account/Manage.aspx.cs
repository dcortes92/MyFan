using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Membership.OpenAuth;

namespace MyFan.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        Fan fan;

        protected void Page_Load()
        {
            fan = (Fan)Session["Fan"];
            if (!IsPostBack)
            {
                txtUserName.Text = fan.Nombre_Usuario;
                txtEmail.Text = fan.Correo_Electronico;
                txtName.Text = fan.Nombre;
                txtLastName1.Text = fan.Apellido1;
                txtLastName2.Text = fan.Apellido2;
                lblMemberSince.Text = "Unido el " + fan.Fecha_Creacion;
                if (fan.Genero == null)
                {
                    ddlGender.SelectedIndex = 2;
                }
                else if (fan.Genero == true)
                {
                    ddlGender.SelectedIndex = 0;
                }
                else
                {
                    ddlGender.SelectedIndex = 1;
                }
            }

        }               
    }
}