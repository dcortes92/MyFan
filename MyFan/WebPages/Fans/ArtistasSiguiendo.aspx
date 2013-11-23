<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="ArtistasSiguiendo.aspx.cs" Inherits="MyFan.WebPages.Fans.ArtistasSiguiendo" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Tus Artistas Favoritos</h2>
    </hgroup>
    <asp:Label ID="lblArtistasSiguiendo" runat="server"></asp:Label>
</asp:Content>