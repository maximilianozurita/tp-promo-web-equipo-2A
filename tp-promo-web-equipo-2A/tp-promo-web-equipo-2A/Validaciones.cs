using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace negocio
{
    public static class Validacion
    {

        public static bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;

            }
            return false;
        }

        public static void setearEstiloValidacion(HtmlGenericControl div, TextBox textBox)
        {
            div.Attributes["class"] = "invalid-feedback";
            textBox.CssClass = "form-control is-invalid";
        }

        public static bool setearEstiloValidacion(TextBox textBox, HtmlGenericControl div)
        {
            if(validaTextoVacio(textBox))
            {
                div.Attributes["class"] = "invalid-feedback";
                textBox.CssClass = "form-control is-invalid";
                return false;
            }
            else 
            {
                div.Attributes["class"] = "invalid-feedback visually-hidden";
                textBox.CssClass = "form-control";
                return true;
            }
        }

    }
}