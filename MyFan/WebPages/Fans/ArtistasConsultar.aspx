<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="ArtistasConsultar.aspx.cs" Inherits="MyFan.WebPages.Fans.ArtistasConsultar" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Consulta de un Artista</h2>
    </hgroup>
    
    <div id="info" style="margin-left:50px">
        <asp:Image ID="imgArtist" runat="server" />
        <asp:Label ID="lblArtistFollowers" runat="server" CssClass="label"></asp:Label>&nbsp;
        <asp:Label ID="lblArtistFollowersText" runat="server" CssClass="label" Text="Seguidores"></asp:Label><br />
        <asp:Button ID="btnFollow" runat="server" Text="Seguir" OnClick="btnFollow_Click" />&nbsp;
        <asp:Label ID="lblError" runat="server" CssClass="message-error"></asp:Label>
        <br />
        <hr />

        <asp:Label ID="lblArtistMembers" runat="server" CssClass="message-success" Text="Integrantes"></asp:Label><br />
        <asp:ListBox ID="lstMembers" runat="server"></asp:ListBox><br /><br />
        <asp:Label ID="lblArtistGenreText" runat="server" CssClass="message-success" Text="Género Musical"></asp:Label>&nbsp;
        <asp:Label ID="lblArtistGenre" runat="server" CssClass="label"></asp:Label><br /><br />
        <asp:Label ID="lblArtistDateText" runat="server" CssClass="message-success" Text="Año de Creación"></asp:Label>&nbsp;
        <asp:Label ID="lblArtistDate" runat="server" CssClass="label"></asp:Label><br /><br />
   
   
        <asp:Label ID="lblBio" runat="server" CssClass="message-success" Text="Biografía"></asp:Label><br />
        <asp:TextBox ID="txtBio" runat="server" TextMode="MultiLine" Enabled="false" Height="150px"></asp:TextBox><br />
   
        <asp:Label ID="lblArtistDiscographyText" Text="Discograf&iacute;a" runat="server" CssClass="message-success"></asp:Label><br />
        <asp:Label ID="lblArtistDiscography" runat="server" CssClass="label"></asp:Label>
    </div>
</asp:Content>
