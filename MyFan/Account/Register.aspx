<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyFan.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <asp:Label ID="lblUserName" runat="server" Text="Nombre de usuario: " CssClass="label"></asp:Label><br />
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="El nombre de usuario es obligatorio" CssClass="message-error"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico: " CssClass="label"></asp:Label><br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El correo electrónico es obligatorio" CssClass="message-error"></asp:RequiredFieldValidator>
    <br /><asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Por favor, ingrese una dirección de correo electrónica válida." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="message-error"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Contraseña: " CssClass="label"></asp:Label><br />
    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="La contraseña es obligatoria." CssClass="message-error"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmar contraseña: " CssClass="label"></asp:Label><br />
    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Por favor, confirme la contraseña." ControlToValidate="txtConfirmPassword" CssClass="message-error"></asp:RequiredFieldValidator>
    <br /><asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Las contraseñas deben coincidir." ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" CssClass="message-error"></asp:CompareValidator>
    <br />
    <asp:Button ID="btnRegister" runat="server" Text="Registrarse" OnClick="btnRegister_Click" />
</asp:Content>