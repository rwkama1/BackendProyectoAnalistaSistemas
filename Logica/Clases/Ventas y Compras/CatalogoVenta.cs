using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
    public class CatalogoVenta
    {
        private static CatalogoVenta _instancia = null;
        public static CatalogoVenta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoVenta();
            return _instancia;
        }
     
       
        public Venta obtenerVenta(int numero)
        {
            Venta pr = null;
          
           
                pr = FabricaDatos.GetDatosVenta().obtenerVenta(numero);
               
            
          
            return pr;
        }
        public LVenta obtenerLVenta(Venta venta)
        {

            List<LLineaVenta> listlineasventa = new List<LLineaVenta>();

            foreach (LineaVenta lc in venta.LineaVenta)
            {
                LLineaVenta lineaventa = new LLineaVenta();

                lineaventa.Idv = lc.IdV;
                lineaventa.Idlv = lc.IdLV;
                lineaventa.Impdato = lc.ImporteLV;
                lineaventa.Producto.Id = lc.ProductoLV;
                lineaventa.Cantidad = lc.CantidadLV;
                listlineasventa.Add(lineaventa);

            }
           

            LVenta lventa = new LVenta();
            lventa.IdV1 = venta.IdV;
            lventa.FechaV1 = venta.FechaV;
            lventa.VencimientoV1 =venta.VencimientoV;
            lventa.MetodoPagoV1 = venta.MetodoPagoV;
            lventa.ImpuestosV1 = venta.ImpuestosV;
            lventa.Cliente = venta.ClienteV;
            lventa.SubtotalV1 = venta.SubtotalV;
            lventa.TotalV1 = venta.TotalV;
            lventa.FormaEntregaV1 = venta.FormaEntregaV;
            lventa.EstadoV1 = venta.EstadoV;
            lventa.LineaVenta1 = listlineasventa;
            return lventa;
        }
        public List<Venta> listarVenta()
        {
            List<Venta> lv = new List<Venta>();
            lv = FabricaDatos.GetDatosVenta().listarVenta();

            return lv;

        }
        public List<Venta> listarVentaPersonal()
        {
            List<Venta> lv = new List<Venta>();
            lv = FabricaDatos.GetDatosVenta().listarVentasPersonales();

            return lv;

        }
        public List<Venta> listarVentaWeb()
        {
            List<Venta> lv = new List<Venta>();
            lv = FabricaDatos.GetDatosVenta().listarVentasWeb();

            return lv;

        }
        public List<Venta> buscarVentasWebMetodoPago(string criterio)
        {
            return FabricaDatos.GetDatosVenta().buscarVentasWebMetodoPago(criterio);
        }
        public List<Venta> buscarVentasPersonalesMetodoPago(string criterio)
        {
            return FabricaDatos.GetDatosVenta().buscarVentasPersonalesMetodoPago(criterio);
        }
        public List<Venta> listarVentasCobradas()
        {

            return FabricaDatos.GetDatosVenta().listarVentasCobradas();
        }
        public List<Venta> buscarVentasCobradasCriterio(string criterio)
        {

            return FabricaDatos.GetDatosVenta().buscarVentasCobradas(criterio);
        }
        public List<Venta> listarVentaFechas(int cedula, DateTime fecha1, DateTime fecha2)
        {
            return FabricaDatos.GetDatosVenta().listarVentaFechas(cedula, fecha1, fecha2);
        }
        public List<LineaVenta> listarProductosmasVendidos()
        {
            return FabricaDatos.GetDatosVenta().listarProductosmasVendidos();
        }
        public List<Venta> buscarVentascriterio(string criterio)
        {
            return FabricaDatos.GetDatosVenta().buscarVentascriterio(criterio);
        }

        public List<Venta> listarVentasCobradasTodas()
        {
            return FabricaDatos.GetDatosVenta().listarVentasCobradasTodas();
        }
        public List<Venta> listarVentasClientes(int cedula)
        { return FabricaDatos.GetDatosVenta().listarVentasClientes(cedula); }
        public List<Venta> buscarVentasCobradastodas(string criterio)
         { return FabricaDatos.GetDatosVenta().buscarVentasCobradastodas(criterio);  }



    }
}
