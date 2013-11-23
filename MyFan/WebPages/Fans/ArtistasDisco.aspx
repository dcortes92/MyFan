<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="ArtistasDisco.aspx.cs" Inherits="MyFan.WebPages.Fans.ArtistasDisco" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Informaci&oacute;n del Disco</h2>
    </hgroup>
    <asp:Label ID="lblLabel" runat="server" CssClass="label"></asp:Label><br />
    <asp:Label ID="lblGenero" runat="server" CssClass="label"></asp:Label><br />
    <asp:Label ID="lblCalifiacion" runat="server" CssClass="label"></asp:Label><br /><br />
    <asp:Label ID="lblCancionesText" runat="server" CssClass="message-success" Text="Lista de Canciones"></asp:Label><br />
    <asp:Label ID="lblCanciones" runat="server"></asp:Label><br />
</asp:Content>
