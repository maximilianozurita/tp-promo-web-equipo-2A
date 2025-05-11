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
            int idArticulo = (int)Session["idArticulo"];
            string codigoVoucher = (string)Session["codigoVoucher"];
            if(codigoVoucher == null)
            {
                Response.Redirect("Error.aspx?message=" + "No se pudo recuperar el codigo de Voucher", false);
                return;
            }
            if(idArticulo == 0) 
            {
                Response.Redirect("Error.aspx?message=" + "No se pudo recuperar el articulo", false);
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
                    Response.Redirect("Error.aspx?message=" + "No se pudo Agregar el cliente", false);
                    return;
                }
            }
            
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            bool res = voucherNegocio.Asociar(idCliente, codigoVoucher, idArticulo);
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