using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Negocio;

namespace MyFan.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        Fan fan;
        Usuario usuario;
        Fecha fecha;
        FanaticoDAL fanaticoDAL;
        UsuarioDAL usuarioDAL;

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
                    ddlGender.SelectedValue = "2";
                }
                else if (fan.Genero == true)
                {
                    ddlGender.SelectedValue = "1";
                }
                else
                {
                    ddlGender.SelectedValue = "0";
                }

                if (fan.Fecha_Nacimiento != "")
                {
                    fecha = new Fecha();
                    string[] fechaparsed = fecha.parsear(fan.Fecha_Nacimiento);
                    ddlAnio.SelectedValue = fechaparsed[0];
                    ddlMes.SelectedValue = int.Parse(fechaparsed[1]).ToString();
                    ddlDia.SelectedValue = int.Parse(fechaparsed[2]).ToString();
                }

                if (fan.Id_pais_pk != -1)
                {
                    ddlPais.SelectedIndex = fan.Id_pais_pk - 1;
                    populateddlCiudadLoad();
                    ddlCiudad.SelectedIndex = fan.Id_ciudad_fk - 1;
                }
            }
            
        }

        
        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            fecha = new Fecha();
            int genero = 0;
            String nueva_fecha_nacimiento = fecha.contriur(ddlDia.SelectedValue, ddlMes.SelectedValue, ddlAnio.SelectedValue);
            if (nueva_fecha_nacimiento != "")
            {
                fan.Fecha_Nacimiento = nueva_fecha_nacimiento;
            }
            usuario.Correo_Electronico = txtEmail.Text;
            usuario.Nombre_Usuario = txtUserName.Text;

            fan.Nombre = txtName.Text;
            fan.Apellido1 = txtLastName1.Text;
            fan.Apellido2 = txtLastName2.Text;
            fan.Genero = ddlGender.SelectedValue == "1" ? true:false ;
            fan.Id_ciudad_fk = int.Parse(ddlCiudad.SelectedValue);

            Session["Fan"] = fan;
            Session["Usuario"] = usuario;

            usuarioDAL = new UsuarioDAL();
            fanaticoDAL = new FanaticoDAL();

            genero = int.Parse(ddlGender.SelectedValue);

            if (genero == 2)
            {
                genero = -1;
            }

            if (usuarioDAL.update(usuario.Id_usuario_pk, usuario.Nombre_Usuario, usuario.Correo_Electronico))
            {
                if(fanaticoDAL.update(fan.Nombre, fan.Apellido1, fan.Apellido2, genero, nueva_fecha_nacimiento, fan.Id_ciudad_fk, usuario.Id_usuario_pk))
                {
                    lblResult.Text = "Información actualizada correctamente.";
                }
                else
                {
                    lblResult.CssClass = "message-error";
                    lblResult.Text = "Ha ocurrido un error al actualizar su información";
                }
            }
            else
            {
                lblResult.CssClass = "message-error";
                lblResult.Text = "Ha ocurrido un error al actualizar su información";
            }
        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateddlCiudad();
        }

        private void populateddlCiudad()
        {
            ddlCiudad.Items.Clear();
            fanaticoDAL = new FanaticoDAL();
            List<MyListItem> ciudades = fanaticoDAL.getCiudades(int.Parse(ddlPais.SelectedValue));
            for (int i = 0; i < ciudades.Count(); i++)
            {
                ListItem item = new ListItem();
                item.Text = ciudades[i].Text;
                item.Value = ciudades[i].Value;
                ddlCiudad.Items.Add(item);
            }
        }

        private void populateddlCiudadLoad()
        {
            ddlCiudad.Items.Clear();
            fanaticoDAL = new FanaticoDAL();
            List<MyListItem> ciudades = fanaticoDAL.getCiudades(fan.Id_pais_pk);
            for (int i = 0; i < ciudades.Count(); i++)
            {
                ListItem item = new ListItem();
                item.Text = ciudades[i].Text;
                item.Value = ciudades[i].Value;
                ddlCiudad.Items.Add(item);
            }
        }
    }
}