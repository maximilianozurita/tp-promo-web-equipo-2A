<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="tp_promo_web_equipo_2A.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
    <div class="row">
      <div class="col-md-6">
        <div id="carouselArticulo" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner">
            <% 
                bool primerImagen = true; 
                foreach (dominio.Imagen imagen in articuloCargado.Imagenes) { 
            %>
                    <div class='carousel-item <%= primerImagen ? "active" : "" %>'>
                      <img src="<%= imagen.ImagenUrl %>" class="d-block w-100">
                    </div>
            <% 
                    primerImagen = false; 
                }
            %>

          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselArticulo" data-bs-slide="prev">
            <span class="carousel-control-prev-icon"></span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carouselArticulo" data-bs-slide="next">
            <span class="carousel-control-next-icon"></span>
          </button>
        </div>
      </div>

      <div class="col-md-6">
            <h2><%= articuloCargado.Nombre %></h2>
            <p><strong>Marca:</strong> <%= articuloCargado.Marca %></p>
            <p><strong>Categoría:</strong> <%= articuloCargado.Categoria %></p>
            <p><strong>Código:</strong> <%= articuloCargado.Codigo %></p>
            <p><strong>Descripción:</strong></p>
            <p><%= articuloCargado.Descripcion %></p>
            <asp:Button ID="button_submit" CssClass="btn btn-primary" runat="server" Text="Aceptar" OnClick="button_submit_Click"/>
            <a href="ListadoArticulo.aspx" class="btn btn-secondary mt-3">Volver al listado</a>
      </div>
    </div>
  </div>
</asp:Content>
