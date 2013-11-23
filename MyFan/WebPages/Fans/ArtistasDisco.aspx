<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="ArtistasDisco.aspx.cs" Inherits="MyFan.WebPages.Fans.ArtistasDisco" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Informaci&oacute;n del Disco</h2>
    </hgroup>
    <asp:Label ID="lblResultado" runat="server"></asp:Label><br />

    <asp:Label ID="lblLabel" runat="server" CssClass="label"></asp:Label><br />
    <asp:Label ID="lblGenero" runat="server" CssClass="label"></asp:Label><br />
    <asp:Label ID="lblCalifiacion" runat="server" CssClass="label"></asp:Label><br /><br />
    <asp:Label ID="lblCancionesText" runat="server" CssClass="message-success" Text="Lista de Canciones"></asp:Label><br />
    <asp:Label ID="lblCanciones" runat="server"></asp:Label><br />
    <br /><hr />
    <asp:Label ID="lblCalificacion" runat="server" CssClass="message-success" Text="Calificación"></asp:Label><br />
    <asp:TextBox ID="txtCalificacion" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCalificacion" CssClass="message-error" ErrorMessage="Ingrese una califiación del 1-10"></asp:RequiredFieldValidator><br />
    <br />
    <asp:Label ID="lblComentario" runat="server" CssClass="message-success" Text="Comentario"></asp:Label><br />
    <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Height="102px" Width="415px"></asp:TextBox><br />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComentario" CssClass="message-error" ErrorMessage="Ingrese un comentario"></asp:RequiredFieldValidator><br /><br />

    <asp:Button ID="btnCalificarDisco" runat="server" Text="Calificar" OnClick="btnCalificarDisco_Click" /><br /><br />
    <hr />
    <asp:Label ID="lblListaCalificacionesText" runat="server" Text="Comentarios" CssClass="message-success"></asp:Label><br /><br />
    <asp:Label ID="lblListaCalificaciones" runat="server"></asp:Label>
</asp:Content>
