using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Membership.OpenAuth;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Usuario;

namespace MyFan.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        Fan fan;
        Usuario usuario;

        protected void Page_Load()
        {
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            if (!IsPostBack)
            {
                txtUserName.Text = usuario.Nombre_Usuario;
                txtEmail.Text = usuario.Correo_Electronico;
                txtName.Text = fan.Nombre;
                txtLastName1.Text = fan.Apellido1;
                txtLastName2.Text = fan.Apellido2;
                lblMemberSince.Text = "Unido el " + usuario.Fecha_Creacion;
                if (fan.Genero == null)
                {
                    ddlGender.SelectedValue = "0";
                }
                else if (fan.Genero == true)
                {
                    ddlGender.SelectedValue = "1";
                }
                else
                {
                    ddlGender.SelectedValue = "2";
                }
            }

        }               
    }
}