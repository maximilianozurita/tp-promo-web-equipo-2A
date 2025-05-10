<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoArticulo.aspx.cs" Inherits="tp_promo_web_equipo_2A.ListadoArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
      <h2 class="text-center mb-4">Elegí tu premio</h2>
      <div class="row justify-content-center">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                      <div class="card text-center h-100">
                        <img src=<%# GetPrimeraImagen(Eval("Imagenes")) %> class="card-img-top">
                        <div class="card-body">
                          <h5 class="card-title"><%#Eval("Nombre") %></h5>
                          <p class="card-text"><%#Eval("Descripcion") %></p>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value=<%#Eval("ID") %> />
                            <asp:Button ID="button_select" CssClass="btn btn-primary" runat="server" Text="¡Quiero este!" OnClick="button_select_Click" CommandArgument='<%#Eval("ID") %>' CommandName="articulo_id"/>
                        </div>
                      </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
      </div>
    </div>
</asp:Content>
