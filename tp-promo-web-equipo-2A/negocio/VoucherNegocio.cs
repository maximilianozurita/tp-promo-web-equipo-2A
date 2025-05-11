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
        public List<Voucher> Listar()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from VOUCHERS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher voucher = new Voucher();
                    object tempCodigo = datos.Lector["CodigoVoucher"];
                    voucher.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    if (!(datos.Lector["FechaCanje"] is DBNull)) 
                    {
                        voucher.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    }
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                    {
                        voucher.IdCliente = (int)datos.Lector["IdCliente"];
                    }
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                    {
                        voucher.IdArticulo = (int)datos.Lector["IdArticulo"];
                    }
                    lista.Add(voucher);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Asociar()
        {

            return true;
        }

        public bool EstaDisponible(string code, out string errMensaje)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
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
        }
    }
}
