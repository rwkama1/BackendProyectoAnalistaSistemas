using Logica.Clases;
using Logica.Clases.FacturaCompraa;
using Logica.Clases.GestionProductos;
using Logica.Clases.GestionProveedor;
using Logica.Clases.GestionUsuarios;
using Logica.Clases.MantenimietoCliente;
using Logica.Clases.Mensajes;
using Logica.Clases.OrdenesEnvio;
using Logica.Clases.OrdenesTaller;
using Logica.Clases.Pagos;
using Logica.Clases.Ventas_y_Compras;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static IAutenticacion getLUsuario()
        {
            return (Autenticacion.GetInstancia());
        }

        public static IControladorPago GetControladorPago()
        {
            return (ControladorPago.GetInstancia());
        }
        public static IControladorVentaCompra GetControladorVentaCompra()
        {
            return (ControladorVentaCompra.GetInstancia());
        }
        public static IControladorUsuario getControladorUsuario()
        {
            return (ControladorUsuario.GetInstancia());
        }
        public static IControladorProducto getConProd()
        {
            return (ControladorProducto.GetInstancia());
        }
        public static IControladorProveedor getconProveedor()
        {
            return (ControladorProveedor.GetInstancia());
        }
        public static IControladorCliente GetControladorCliente()
        {
            return (ControladorCliente.GetInstancia());
        }
        public static IControladorMensajes GetControladorMensajes()
        {
            return (ControladorMensajes.GetInstancia());
        }
        public static IControladorFC GetControladorFC()
        {
            return (ControladorFC.GetInstancia());
        }
        public static IControladorOT GetControladorOT()
        {
            return (ControladorOT.GetInstancia());
        }
        public static IControladorOE GetControladorOE()
        {
            return (ControladorOE.GetInstancia());
        }

    }
}
