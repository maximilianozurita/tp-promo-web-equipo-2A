using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_promo_web_equipo_2A
{
    public partial class FormularioDatosPersonales : System.Web.UI.Page
    {
        private ClienteNegocio _clienteNegocio = new ClienteNegocio();
        private Cliente _cliente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //ToDo: Verificar todos los datos, tomar voucher id y articulo id guardado en sesion para procesar toda la operacion en la BD
            bool v1 = Validacion.setearEstiloValidacion(textDni, validDNI);
            bool v2 = Validacion.setearEstiloValidacion(textNombre, validNombre);
            bool v3 = Validacion.setearEstiloValidacion(textApellido, validApellido);
            bool v4 = Validacion.setearEstiloValidacion(textEmail, validEmail);
            bool v5 = Validacion.setearEstiloValidacion(textCiudad, validCiudad);
            bool v6= Validacion.setearEstiloValidacion(textDireccion, validDireccion);
            bool v7 = Validacion.setearEstiloValidacion(textCP, validCp);
            bool v8 = checkTerminos.Checked;
            if (!(v1&&v2&&v3&&v4&&v5&&v6&&v7&&v8)) return;
            string idArticulo = (string)Session["idArticulo"];
            string idVoucher = (string)Session["idVoucher"];
            if(idVoucher == null)
            {
                Response.Redirect("Error.aspx?message=" + "No se pudo recuperar el codigo de Voucher", false);
                return;
            }
            if(idArticulo == null) 
            {
                Response.Redirect("Error.aspx?message=" + "No se pudo recuperar el articulo", false);
                return;
            }
            
            if (this._cliente == null)
            {
                this._cliente = new Cliente();
                this._cliente.Documento = textDni.Text;
                this._cliente.Nombre = textNombre.Text;
                this._cliente.Apellido = textApellido.Text;
                this._cliente.Email = textEmail.Text;
                this._cliente.Ciudad = textCiudad.Text;
                this._cliente.Direccion = textDireccion.Text;
                this._cliente.CP = int.Parse(textCP.Text);
                this._clienteNegocio.SetCliente(this._cliente);
            }
            
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            bool res = voucherNegocio.Asociar(this._cliente.Id, int.Parse(idVoucher), int.Parse(idArticulo));
            if (res)
            {
                Response.Redirect("CodigoVoucher.aspx", false);
            }
            else
            {
                Response.Redirect("Error.aspx?message="+"No se pudo completar la operacion", false);
            }




        }

        protected void textDni_TextChanged(object sender, EventArgs e)
        {
            this._cliente = _clienteNegocio.GetCliente(textDni.Text);
            if (this._cliente == null)
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
                textNombre.Text = this._cliente.Nombre;
                textApellido.Text = this._cliente.Apellido;
                textEmail.Text = this._cliente.Email;
                textCiudad.Text = this._cliente.Ciudad;
                textDireccion.Text = this._cliente.Direccion;
                textCP.Text = this._cliente.CP.ToString();
            }
        }

        protected void checkTerminos_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = checkTerminos.Checked;
        }
    }
}