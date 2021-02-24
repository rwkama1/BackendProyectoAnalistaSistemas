using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorVentaCompra
    {
        void iniciarSolicitudCompra();
        LineaCompra registrarProductoenCompra(int id, int cantidad);
        Compra cerrarSolicitudCompra(string formaentrega, string metodopago, int cliente);

        List<Compra> listarSolicitudCompras();
        Compra seleccionarCompra(int id);
        Venta aceptarSolicitud(int idcompra);
        Compra rechazarCompra(int idcompra);
       
        void iniciarVenta();
        LineaVenta registrarProductoenVenta(int id, int cantidad);
        Venta cerrarVenta(string formaentrega, string metodopago, int cliente);
        
        List<Compra> listarC();
        Compra obtenerCompra(int id);
        List<Venta> listarV();
        Venta obtenerVenta(int id);
        List<Venta> buscarVentasWebMetodoPago(string criterio);
        List<Venta> buscarVentasPersonalesMetodoPago(string criterio);
        List<Venta> buscarVentasCobradasCriterio(string criterio);
        List<Compra> listarCompraCliente(int cedula, DateTime fecha1, DateTime fecha2);
        List<Venta> listarVentaCliente(int cedula, DateTime fecha1, DateTime fecha2);
        List<Compra> listarCompraCliente(int cedula);
        List<LineaVenta> listarProductosmasVendidos();
        List<Venta> buscarVentascriterio(string criterio);

        List<Venta> listarVentasCobradasTodas();
        List<Venta> listarVentasClientes(int cedula);
        List<Venta> buscarVentasCobradastodas(string criterio);



    }
}
