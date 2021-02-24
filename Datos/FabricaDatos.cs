using Datos.Clases;
using Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FabricaDatos
    {
        public static IDatosAdmin getPAdmin()
        {
            return (DatosAdministrador.GetInstancia());
        }
        public static IDatosCadete getPCadete()
        {
            return (DatosCadete.GetInstancia());
        }
        public static IDatosCajero getPCajero()
        {
            return (DatosCajero.GetInstancia());
        }
        public static IDatosStocker getPStocker()
        {
            return (DatosStocker.GetInstancia());
        }
        public static IDatosTecnicos getPTecnicos()
        {
            return (DatosTecnicos.GetInstancia());
        }
        public static IDatosVendedor getPVendeor()
        {
            return (DatosVendedor.GetInstancia());
        }
        public static IDatosProductos getPProd()
        {
            return (DatosProductos.GetInstancia());
        }
        public static IDatosCliente getCliente()
        {
            return (DatosCliente.GetInstancia());
        }
        public static IDatosProveedor getProveedor()
        {
            return (DatosProveedor.GetInstancia());
        }
        public static IDatosMensajes GetDatosMensajes()
        {
            return (DatosMensajes.GetInstancia());
        }
        public static IDatosFCompra GetDatosFCompra()
        {
            return (DatosFCompra.GetInstancia());
        }
        public static IDatosVenta GetDatosVenta()
        {
            return (DatosVenta.GetInstancia());
        }
        public static IDatosCompra GetDatosCompra()
        {
            return (DatosCompra.GetInstancia());
        }
        public static IDatosTarjeta GetDatosTarjeta()
        {
            return (DatosTarjeta.GetInstancia());
        }
        public static IDatosOrdenTaller GetOrdenTaller()
        {
            return (DatosOrdenTaller.GetInstancia());
        }
        public static IDatosOrdenEnvio GetOrdenEnvio()
        {
            return (DatosOrdenEnvio.GetInstancia());
        }
    }
}
