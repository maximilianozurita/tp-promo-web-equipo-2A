<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioDatosPersonales.aspx.cs" Inherits="tp_promo_web_equipo_2A.FormularioDatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">
  <h2>Ingresá tus datos</h2>
  <form class="row g-3 needs-validation" novalidate>
    <div class="col-md-4">
      <label for="dni" class="form-label">DNI</label>
      <input type="text" class="form-control" id="dni" required>
        <div class="invalid-feedback visually-hidden">Falta DNI.</div>
    </div>

    <div class="col-md-4">
      <label for="nombre" class="form-label">Nombre</label>
      <input type="text" class="form-control" id="nombre" required>
       <div class="invalid-feedback visually-hidden">Falta Nombre.</div>
    </div>

    <div class="col-md-4">
      <label for="apellido" class="form-label">Apellido</label>
      <input type="text" class="form-control" id="apellido" required>
        <div class="invalid-feedback visually-hidden">Falta Apellido</div>
    </div>

    <div class="col-md-6">
      <label for="email" class="form-label">Email</label>
      <div class="input-group">
        <span class="input-group-text" id="inputGroupPrepend">@</span>
        <input type="email" class="form-control" id="email" required>
          <div class="invalid-feedback visually-hidden">Falta email</div>
      </div>
    </div>

    <div class="col-md-6">
      <label for="direccion" class="form-label">Ciudad</label>
      <input type="text" class="form-control" id="ciudad" placeholder="Mi ciudad" required>
      <div class="invalid-feedback visually-hidden">Falta Ciudad.</div>
    </div>

    <div class="col-md-4">
      <label for="ciudad" class="form-label">Direccion</label>
      <input type="text" class="form-control" id="direccion" required>
        <div class="invalid-feedback visually-hidden">Falta Direccion</div>
    </div>

    <div class="col-md-2">
      <label for="cp" class="form-label">CP</label>
      <input type="text" class="form-control" id="cp" required>
      <div class="invalid-feedback visually-hidden">Falta CP</div>
    </div>

    <div class="col-12">
      <div class="form-check">
        <input class="form-check-input" type="checkbox" id="terminos" required>
        <label class="form-check-label" for="terminos">
          Acepto los términos y condiciones.
        </label>
      </div>
    </div>

    <div class="col-12">
      <button class="btn btn-primary" type="submit">¡Participar!</button>
    </div>
  </form>
</div>
</asp:Content>
