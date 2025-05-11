<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="tp_promo_web_equipo_2A.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
    <div class="row">

      <div class="col-md-6">
        <div id="carouselArticulo" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner">
              <% bool isFirstImage = true;
                  foreach (dominio.Imagen imagen in articulo.Imagenes) {
                      string clase = isFirstImage ? "carousel-item active" : "carousel-item";
                      %>
                    <div class="<%= clase %>">
                      <img src="<%= imagen.ImagenUrl %>" class="d-block w-100">
                    </div>
                <%
                    isFirstImage = false; 
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
        <h2><%= articulo.Nombre %></h2>
        <p><strong>Marca:</strong><%= articulo.Marca %></p>
        <p><strong>Categoría:</strong> <%= articulo.Categoria %></p>
        <p><strong>Código:</strong> <%= articulo.Codigo %></p>
        <p><strong>Descripción:</strong></p>
        <p>
          <%= articulo.Descripcion %>
        </p>
        <a href="ListadoArticulo.aspx" class="btn btn-secondary mt-3">Volver al listado</a>
        <asp:Button ID="button_aceptar" CssClass="btn btn-primary" runat="server" Text="Seleccionar" OnClick="button_aceptar_Click" />
      </div>
    </div>
  </div>
</asp:Content>
