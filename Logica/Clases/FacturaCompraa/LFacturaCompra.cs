using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.FacturaCompraa
{
    public class LFacturaCompra
    {
        
        int idfc;
        string numerofc;
        string provfc;
      
        DateTime fechac;
        decimal impuestosfc;
        decimal subtotalfc;
        decimal totalfc;
        List<LLineaFactura> lineasfc;

        public int IdFC { get { return idfc; } set { idfc = value; } }
        public string NumeroFC { get { return numerofc; } set { numerofc = value; } }
        public string ProvFC { get { return provfc; } set { provfc = value; } }
        public System.DateTime FechaFC { get { return fechac; } set { fechac = value; } } 
        public decimal ImpuestosFC { get { return impuestosfc; } set { impuestosfc = value; } }
        public decimal SubtotalFC { get { return subtotalfc; }
                set {
                subtotalfc = value;
                decimal impuesto = subtotalfc * .22M ;
                ImpuestosFC = impuesto;
                TotalFC=(subtotalfc+ impuesto)
                                                            ; } }
        public decimal TotalFC { get { return totalfc; } set { totalfc = value; } }
        public List<LLineaFactura> LineasFC { get { return lineasfc; } set { lineasfc = value; } }

      

        public LFacturaCompra()
        {
            IdFC = 0;
            NumeroFC = "";
            ProvFC = "";
            FechaFC = DateTime.Now;
            SubtotalFC = 0;
            List<LLineaFactura> lineasfc=new List<LLineaFactura>();
            LineasFC = lineasfc;
        }
        public LineaFacturaCompra registrarLinea(LProducto lProducto, int cantidad)
        {
            
            LLineaFactura linea = new LLineaFactura();
            //lProducto.Stock = linea.Smstock;
            linea.Cantidad = cantidad;
            linea.Producto = lProducto;
            List<LLineaFactura> lineas = LineasFC;
            lineas.Add(linea);
            LineaFacturaCompra datoslineafactura = linea.getDataType();
            return datoslineafactura;
        }
        public void cerrarFactura()
        {
            List<LLineaFactura> lineas =LineasFC;
            decimal subtotal = 0;
            foreach (LLineaFactura l in lineas)
            {
                subtotal += l.Importe;
            }
            SubtotalFC = subtotal;
        }
        public FacturaCompra getDataType()
        {
            List<LineaFacturaCompra> datosLineas = new List<LineaFacturaCompra>();

            foreach (LLineaFactura lv in LineasFC)
            {
                datosLineas.Add(lv.getDataType());
            }
            FacturaCompra datafc = new FacturaCompra();
            datafc.IdFC = IdFC;
            datafc.NumeroFC = NumeroFC;
            datafc.FechaFC = FechaFC;
            datafc.ProvFC = ProvFC;
            datafc.SubtotalFC = SubtotalFC;
            datafc.ImpuestosFC = ImpuestosFC;
            datafc.TotalFC = TotalFC;
            datafc.Listalineas = datosLineas;
            return datafc;
        }
    }
    
}
