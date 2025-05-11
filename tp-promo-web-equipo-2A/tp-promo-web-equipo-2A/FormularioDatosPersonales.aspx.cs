using dominio;
using negocio;
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
        private ClienteNegocio _clienteNegocio = new ClienteNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool v1 = Validacion.setearEstiloValidacion(textDni, validDNI);
            bool v2 = Validacion.setearEstiloValidacion(textNombre, validNombre);
            bool v3 = Validacion.setearEstiloValidacion(textApellido, validApellido);
            bool v4 = Validacion.setearEstiloValidacion(textEmail, validEmail);
            bool v5 = Validacion.setearEstiloValidacion(textCiudad, validCiudad);
            bool v6= Validacion.setearEstiloValidacion(textDireccion, validDireccion);
            bool v7 = Validacion.setearEstiloValidacion(textCP, validCp);
            bool v8 = checkTerminos.Checked;
            if (v1&&v2&&v3&&v4&&v5&&v6&&v7&&v8) return;

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

        protected void textDni_TextChanged(object sender, EventArgs e)
        {
            Cliente cliente = _clienteNegocio.GetCliente(textDni.Text);
            if (cliente == null)
            {
                textNombre.Text = string.Empty;
                textApellido.Text = string.Empty;
                textEmail.Text = string.Empty;
                textCiudad.Text = string.Empty;
                textDireccion.Text = string.Empty;
                textCP.Text = string.Empty;
            }
            else
            {
                textNombre.Text = cliente.Nombre;
                textApellido.Text = cliente.Apellido;
                textEmail.Text = cliente.Email;
                textCiudad.Text = cliente.Ciudad;
                textDireccion.Text = cliente.Direccion;
                textCP.Text = cliente.CP.ToString();
            }
        }

        protected void checkTerminos_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = checkTerminos.Checked;
        }
    }
}