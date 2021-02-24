using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
    public class LLineaCompra
    {

        decimal imp;
     
        int cantidad;
        int idlc;
        int idc;
        int idprod;
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

        public int Idlc { get => idlc; set => idlc = value; }
        public int Idc { get => idc; set => idc = value; }
        public int Idprod { get => idprod; set => idprod = value; }
    

        public LLineaCompra(int cantidad, LProducto producto)
        {
            Cantidad = cantidad;
            Producto = producto;
        }

        public LLineaCompra(int cantidad, decimal importe, int idlc, int idc, int idprod)
        {
            Cantidad = cantidad;
             Importe = importe;
            Idlc = idlc;
            Idc = idc;
            Idprod = idprod;
        }

        public LLineaCompra()
        {
           
           LProducto prod = new LProducto();
            Producto = prod;
        }

        public LineaCompra getDataType()
        {
            LineaCompra dtlineacompra = new LineaCompra();

            dtlineacompra.ProductoLC = Producto.Id;
            dtlineacompra.IdC = Idc;
            dtlineacompra.IdLC = Idlc;
            dtlineacompra.PrecioprodLC = Producto.Precio;
            dtlineacompra.ImporteLC = Importe;
            dtlineacompra.CantidadLC = Cantidad;
          

            return dtlineacompra;
        }
    }
}
