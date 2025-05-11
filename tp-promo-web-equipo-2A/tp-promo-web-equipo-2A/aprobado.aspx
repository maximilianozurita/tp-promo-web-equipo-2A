<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Aprobado.aspx.cs" Inherits="tp_promo_web_equipo_2A.formularioAprobado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Exitos</h1>
    <asp:Label Text="Su registro se efectuo sastifactoriamente" ID="lblMensaje" runat="server" />
    <div class="alert alert-success" role="alert">
        <h4 class="alert-heading">Mucha suerte</h4>
    </div>
    <a href="/CodigoVoucher.aspx" class="btn btn-primary">Inicio</a>
</asp:Content>
