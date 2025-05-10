<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CodigoVoucher.aspx.cs" Inherits="tp_promo_web_equipo_2A.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
      <div class="row justify-content-center">
        <div class="col-md-6 text-center">
            <div class="mb-3">
              <label for="codigoVoucher" class="form-label">Ingresá el código de tu voucher!</label>
              <input type="text" class="form-control text-center" id="codigoVoucher" required>
            </div>
            <button type="submit" class="btn btn-primary">Siguiente</button>
        </div>
      </div>
    </div>
</asp:Content>