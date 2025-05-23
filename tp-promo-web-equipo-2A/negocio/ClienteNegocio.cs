﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {

        public Cliente GetCliente(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "select * from CLIENTES where Documento = @documento";
                datos.setearConsulta(query);
                datos.setearParametros("@documento", dni);
                datos.ejecutarLectura();
                datos.Lector.Read();
                if (!datos.Lector.HasRows)
                {
                    return null;
                }
                Cliente cliente = new Cliente();
                cliente.Documento = (string)datos.Lector["Documento"];
                cliente.Email = (string)datos.Lector["Email"];
                cliente.Nombre = (string)datos.Lector["Nombre"];
                cliente.Apellido = (string)datos.Lector["Apellido"];
                cliente.Direccion = (string)datos.Lector["Direccion"];
                cliente.Ciudad = (string)datos.Lector["Ciudad"];
                cliente.CP = (int)datos.Lector["CP"];
                cliente.Id = (int)datos.Lector["Id"];
                return cliente;
            }
            catch
            {
                return null;
            }

            finally { datos.cerrarConexion(); }
        }
        public int SetCliente(Cliente cliente)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = @"insert into CLIENTES (Documento, Email, Nombre, Apellido, Direccion, Ciudad, CP) 
                        values (@documento, @email, @nombre, @apellido, @direccion, @ciudad, @CP);
                        select scope_identity();";
                datos.setearConsulta(query);
                datos.setearParametros("@documento", cliente.Documento);
                datos.setearParametros("@email", cliente.Email);
                datos.setearParametros("@nombre", cliente.Nombre);
                datos.setearParametros("@apellido", cliente.Apellido);
                datos.setearParametros("@direccion", cliente.Direccion);
                datos.setearParametros("@ciudad", cliente.Ciudad);
                datos.setearParametros("@cp", cliente.CP);
                int idCliente = datos.ejecutarAccionAndReturnId();
                return idCliente;
            }
            catch
            {
                return 0;
            }

            finally { datos.cerrarConexion(); }
        }

    }
}
