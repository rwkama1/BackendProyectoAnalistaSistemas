using Logica.Clases.Ventas_y_Compras;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesEnvio
{
    internal class ControladorOE : IControladorOE
    {
        private static ControladorOE _instancia = null;
        private ControladorOE() { }
        public static ControladorOE GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorOE();
            return _instancia;
        }
        LOrdenEnvio controladorordenvio;

        public LOrdenEnvio Controladorordenvio { get => controladorordenvio; set => controladorordenvio = value; }

        public List<Venta> listarVentasCobradas()
        {
            return CatalogoVenta.GetInstancia().listarVentasCobradas
();

        }
        public Venta seleccionarVenta(int idventa)
        {
            Venta data = CatalogoVenta.GetInstancia().obtenerVenta(idventa);
            if (data != null)
            {

                LOrdenEnvio lOrdenEnvio = CatalogoOE.GetInstancia().obtenerProductoOrdenEnvio(data);
                Controladorordenvio = lOrdenEnvio;
            }
            return data;


        }
        public OrdenEnvio agregarOrdenEnvio(long cadete,int cliente,int idventa,string destino,string localidad)
        {
            LOrdenEnvio lordenenvio = Controladorordenvio;
            lordenenvio.CadeteOE = cadete;
            lordenenvio.Clienteoe = cliente;
            lordenenvio.VentaOE = idventa;
            lordenenvio.UbicacionOE = destino;
            lordenenvio.LocalidadOE = localidad;
            OrdenEnvio ot = lordenenvio.getDataType();
            MantenimientoOE.GetInstancia().agregarOrdenEnvio(ot);
            Controladorordenvio = null;
            return ot;
        }

        public List<OrdenEnvio> listarOrdenEnvioPendientes()
        {
            return CatalogoOE.GetInstancia().listarOrdenEnvioPendiente();


        }
        public OrdenEnvio seleccionarOrdenEnvio(int id)
        {
            return CatalogoOE.GetInstancia().buscarOE(id);
        }
        public void cambiarEstado(OrdenEnvio orden)
        {
            MantenimientoOE.GetInstancia().cambiarestado(orden);
        }
        public List<OrdenEnvio> listarOrdenEnvioCadete(long cadete)
        {
            return CatalogoOE.GetInstancia().listarOrdenEnvioCadete(cadete);
        }
        public List<OrdenEnvio> listarOrdenEnvioCliente(int cliente)
        {
            return CatalogoOE.GetInstancia().listarOrdenEnvioCliente(cliente);
        }
    }
}
