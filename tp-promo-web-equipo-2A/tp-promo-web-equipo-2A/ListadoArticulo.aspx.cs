using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tp_promo_web_equipo_2A
{
    public partial class ListadoArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio artNegocio = new ArticuloNegocio();
                List<Articulo> ListadoArticulo = new List<Articulo>();
                ListadoArticulo = artNegocio.Listar();
                System.Diagnostics.Debug.WriteLine("Cantidad de imágenes: " + ListadoArticulo.Count);
                rptArticulos.DataSource = ListadoArticulo;
                rptArticulos.DataBind();
            }
        }
        public string GetPrimeraImagen(object imagenesObj)
        {
            List<Imagen> lista = imagenesObj as List<Imagen>;
            if (lista != null && lista.Count > 0)
                return lista[0].ImagenUrl;
            return "https://www.shutterstock.com/image-vector/default-ui-image-placeholder-wireframes-600nw-1037719192.jpg";
        }

        protected void button_select_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            //ToDo: Verificar y guardar el id del articulo en variable sesion para reutilizar una vez que se carguen todos los datos personales.
            Session.Add("idArticulo", id);
            Response.Redirect("FormularioDatosPersonales.aspx", false);
        }
    }
}