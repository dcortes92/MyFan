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
                <asp:ListItem Value="2">Prefiero no decir</asp:ListItem>
                <asp:ListItem Value="0">Hombre</asp:ListItem>
                <asp:ListItem Value="1">Mujer</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label ID="lblBirthday" runat="server" Text="Fecha de nacimiento: " CssClass="label"></asp:Label><br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Selected="True" Value="0">Día</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem Value="8"></asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="0">Mes</asp:ListItem>
                <asp:ListItem Value="1">Enero</asp:ListItem>
                <asp:ListItem Value="2">Febrero</asp:ListItem>
                <asp:ListItem Value="3">Marzo</asp:ListItem>
                <asp:ListItem Value="4">Abril</asp:ListItem>
                <asp:ListItem Value="5">Mayo</asp:ListItem>
                <asp:ListItem Value="6">Junio</asp:ListItem>
                <asp:ListItem Value="7">Julio</asp:ListItem>
                <asp:ListItem Value="8">Agosto</asp:ListItem>
                <asp:ListItem Value="9">Setiembre</asp:ListItem>
                <asp:ListItem Value="10">Octubre</asp:ListItem>
                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                <asp:ListItem Value="12">Diciembre</asp:ListItem>
            </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem Value="0">Año</asp:ListItem>
                <asp:ListItem>1970</asp:ListItem>
                <asp:ListItem>1971</asp:ListItem>
                <asp:ListItem>1972</asp:ListItem>
                <asp:ListItem>1973</asp:ListItem>
                <asp:ListItem>1974</asp:ListItem>
                <asp:ListItem>1975</asp:ListItem>
                <asp:ListItem>1976</asp:ListItem>
                <asp:ListItem>1977</asp:ListItem>
                <asp:ListItem>1978</asp:ListItem>
                <asp:ListItem>1979</asp:ListItem>
                <asp:ListItem>1980</asp:ListItem>
                <asp:ListItem>1981</asp:ListItem>
                <asp:ListItem>1982</asp:ListItem>
                <asp:ListItem>1983</asp:ListItem>
                <asp:ListItem>1984</asp:ListItem>
                <asp:ListItem>1985</asp:ListItem>
                <asp:ListItem>1986</asp:ListItem>
                <asp:ListItem>1987</asp:ListItem>
                <asp:ListItem>1988</asp:ListItem>
                <asp:ListItem>1989</asp:ListItem>
                <asp:ListItem>1990</asp:ListItem>
                <asp:ListItem>1991</asp:ListItem>
                <asp:ListItem>1992</asp:ListItem>
                <asp:ListItem>1993</asp:ListItem>
                <asp:ListItem>1994</asp:ListItem>
                <asp:ListItem>1995</asp:ListItem>
                <asp:ListItem Value="199">1996</asp:ListItem>
                <asp:ListItem>1997</asp:ListItem>
                <asp:ListItem>1998</asp:ListItem>
                <asp:ListItem>1999</asp:ListItem>
                <asp:ListItem>2000</asp:ListItem>
                <asp:ListItem>2001</asp:ListItem>
                <asp:ListItem>2002</asp:ListItem>
                <asp:ListItem Value="200">2003</asp:ListItem>
                <asp:ListItem>2004</asp:ListItem>
                <asp:ListItem>2005</asp:ListItem>
                <asp:ListItem>2006</asp:ListItem>
                <asp:ListItem>2007</asp:ListItem>
                <asp:ListItem>2008</asp:ListItem>
                <asp:ListItem>2009</asp:ListItem>
                <asp:ListItem>2010</asp:ListItem>
                <asp:ListItem>2011</asp:ListItem>
                <asp:ListItem>2012</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server" Text="País: " CssClass="label"></asp:Label><br />
            <asp:DropDownList ID="ddlPais" runat="server" DataSourceID="SqlDataSourceMyFan" DataTextField="pais" DataValueField="id_pais_pk" Height="28px" Width="311px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceMyFan" runat="server" ConnectionString="<%$ ConnectionStrings:MyFanConnection %>" SelectCommand="SELECT * FROM [Paises]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Ciudad: " CssClass="label"></asp:Label><br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />

            <div style="float:left">
                <asp:Button ID="btnUpdateInfo" runat="server" Text="Actualizar Información" />   
            </div>
        </div>
    </section>
    
    
</asp:Content>
