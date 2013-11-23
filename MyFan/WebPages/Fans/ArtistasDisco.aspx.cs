using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFan.App_Code.Fanatico;
using MyFan.App_Code.Artista;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Disc;
using MyFan.App_Code.Song;
using MyFan.App_Code.Comentario;

namespace MyFan.WebPages.Fans
{
    public partial class ArtistasDisco : System.Web.UI.Page
    {
        private DiscProxy discProxy;
        private Disc disc;
        private Usuario usuario;
        private Artist artist;
        private int Id;
        private List<Song> canciones;
        private ComentarioDAL comentarioDAL;
        private Comentario comentario;
        private List<Comentario> comentarios;
        private int cantidad_comentarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];
            artist = (Artist)Session["Artist"];
            String temp = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                if (usuario != null)
                {
                    if (temp != null)
                    {
                        Id = int.Parse(temp);
                        getInfoDisc();
                        getComentarios();
                    }
                }
            }
        }

        

        /// <summary>
        /// Gets the information about the disc.
        /// </summary>
        private void getInfoDisc()
        {
            discProxy = new DiscProxy();
            disc = discProxy.getById(Id);
            String table = "";

            if (disc != null)
            {
                Session["Disco"] = disc;
                Title = disc.Title;
                Title = Title + " ("+disc.Year+") ";
                lblLabel.Text = "Publicado por: " + disc.DiscographicLabel;
                lblGenero.Text = "Género: " + disc.MusicalGenre.Name;
                lblCalifiacion.Text = "Calificación: " + disc.Rating + "/10";
                table = "<div class='Events' style='overflow:auto;height:160px;width:450px'>";
                table += "<table><tr><td>Nombre</td><td>Duraci&oacute;n</td><td>Edici&oacute;n</td><td>Tipo</td></tr>";

                canciones = disc.Songs;

                for (int i = 0; i < canciones.Count; i++)
                {
                    table += "<tr>"+
                                 "<td>"+ canciones[i].Name +"</td>" +
                                 "<td>"+ canciones[i].Time +"</td>" +
                                 "<td>"+ canciones[i].Edition +"</td>" +
                                 "<td>"+ canciones[i].SongKind +"</td>"+
                            "</tr>";
                }

                table += "</table></div>";

                lblCanciones.Text = table;
            }
        }

        protected void btnCalificarDisco_Click(object sender, EventArgs e)
        {
            publicarComentario();
            enviarCalificacion();
        }

        /// <summary>
        /// Gets all the comments of a disc
        /// </summary>
        private void getComentarios()
        {
            disc = (Disc)Session["Disco"];
            if (disc != null)
            {
                comentarioDAL = new ComentarioDAL();
                comentarios = comentarioDAL.get(disc.Id);
                if (comentarios == null || comentarios.Count() == 0)
                {
                    Session["Cantidad"] = 1;
                }
                else
                {
                    Session["Cantidad"] = comentarios.Count();

                    for (int i = 0; i < comentarios.Count(); i++)
                    {
                        lblListaCalificaciones.Text += "<p>";
                        lblListaCalificaciones.Text += "Por: " + comentarios[i].Nombre_usuario + "<br />";
                        lblListaCalificaciones.Text += comentarios[i].Comentario_usuario + "</p>";
                    }
                }
            }
        }


        /// <summary>
        /// Sends the user's rating to MyMusicCenter.
        /// </summary>
        private void enviarCalificacion()
        {
            usuario = (Usuario)Session["Usuario"];
            disc = (Disc)Session["Disco"];
            cantidad_comentarios = (int)Session["Cantidad"];
            if (usuario != null && disc != null )
            {
                comentarioDAL = new ComentarioDAL();
                int calificacion;
                try
                {
                    calificacion = int.Parse(txtCalificacion.Text);
                    comentarioDAL.send(calificacion, cantidad_comentarios, usuario.Nombre_Usuario, disc.Title);
                }
                catch(Exception ex)
                {
                    lblResultado.Text = "Debe ingresar un número entero del 1 al 10.";
                    lblResultado.CssClass = "message-error";
                }
            }
            else
            {
                lblResultado.Text = "Error al enviar la calificación a MyMusicCenter";
                lblResultado.CssClass = "message-error";
            }
        }


        /// <summary>
        /// Creates a new comment.
        /// </summary>
        private void publicarComentario()
        {
            usuario = (Usuario)Session["Usuario"];
            disc = (Disc)Session["Disco"];
            if (usuario != null && disc != null)
            {
                comentarioDAL = new ComentarioDAL();
                comentario = new Comentario(usuario.Id_usuario_pk, disc.Id, txtComentario.Text);

                if (comentarioDAL.add(comentario))
                {
                    lblResultado.Text = "Calificación enviada correctamente";
                    lblResultado.CssClass = "message-success";
                }
                else
                {
                    lblResultado.Text = "Error al enviar la calificación";
                    lblResultado.CssClass = "message-error";
                }
            }
            else
            {
                lblResultado.Text = "Ha ocurrido un error al obtener la información del disco.";
                lblResultado.CssClass = "message-error";
            }
            
        }
    }
}