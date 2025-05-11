using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace tp_promo_web_equipo_2A
{
    public partial class FormularioDatosPersonales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SetearError(TextBox textBox, HtmlGenericControl div, string msj)
        {
            div.Attributes["class"] = "invalid-feedback";
            textBox.CssClass = "form-control is-invalid";
            div.InnerHtml = msj;
        }

        protected void InitValidacion(TextBox textBox, HtmlGenericControl div)
        {
            div.Attributes["class"] = "invalid-feedback visually-hidden";
            textBox.CssClass = "form-control";
            div.InnerHtml = "";
        }

        protected bool ValidateInputs ()
        {
            var campos = new List<(TextBox textBox, HtmlGenericControl div)>
            {
                (textDni, validDNI),
                (textNombre, validNombre),
                (textApellido, validApellido),
                (textEmail, validEmail),
                (textCiudad, validCiudad),
                (textDireccion, validDireccion),
                (textCP, validCp)
            };

            bool valid = true;
            foreach (var (textBox, div) in campos)
            {
                InitValidacion(textBox, div);

                string errorMsj = "";
                if (!Validacion.ValidarTextInputs(textBox, ref errorMsj))
                {
                    SetearError(textBox, div, errorMsj);
                    valid = false;
                }
            }

            return valid && checkTerminos.Checked;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }
            Articulo articulo = (Articulo)Session["articuloSeleccionado"];
            int idArticulo = (int)articulo.ID;
            string codigoVoucher = (string)Session["codigoVoucher"];
            if(codigoVoucher == null)
            {
                Session.Add("error", "No se pudo recuperar el codigo de Voucher");
                Response.Redirect("Error.aspx", false);
                return;
            }
            if(idArticulo == 0) 
            {
                Session.Add("error", "No se pudo recuperar el articulo");
                Response.Redirect("Error.aspx", false);
                return;
            }
            int idCliente= (int)Session["idCliente"];
            if (idCliente == 0)
            {
                Cliente cliente = new Cliente();
                cliente.Documento = textDni.Text;
                cliente.Nombre = textNombre.Text;
                cliente.Apellido = textApellido.Text;
                cliente.Email = textEmail.Text;
                cliente.Ciudad = textCiudad.Text;
                cliente.Direccion = textDireccion.Text;
                cliente.CP = int.Parse(textCP.Text);
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                idCliente = clienteNegocio.SetCliente(cliente);
                if(idCliente <= 0)
                {
                    Session.Add("error", "No se pudo Agregar el cliente");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
            }
            
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            bool res = voucherNegocio.Asociar(idCliente, codigoVoucher, idArticulo);
            if (res)
            {
                Response.Redirect("Aprobado.aspx", false);
            }
            else
            {
                Session.Add("error", "No se pudo completar la operacion");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void textDni_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = clienteNegocio.GetCliente(textDni.Text);
            if (cliente == null)
            {
                textNombre.Text = string.Empty;
                textApellido.Text = string.Empty;
                textEmail.Text = string.Empty;
                textCiudad.Text = string.Empty;
                textDireccion.Text = string.Empty;
                textCP.Text = string.Empty;
                Session.Add("idCliente", 0);
            }
            else
            {
                textNombre.Text = cliente.Nombre;
                textApellido.Text = cliente.Apellido;
                textEmail.Text = cliente.Email;
                textCiudad.Text = cliente.Ciudad;
                textDireccion.Text = cliente.Direccion;
                textCP.Text = cliente.CP.ToString();
                Session.Add("idCliente", cliente.Id);
            }
            

        }

        protected void checkTerminos_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = checkTerminos.Checked;
        }
    }
}