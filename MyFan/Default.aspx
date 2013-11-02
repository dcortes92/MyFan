<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyFan._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>My Fan</h1>
                <h2>La red social de fan&aacute;nicos de la m&uacute;sica. </h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Conecta con MyFan</h3>
    <ol class="round">
        <li class="one">
            <h5>Sigue a tus artistas</h5>
            Consulta todo el contenido discogr&aacute;fico y la ficha del artista. <br />
            Recibe notificaciones de las noticias que publican los artistas que seguis.
        </li>
        <li class="two">
            <h5>Califica un disco</h5>
            Agrega comentarios y califica discos.
        </li>
        <li class="three">
            <h5>Crea eventos</h5>
            Crea tus propios eventos y agrega informaci&oacute;n del evento para que otros asistan.
        </li>
    </ol>
</asp:Content>
