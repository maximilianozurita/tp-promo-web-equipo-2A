<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoArticulo.aspx.cs" Inherits="tp_promo_web_equipo_2A.ListadoArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
      <h2 class="text-center mb-4">Elegí tu premio</h2>
      <div class="row justify-content-center">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                <div class="col-md-4 mb-4 d-flex">
                    <div class="card text-center w-100">
                        <a href='/DetalleArticulo.aspx?id=<%#Eval("ID") %>'>
                            <img src='<%# GetPrimeraImagen(Eval("Imagenes")) %>' class="card-img-top">
                        </a>
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                        </div>
                    </div>
                </div>
                </ItemTemplate>
            </asp:Repeater>
          <a href="CodigoVoucher.aspx" class="btn btn-secondary mt-3">Atras</a>
      </div>
    </div>
</asp:Content>
