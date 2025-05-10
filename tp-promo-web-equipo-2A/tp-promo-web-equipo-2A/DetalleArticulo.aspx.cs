using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace tp_promo_web_equipo_2A
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public Articulo articuloCargado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int articulo_id = int.Parse(Request.QueryString["ID"]);
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloCargado = articuloNegocio.FindById(articulo_id);
            }
            catch (Exception ex)
            {
                Response.Redirect("ListadoArticulo.aspx", false);
            }
        }
        protected void button_submit_Click(object sender, EventArgs e)
        {
            Session.Add("articuloSeleccionado", articuloCargado);
            Response.Redirect("FormularioDatosPersonales.aspx", false);
        }
    }
}