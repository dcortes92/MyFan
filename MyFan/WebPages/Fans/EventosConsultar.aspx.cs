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
    public partial class EventosConsultar : System.Web.UI.Page
    {
        private Fan fan;
        private Usuario usuario;
        private int id_evento_pk;
        private String ubicacion;
        private EventoDAL eventoDAL;
        private Evento evento;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Eventos";
            fan = (Fan)Session["Fan"];
            usuario = (Usuario)Session["Usuario"];
            String temp = Request.QueryString["Id"];
            ubicacion = Request.QueryString["City"];
            
            if (!IsPostBack)
            {
                if (ubicacion != null && temp != null)
                {
                    id_evento_pk = int.Parse(temp);
                    txtCiudad.Text = ubicacion;
                    getInfoEvento();
                }
                else
                {
                    btnActualizar.Enabled = false;
                    Response.Redirect("/WebPages/Fans/Eventos.aspx");
                }
            }
        }

        /// <summary>
        /// Gets the information of the given event.
        /// </summary>
        private void getInfoEvento()
        {
            eventoDAL = new EventoDAL();
            evento = eventoDAL.get(id_evento_pk);
            if (evento != null)
            {
                txtTitulo.Text = evento.Titulo;
                txtFecha.Text = evento.Fecha;
                txtContenido.Text = evento.Descripcion;
                if (evento.Concierto)
                {
                    //getInfoSetList();
                    chkConcierto.Checked = true;
                    txtSetList.Enabled = true;
                    txtSetList.Text = evento.Set_list;
                    Session["Evento"] = evento;
                }
                else
                {
                    txtSetList.Enabled = false;
                }
            }
            else
            {
                btnActualizar.Enabled = false;
            }
        }

        /// <summary>
        /// Gets the information about the set list of the concert
        /// </summary>
        private void getInfoSetList()
        {
            throw new NotImplementedException();
        }

        protected void cldFecha_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = cldFecha.SelectedDate.ToShortDateString();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            evento = (Evento)Session["Evento"];
            if (evento != null)
            {
                if (chkConcierto.Enabled)
                {
                    evento.Concierto = true;
                    evento.Set_list = txtSetList.Text;
                }
                else
                {
                    evento.Concierto = false;
                    evento.Set_list = "";
                }

                evento.Titulo = txtTitulo.Text;
                evento.Fecha = txtFecha.Text;
                evento.Descripcion = txtContenido.Text;

                eventoDAL = new EventoDAL();
                if (eventoDAL.update(evento))
                {
                    lblResult.Text = "Evento actualizado correctamente.";
                    lblResult.CssClass = "message-success";
                }
                else
                {
                    lblResult.Text = "Ha ocurrido un error al modificar el evento.";
                    lblResult.CssClass = "message-error";
                }
            }
            else
            {
                lblResult.Text = "Ha ocurrido un error al modificar el evento.";
                lblResult.CssClass = "message-error";
            }
            
        }

        protected void chkConcierto_CheckedChanged(object sender, EventArgs e)
        {
            txtSetList.Enabled = chkConcierto.Enabled;
        }
    }
}