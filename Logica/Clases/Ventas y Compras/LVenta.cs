using Logica.Clases.GestionProductos;
using Logica.Clases.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
    public class LVenta
    {

        int IdV;
        DateTime FechaV;
        DateTime VencimientoV;
        long TarjetaV;
        string MetodoPagoV;
        decimal ImpuestosV;
        int? cliente;
        decimal SubtotalV;
        decimal TotalV;
        string FormaEntregaV;
        string EstadoV;
        LPagoTarjeta lPago;
        List<LLineaVenta> LineaVenta;

        public int IdV1 { get => IdV; set => IdV = value; }
        public DateTime FechaV1 { get => FechaV; set => FechaV = value; }
        public DateTime VencimientoV1 { get => VencimientoV; set => VencimientoV = value; }
        public long TarjetaV1 { get => TarjetaV; set => TarjetaV = value; }
        public string MetodoPagoV1 { get => MetodoPagoV; set => MetodoPagoV = value; }
        public decimal ImpuestosV1 { get => ImpuestosV; set => ImpuestosV = value; }

        public int? Cliente { get => cliente; set => cliente = value; }
        public decimal SubtotalV1 { get => SubtotalV;
            set {
                SubtotalV = value;
                decimal impuesto = SubtotalV * .22M;
                ImpuestosV1 = impuesto;
                TotalV1 = (SubtotalV + impuesto);
            } }
        public decimal TotalV1 { get => TotalV; set => TotalV = value; }
        public string FormaEntregaV1 { get => FormaEntregaV; set => FormaEntregaV = value; }
        public string EstadoV1 { get => EstadoV; set => EstadoV = value; }
        public List<LLineaVenta> LineaVenta1 { get => LineaVenta; set => LineaVenta = value; }
        public LPagoTarjeta LPago { get => lPago; set => lPago = value; }

        public LVenta()
        {
            DateTime fechav = DateTime.Now;
            IdV1 = 0;
            SubtotalV1 = 0;
            EstadoV1 = "Abierta";
            FechaV1 = fechav;
            VencimientoV1 = fechav.AddDays(30);
            List<LLineaVenta> lineasv = new List<LLineaVenta>();
            LineaVenta1 = lineasv;
        }

        public LVenta(int idV1, DateTime fechaV1, DateTime vencimientoV1, long tarjetaV1, string metodoPagoV1, decimal impuestosV1, int? cliente, decimal subtotalV1, decimal totalV1, string formaEntregaV1, string estadoV1, List<LLineaVenta> lineaVenta1)
        {
            IdV1 = idV1;
            FechaV1 = fechaV1;
            VencimientoV1 = vencimientoV1;
            TarjetaV1 = tarjetaV1;
            MetodoPagoV1 = metodoPagoV1;
            ImpuestosV1 = impuestosV1;
            Cliente = cliente;
            SubtotalV1 = subtotalV1;
            TotalV1 = totalV1;
            FormaEntregaV1 = formaEntregaV1;
            EstadoV1 = estadoV1;
            LineaVenta1 = lineaVenta1;
        }

        public LineaVenta registrarLinea(LProducto lProducto, int cantidad)
        {

            LLineaVenta linea = new LLineaVenta();
            linea.Cantidad = cantidad;
            linea.Producto = lProducto;
            List<LLineaVenta> lineas = LineaVenta1;
            lineas.Add(linea);
            LineaVenta datoslinea = linea.getDataType();
            return datoslinea;
        }
        public void cerrarVenta()
        {
            List<LLineaVenta> lineas = LineaVenta1;
            decimal subtotal = 0;
            foreach (LLineaVenta l in lineas)
            {
                subtotal += l.Importe;
            }
          
            SubtotalV1 = subtotal;
            EstadoV1 = "Cerrada";
        }
        
        public bool tieneLineas()
        {
            List<LLineaVenta> lineas = LineaVenta1;

            bool tieneLineas = lineas.Count() > 0;

            return tieneLineas;
        }
        public decimal calcularVuelto(decimal montoEntregado)
        {
            decimal total = TotalV1;

            return montoEntregado - total;
        }
        public void cobrarEfectivo()
        {
            EstadoV1 = "Cobrada";
        }
        public void cobrarConTarjeta(long numeroTarjeta, int cedulaCliente, int cantidadCuotas)
        {
            decimal total =TotalV1;
            LPagoTarjeta pagoTarjeta = new LPagoTarjeta(numeroTarjeta, cedulaCliente, cantidadCuotas, total);
            LPago = pagoTarjeta;
            TarjetaV1 = numeroTarjeta;
            PagoTarjeta ptarj =LPago.getDataType();
            RegistroTarjeta.GetInstancia().RegistrarTarjeta(ptarj);
            EstadoV1 = "Cobrada";
        }
        public Venta getDataType()
        {
            List<LineaVenta> datosLineas = new List<LineaVenta>();

            foreach (LLineaVenta lv in LineaVenta1)
            {
                datosLineas.Add(lv.getDataType());
            }
            Venta data = new Venta(IdV1, FechaV1, VencimientoV1, MetodoPagoV1, Cliente, TarjetaV1, ImpuestosV1, SubtotalV1, TotalV1, FormaEntregaV1, EstadoV1, datosLineas);
            return data;
        }
        public Venta getDataType2()
        {
            List<LineaVenta> datosLineas = new List<LineaVenta>();

            foreach (LLineaVenta lv in LineaVenta1)
            {
                datosLineas.Add(lv.getDataType2());
            }
            Venta data = new Venta(IdV1, FechaV1, VencimientoV1, MetodoPagoV1, Cliente, TarjetaV1, ImpuestosV1, SubtotalV1, TotalV1, FormaEntregaV1, EstadoV1, datosLineas);
            return data;
        }

    }

}
