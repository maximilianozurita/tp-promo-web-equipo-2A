<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_promo_web_equipo_2A.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblMensaje" runat="server" />
    <div class="alert alert-success" role="alert">
        <h4 class="alert-heading"> <%= msg %> </h4>
    </div>
    <a href="/CodigoVoucher.aspx" class="btn btn-primary">Inicio</a>
</asp:Content>
