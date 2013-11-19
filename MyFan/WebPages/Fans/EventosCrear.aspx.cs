using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Negocio;
using MyFan.App_Code.Ubicacion;
using MyFan.App_Code.Evento;

namespace MyFan.WebPages.Fans
{
    public partial class AgregarEvento : System.Web.UI.Page
    {
        private Usuario usuario;
        private Fan fan;
        private CiudadDAL ciudadDAL;
        private Evento evento;
        private EventoDAL eventoDAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Crear Evento";
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            if (!IsPostBack)
            {
                if (fan == null || usuario == null)
                {
                    lblResult.Text = "Por favor, actualice su información de ubicación.";
                    lblResult.CssClass = "message-error";
                    btnCrearEvento.Enabled = false;
                }
                else
                {
                    if (fan.Id_pais_pk == 0 || fan.Id_pais_pk == -1)
                    {
                        lblResult.Text = "Por favor, actualice su información de ubicación.";
                        lblResult.CssClass = "message-error";
                        btnCrearEvento.Enabled = false;
                    }
                    else
                    {
                        populateddlCiudad();
                    }
                }
            }
        }

        protected void btnCrearEvento_Click(object sender, EventArgs e)
        {
            evento = new Evento(txtTitulo.Text, txtContenido.Text, txtFecha.Text, 
                chkConcierto.Checked, int.Parse(ddlCiudad.SelectedValue), usuario.Id_usuario_pk);
            eventoDAL = new EventoDAL();
            if (eventoDAL.add(evento))
            {
                lblResult.Text = "Evento creado correctamente";
                txtContenido.Text = "";
                txtTitulo.Text = "";
                txtFecha.Text = "";
                chkConcierto.Checked = false;
            }
            else
            {
                lblResult.Text = "Ha ocurrido un error al crear el evento.";
                lblResult.CssClass = "message-error";
            }
        }

        /// <summary>
        /// Populates de DDL with the cities of the fan.
        /// </summary>
        private void populateddlCiudad()
        {
            ciudadDAL = new CiudadDAL();
            List<Ciudad> ciudades = ciudadDAL.getCiudadesPorIdPais(fan.Id_pais_pk);
            if (ciudades != null)
            {
                ddlCiudad.Items.Clear();
                for (int i = 0; i < ciudades.Count(); i++)
                {
                    ddlCiudad.Items.Add(new ListItem(ciudades[i].Nombre, ciudades[i].Id_ciudad_pk.ToString()));
                }
            }
        }

        /// <summary>
        /// Updates de date selected by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cldFecha_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = cldFecha.SelectedDate.ToShortDateString();
        }
    }
}