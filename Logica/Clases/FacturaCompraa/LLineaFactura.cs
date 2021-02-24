using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica.Clases.FacturaCompraa
{
    public class LLineaFactura
    {
       
        decimal imp;
        int cantidad;
     
        LProducto producto;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public LProducto Producto { get => producto; set => producto = value; }
        public decimal Importe
        {
            get
            {
                int ccantidad = Cantidad;
                LProducto prod = Producto;
                decimal preciounitario = prod.Precio;
               imp = ccantidad * preciounitario;
                return imp;
            }
            set { imp = value; }
        }

        

        public LLineaFactura(int cantidad, LProducto producto)
        {
            Cantidad = cantidad;
            Producto = producto;
        }

        public LLineaFactura()
        {
        }

        public LineaFacturaCompra getDataType()
        {
            LineaFacturaCompra dtlineafactura = new LineaFacturaCompra();
           
            dtlineafactura.ProductoLFC = Producto.Id;
            
            dtlineafactura.ImporteLFC= Importe;
            dtlineafactura.CantidadLFC = Cantidad;

            return dtlineafactura;
        }
    }
    
}
