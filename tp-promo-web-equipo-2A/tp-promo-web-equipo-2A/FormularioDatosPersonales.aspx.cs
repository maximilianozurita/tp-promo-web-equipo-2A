using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_promo_web_equipo_2A
{
    public partial class FormularioDatosPersonales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string dni = textDni.Text;
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            string email = textEmail.Text;
            string ciudad = textCiudad.Text;
            string direccion = textDireccion.Text;
            string cp = textCP.Text;
            bool terminos = checkTerminos.Checked;

            //ToDo: Verificar todos los datos, tomar voucher id y articulo id guardado en sesion para procesar toda la operacion en la BD
            string codigo = (string)Session["articuloSeleccionado"];

        }
    }
}