using Datos;
using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
    public class RegistroVenta
    {
        private static RegistroVenta _instancia = null;
        public static RegistroVenta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new RegistroVenta();
            return _instancia;
        }
      

      

        public void RegistrarVenta(Venta v)
        {
            FabricaDatos.GetDatosVenta().agregarVenta(v);

        }
        public void cobrarVenta(Venta v)
        {
            FabricaDatos.GetDatosVenta().cobrarVenta(v);

        }
        public LVenta convertirCompraVenta(Compra com)
        {
            
            List<LLineaVenta> listlineasventa = new List<LLineaVenta>();

            foreach (LineaCompra lc in com.LineaCompra)
            {
                LLineaVenta lineaventa = new LLineaVenta();
              
                lineaventa.Idv = lc.IdC;
                lineaventa.Idlv = lc.IdLC;
                lineaventa.Impdato = lc.ImporteLC;
                lineaventa.Producto.Id = lc.ProductoLC;
                //lineaventa.Producto.Precio = prod.PrecioProd;
                lineaventa.Cantidad = lc.CantidadLC;
                listlineasventa.Add(lineaventa);

            }
            DateTime fechav = DateTime.Now;
            
            LVenta lventa = new LVenta();
            lventa.IdV1 = com.IdC;
            lventa.FechaV1 = fechav;
            lventa.VencimientoV1 = fechav.AddDays(30);
            lventa.MetodoPagoV1 = com.MetodoPagoC;
            lventa.ImpuestosV1 = com.ImpuestosC;
            lventa.Cliente = com.ClienteC;
            lventa.SubtotalV1 = com.SubtotalC;
            lventa.TarjetaV1 =0;
            lventa.TotalV1 = com.TotalC;
            lventa.FormaEntregaV1 = com.FormaEntregaC;
            lventa.EstadoV1 = "Abierta";
            lventa.LineaVenta1 = listlineasventa;
            return lventa;
        }


    }
}
