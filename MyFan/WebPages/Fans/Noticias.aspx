<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Noticias.aspx.cs" Inherits="MyFan.WebPages.Fans.Noticias" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>&Uacute;ltimas noticias</h2>
    </hgroup>

    <asp:Label ID="lblNoticias" runat="server"></asp:Label>
</asp:Content>