<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Artistas.aspx.cs" Inherits="MyFan.WebPages.Fans.Artistas" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>B&uacute;squeda de Artistas</h2>
    </hgroup>
    <asp:Label ID="lblNombreArtistas" runat="server" CssClass="label" Text="Ingrese el nombre del artista / solista"></asp:Label><br />
    <asp:TextBox ID="txtNombreArtista" runat="server"></asp:TextBox>&nbsp;
    <asp:Button ID="btnBuscarArtistas" runat="server" Text="Buscar Artista / Solista" OnClick="btnBuscarArtistas_Click"/><br /><hr />
    <asp:Label ID="lblResultados" runat="server" CssClass="label"></asp:Label>
</asp:Content>
