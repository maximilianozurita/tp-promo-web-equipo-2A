using negocio;
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
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            string mensaje;
            bool res = voucherNegocio.EstaDisponible(codigo, out mensaje);
            if (!res)
            {
                Response.Redirect("Error.aspx?message="+mensaje,false);
            }
            else
            {
                Session.Add("codigoVoucher", codigo);
                Response.Redirect("ListadoArticulo.aspx", false);
            }
        }
    }
}