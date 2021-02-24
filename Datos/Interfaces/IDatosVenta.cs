using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IDatosVenta
    {
        List<Venta> listarVenta();
        Venta obtenerVenta(int id);
        void agregarVenta(Venta addp);
        List<Venta> listarVentasPersonales();
        List<Venta> listarVentasCobradas();
        List<Venta> listarVentaFechas(int cedula, DateTime fecha1, DateTime fecha2); 
         List<Venta> listarVentasWeb();
        List<Venta> buscarVentasPersonalesMetodoPago(string criterio);
        List<Venta> buscarVentasWebMetodoPago(string criterio);
        void cobrarVenta(Venta addp);
        List<Venta> buscarVentasCobradas(string criterio);
        List<LineaVenta> listarProductosmasVendidos();
        List<Venta> buscarVentascriterio(string criterio);
        List<Venta> listarVentasCobradasTodas();
        List<Venta> listarVentasClientes(int cedula);
        List<Venta> buscarVentasCobradastodas(string criterio);
    }
}
