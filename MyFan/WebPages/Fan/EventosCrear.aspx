﻿<%@ Page Language="C#" CodeBehind="EventosCrear.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MyFan.WebPages.Fan.AgregarEvento" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Crea un nuevo evento</h2>
    </hgroup>
    <br />

    <div style="width:50%; float:left">
        <asp:Label ID="lblTitulo" Text ="Título del Evento" runat="server" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblFecha" Text="Fecha" runat="server" CssClass="label"></asp:Label><br />    
        <asp:Calendar ID="cldFecha" runat="server"></asp:Calendar>
        <asp:TextBox ID="txtFecha" runat="server" Enabled="false"></asp:TextBox><br />
    </div>
    

    <div style="width:49%;float:right">
        <asp:Label ID="lblCiudad" runat="server" Text="Ubicación" CssClass="label"></asp:Label><br />
        <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList><br />
        <asp:Label ID="lblConcierto" runat="server" CssClass="label" Text="¿Es Concierto?"></asp:Label>&nbsp;
        <asp:CheckBox ID="chkConcierto" runat="server" /><br />
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtContenido" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <hr />
    </div>

    <asp:Button ID="btnCrearEvento" runat="server" Text="Crear Evento" /> <br />
    <asp:Label ID="lblResult" runat="server" CssClass="message-success"></asp:Label>
</asp:Content>
