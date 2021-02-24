using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica.Clases.Ventas_y_Compras
{
    public class LLineaVenta
    {

        decimal imp;
        
        int cantidad;
        int idlv;
        int idv;
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

        public int Idlv { get => idlv; set => idlv = value; }
        public int Idv { get => idv; set => idv = value; }
        public decimal Impdato { get; set; }
        public LLineaVenta(int cantidad, LProducto producto)
        {
            Cantidad = cantidad;
            Producto = producto;
        }

        public LLineaVenta()
        {
            LProducto prod = new LProducto();
            Producto = prod;
        }

        public LineaVenta getDataType()
        {
            LineaVenta dtlineaV = new LineaVenta();
            dtlineaV.ProductoLV = Producto.Id;
            dtlineaV.IdV = Idv;
            dtlineaV.IdLV = Idlv;
           
            dtlineaV.PrecioprodV = Producto.Precio;
           
            dtlineaV.ImporteLV = Importe;
          
            dtlineaV.CantidadLV = Cantidad;
            
            return dtlineaV;
        }
        public LineaVenta getDataType2()
        {
            LineaVenta dtlineaV = new LineaVenta();
            dtlineaV.ProductoLV = Producto.Id;
            dtlineaV.IdLV = Idlv;
            dtlineaV.IdV = Idv;
            dtlineaV.ImporteLV = Impdato;
            dtlineaV.PrecioprodV = Producto.Precio;
            dtlineaV.CantidadLV = Cantidad;
            return dtlineaV;
        }
    }
    
}
