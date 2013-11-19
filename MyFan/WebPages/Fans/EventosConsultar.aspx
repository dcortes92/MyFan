<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="EventosConsultar.aspx.cs" Inherits="MyFan.WebPages.Fans.EventosConsultar" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Informaci&oacute;n del evento</h2>
    </hgroup>
    <br />

    <div style="width:50%; float:left">
        <asp:Label ID="lblTitulo" Text ="Título del Evento" runat="server" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTitulo" CssClass="message-error">Debe especificar el título del evento.</asp:RequiredFieldValidator><br />
        <asp:Label ID="lblFecha" Text="Fecha" runat="server" CssClass="label"></asp:Label><br />    
        <asp:Calendar ID="cldFecha" runat="server"></asp:Calendar>
        <asp:TextBox ID="txtFecha" runat="server" Enabled="false"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe especificar la fecha del evento." ControlToValidate="txtFecha" CssClass="message-error"></asp:RequiredFieldValidator>
    </div>
    

    <div style="width:49%;float:right">
        <asp:Label ID="lblCiudad" runat="server" Text="Ubicación" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtCiudad" Enabled="false" runat="server"></asp:TextBox><br /><br />
        <asp:Label ID="lblConcierto" runat="server" CssClass="label" Text="¿Es Concierto?"></asp:Label>&nbsp;
        <asp:CheckBox ID="chkConcierto" runat="server" /><br /><br />
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtContenido" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Label ID="lblSetList" runat="server" CssClass="label" Text="SetList"></asp:Label><br />
        <asp:TextBox ID="txtSetList" runat="server" TextMode="MultiLine"></asp:TextBox>
        <hr />
    </div>

    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Información" /><br />
    <asp:Label ID="lblResult" runat="server" CssClass="message-success"></asp:Label>
</asp:Content>