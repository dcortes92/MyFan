<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Galeria.aspx.cs" Inherits="MyFan.WebPages.Fans.Galeria" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Fotograf&iacute;as de los Conciertos</h2>
    </hgroup>
    <asp:Button ID="Autenticar" runat="server" Text="Autenticar" OnClick="Autenticar_Click" />
    <br />
    <asp:Label ID="lblGalerias" runat="server"></asp:Label>

</asp:Content>
