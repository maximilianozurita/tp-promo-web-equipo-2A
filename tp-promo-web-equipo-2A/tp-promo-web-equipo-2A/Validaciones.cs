using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    return false;
                else
                    return true;

            }
            return false;
        }
        public static bool ValidarTipoInput(TextBox textBox)
        {
            bool valido = false;
            string valor = textBox.Text.Trim();
            string tipo = textBox.Attributes["data-titulo"].ToLower();
            switch (tipo)
            {
                case "dni":
                    valido = Regex.IsMatch(valor, @"^\d+$");
                    break;
                case "cp":
                    valido = Regex.IsMatch(valor, @"^\d+$");
                    break;

                case "nombre":
                    valido = !string.IsNullOrWhiteSpace(valor);
                    break;
                case "apellido":
                    valido = !string.IsNullOrWhiteSpace(valor);
                    break;
                case "ciudad":
                    valido = !string.IsNullOrWhiteSpace(valor);
                    break;
                case "direccion":
                    valido = !string.IsNullOrWhiteSpace(valor);
                    break;

                case "email":
                    valido = Regex.IsMatch(valor, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                    break;
            }
            return valido;
        }
        public static bool ValidarTextInputs(TextBox textBox, ref string errorMsj)
        {
            if (!validaTextoVacio(textBox))
            {
                errorMsj = "Falta ingresar " + textBox.Attributes["data-titulo"];
                return false;
            }
            if (!ValidarTipoInput(textBox))
            {
                errorMsj = textBox.Attributes["data-titulo"] + " con formato invalido.";
                return false;
            }
            return true;
        }
    }
}