using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public bool Asociar(int idCliente, string idVoucher, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta(
                    "update Vouchers set " +
                    "IdCliente=@IdCliente , " +
                    "IdArticulo=@idArticulo ,"+
                    "FechaCanje = (GETDATE())" +
                    "where " +
                    "CodigoVoucher=@codigoVoucher;");
           
                datos.setearParametros("@idCliente", idCliente);
                datos.setearParametros("@codigoVoucher", idVoucher);
                datos.setearParametros("@idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return true;
        }

        public bool EstaDisponible(string code, out string errMensaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "select * from VOUCHERS where CodigoVoucher = @codigo";
                datos.setearConsulta(query);
                datos.setearParametros("@codigo", code);
                datos.ejecutarLectura();
                datos.Lector.Read();
                if (!datos.Lector.HasRows)
                {
                    errMensaje = "Codigo de Voucher No existe";
                    return false;
                }
                if (!(datos.Lector["IdCliente"] is DBNull))
                {
                    errMensaje = "El Voucher ya fue utilizado";
                    return false;
                }
                errMensaje = string.Empty;
                return true;
            }
            catch (Exception ex)
            {

                errMensaje = "Error Interno : " + ex.Message;
                return false;
            }

            finally {  datos.cerrarConexion(); }
        }
    }
}
