<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyFan.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        <asp:Label ID="lblUserName" runat="server" Text="Nombre de usuario: "></asp:Label><br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUserName" CssClass="message-error">Por favor ingrese su nombre de usuario.</asp:RequiredFieldValidator><br />
        <asp:Label ID="lblPassword" runat="server" Text="Contraseña: "></asp:Label><br />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword" CssClass="message-error">Por favor ingrese su contraseña.</asp:RequiredFieldValidator><br />
        <asp:Button ID="btnLogin" runat="server" Text="Inciar sesión" OnClick="btnLogin_Click" /><br />
        <asp:Label ID="lblError" runat="server" CssClass="message-error"></asp:Label>
        
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse</asp:HyperLink>
            si no tiene una cuenta.
        </p>
    </section>

   <!--<section id="socialLoginForm">
        <h2>Utilice otro servicio para iniciar sesión.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>-->
</asp:Content>
