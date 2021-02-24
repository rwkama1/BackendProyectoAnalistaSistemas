using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
    public class LCompra
    {
       
        int IdC;
        DateTime FechaC;
        string MetodoPagoC;
        decimal ImpuestosC;
        Nullable<int> cliente;
        decimal SubtotalC;
        decimal TotalC;
        string FormaEntregaC;
         string EstadoC;
        List<LLineaCompra> LineaCompra;

        public int IdC1 { get => IdC; set => IdC = value; }
        public DateTime FechaC1 { get => FechaC; set => FechaC = value; }
        public string MetodoPagoC1 { get => MetodoPagoC; set => MetodoPagoC = value; }
        public decimal ImpuestosC1 { get => ImpuestosC; set => ImpuestosC = value; }
        public decimal SubtotalC1 { get => SubtotalC;
                    set
                        {
                       SubtotalC = value;
                       decimal impuesto = SubtotalC * .22M;
                       ImpuestosC1 = impuesto;
                       TotalC1=(SubtotalC + impuesto);
                        }
        }
        public decimal TotalC1 { get => TotalC; set => TotalC = value; }
        public string FormaEntregaC1 { get => FormaEntregaC; set => FormaEntregaC = value; }
        public string EstadoC1 { get => EstadoC; set => EstadoC = value; }
        public List<LLineaCompra> LineaCompra1 { get => LineaCompra; set => LineaCompra = value; }
        public Nullable<int> Cliente { get => cliente; set => cliente = value; }

        public LCompra()
        {
            IdC1 = 0;
            EstadoC1 = "Abierta";
            SubtotalC1 = 0;
            List<LLineaCompra> lineasc = new List<LLineaCompra>();
            LineaCompra1 = lineasc;
        }

        public LCompra(int idC1, DateTime fechaC1, string metodoPagoC1, decimal impuestosC1, decimal subtotalC1, decimal totalC1, string formaEntregaC1, string estadoC1, List<LLineaCompra> lineaCompra1, int? cliente)
        {
            IdC1 = idC1;
            FechaC1 = fechaC1;
            MetodoPagoC1 = metodoPagoC1;
            ImpuestosC1 = impuestosC1;
            SubtotalC1 = subtotalC1;
            TotalC1 = totalC1;
            FormaEntregaC1 = formaEntregaC1;
            EstadoC1 = estadoC1;
            LineaCompra1 = lineaCompra1;
            Cliente = cliente;
        }

        public LineaCompra registrarLinea(LProducto lProducto, int cantidad)
        {
            LLineaCompra linea = new LLineaCompra();
            linea.Cantidad = cantidad;
            linea.Producto = lProducto;
            List<LLineaCompra> lineas = LineaCompra1;
            lineas.Add(linea);
            LineaCompra datoslinea = linea.getDataType();
            return datoslinea;
        }
        public void cerrarCompra()
        {
            List<LLineaCompra> lineas = LineaCompra1;
            decimal subtotal = 0;
            foreach (LLineaCompra l in lineas)
            {
                subtotal += l.Importe;
            }
            SubtotalC1 = subtotal;
            FechaC1 = DateTime.Now;
            EstadoC1 = "Pendiente";
        }
        public bool tieneLineas()
        {
            List<LLineaCompra> lineas = LineaCompra1;

            bool tieneLineas = lineas.Count() > 0;

            return tieneLineas;
        }
        public Compra getDataType()
        {
            List<LineaCompra> datosLineas = new List<LineaCompra>();

            foreach (LLineaCompra lv in LineaCompra1)
            {
                datosLineas.Add(lv.getDataType());
            }
            Compra datafc = new Compra();
            datafc.IdC = IdC1;
            datafc.FechaC = FechaC1;
            datafc.MetodoPagoC = MetodoPagoC1;
            datafc.ImpuestosC = ImpuestosC1;
            datafc.SubtotalC = SubtotalC1;
            datafc.ClienteC =Cliente ;
            datafc.TotalC = TotalC1;
            datafc.FormaEntregaC = FormaEntregaC1;
            datafc.EstadoC = EstadoC1;
            datafc.LineaCompra = datosLineas;
            return datafc;
        }
       
         

    }
}
