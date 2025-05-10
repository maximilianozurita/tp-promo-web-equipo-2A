<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioDatosPersonales.aspx.cs" Inherits="tp_promo_web_equipo_2A.FormularioDatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">
  <h2>Ingresá tus datos</h2>
  <div class="row g-3 needs-validation">
    <div class="col-md-4">
      <label for="dni" class="form-label">DNI</label>
        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="textDni" placeholder="xxxx"/>
        <div class="invalid-feedback visually-hidden">Falta DNI.</div>
    </div>

    <div class="col-md-4">
      <label for="nombre" class="form-label">Nombre</label>
        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="textNombre" placeholder="xxxx"/>
       <div class="invalid-feedback visually-hidden">Falta Nombre.</div>
    </div>

    <div class="col-md-4">
      <label for="apellido" class="form-label">Apellido</label>
        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="textApellido" placeholder="xxxx"/>
        <div class="invalid-feedback visually-hidden">Falta Apellido</div>
    </div>

    <div class="col-md-6">
      <label for="email" class="form-label">Email</label>
      <div class="input-group">
        <span class="input-group-text">@</span>
        <asp:TextBox runat="server" type="email" CssClass="form-control" ID="textEmail" placeholder="xxxx"/>
        <div class="invalid-feedback visually-hidden">Falta email</div>
      </div>
    </div>

    <div class="col-md-6">
      <label for="direccion" class="form-label">Ciudad</label>
        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="textCiudad" placeholder="xxxx"/>
        <div class="invalid-feedback visually-hidden">Falta Ciudad.</div>
    </div>

    <div class="col-md-4">
      <label for="direccion" class="form-label">Direccion</label>
        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="textDireccion" placeholder="xxxx"/>
        <div class="invalid-feedback visually-hidden">Falta Direccion</div>
    </div>

    <div class="col-md-2">
      <label for="cp" class="form-label">CP</label>
        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="textCP" placeholder="xxxx"/>
        <div class="invalid-feedback visually-hidden">Falta CP</div>
    </div>

    <div class="col-12">
      <div class="form-check">
        <asp:CheckBox runat="server" CssClass="form-check-input" ID="checkTerminos"/>
        <label class="form-check-label">
          Acepto los términos y condiciones.
        </label>
      </div>
    </div>

    <div class="col-12">
        <asp:Button ID="btnAceptar"  CssClass="btn btn-primary" runat="server" Text="¡Participar!" onClick="btnAceptar_Click" />
    </div>
  </div>
</div>
</asp:Content>
