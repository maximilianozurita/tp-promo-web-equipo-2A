using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_promo_web_equipo_2A
{
    public partial class CodigoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_siguiente_Click(object sender, EventArgs e)
        {
            string codigo = codigoVoucher.Text;

            //ToDo: Crear condicional verificando codigo de articulo. Si esta ok, guardar en sesion y redirigir. Si no, mostrar etiqueta
            try
            {
                //Session.Add("codigoSeleccionado", codigo);
                Response.Redirect("ListadoArticulo.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}