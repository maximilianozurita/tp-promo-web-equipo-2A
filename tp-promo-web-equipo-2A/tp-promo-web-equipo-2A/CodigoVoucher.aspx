<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CodigoVoucher.aspx.cs" Inherits="tp_promo_web_equipo_2A.CodigoVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
      <div class="row justify-content-center">
        <div class="col-md-6 text-center">
            <div class="mb-3">
                <label for="codigoVoucher" class="form-label">Ingresá el código de tu voucher!</label>
                <asp:TextBox runat="server" type="text" CssClass="form-control text-center" ID="codigoVoucher" placeholder="xxxx"/>
            </div>
            <asp:Button ID="button_siguiente" CssClass="btn btn-primary" runat="server" Text="Siguiente" OnClick="button_siguiente_Click"/>
        </div>
      </div>
    </div>
</asp:Content>