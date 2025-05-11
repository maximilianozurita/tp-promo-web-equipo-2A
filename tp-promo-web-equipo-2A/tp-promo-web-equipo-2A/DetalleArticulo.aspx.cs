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
        public Articulo articulo = new Articulo();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                try
                {
                    int id = int.Parse(Request.QueryString["ID"]);
                    ArticuloNegocio artNeg = new ArticuloNegocio();
                    articulo = artNeg.FindById(id);
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void button_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("articuloSeleccionado", articulo);
                Response.Redirect("FormularioDatosPersonales.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}