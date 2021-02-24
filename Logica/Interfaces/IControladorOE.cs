using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorOE
    {
        //Agregar Orden Envio
        List<Venta> listarVentasCobradas();
        Venta seleccionarVenta(int idventa);
        OrdenEnvio agregarOrdenEnvio(long cadete, int cliente, int idventa, string destino,string localidad);
        //Cambiar estado Orden Envio
        List<OrdenEnvio> listarOrdenEnvioPendientes();
        OrdenEnvio seleccionarOrdenEnvio(int id);
        void cambiarEstado(OrdenEnvio orden);
        List<OrdenEnvio> listarOrdenEnvioCliente(int cliente);
        List<OrdenEnvio> listarOrdenEnvioCadete(long cadete);
    }
}
