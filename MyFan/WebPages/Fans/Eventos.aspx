<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Eventos.aspx.cs" Inherits="MyFan.WebPages.Fans.Eventos" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Lista de eventos en tu regi&oacute;n</h2>
    </hgroup>
    <asp:Label ID="lblRegion" runat="server" CssClass="label"></asp:Label>
    <br /><br />

    <asp:Label ID="lblTable" runat="server"></asp:Label>
    
</asp:Content>