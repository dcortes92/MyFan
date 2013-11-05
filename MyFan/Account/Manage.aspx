<%@ Page Title="Administrar cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="MyFan.Account.Manage" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <section id="passwordForm">
        <p>Ha iniciado sesión como <strong><%: User.Identity.Name %></strong>.</p>
        <asp:Label ID="lblMemberSince" runat="server" CssClass="label"></asp:Label>
        <h2>Actualice su informaci&oacute;n</h2>
        
        
        <div style="width: 50%; float:left">
            <asp:Label ID="lblName" runat="server" Text="Nombre: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblLastName1" runat="server" Text="Apellido 1: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtLastName1" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblLastName2" runat="server" Text="Apellido 2: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtLastName2" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblUserName" runat="server" Text="Nombre de usuario: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="El nombre de usuario es obligatorio" CssClass="message-error"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="El correo electrónico es obligatorio" CssClass="message-error"></asp:RequiredFieldValidator>
            <br /><asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Por favor, ingrese una dirección de correo electrónica válida." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="message-error"></asp:RegularExpressionValidator>           
        </div>

        <div style="width: 49%; float:right">
            <asp:Label ID="lblGender" runat="server" Text="Género: " CssClass="label"></asp:Label><br />
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="label">
                <asp:ListItem>Hombre</asp:ListItem>
                <asp:ListItem>Mujer</asp:ListItem>
                <asp:ListItem>Prefiero no decir</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label ID="lblBirthday" runat="server" Text="Fecha de nacimiento: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtBirthday" runat="server" ToolTip="dd/MM/YYYY"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="País: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="Ciudad: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />

            <div style="float:left">
                <asp:Button ID="btnUpdateInfo" runat="server" Text="Actualizar Información" />   
            </div>
        </div>
    </section>
    
    
</asp:Content>
