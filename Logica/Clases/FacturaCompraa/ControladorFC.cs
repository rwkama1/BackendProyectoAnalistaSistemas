using Datos;
using Logica.Clases.GestionProductos;
using Logica.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.FacturaCompraa
{
    public class ControladorFC : IControladorFC
    {
        private static ControladorFC _instancia = null;
        private ControladorFC() { }
        public static ControladorFC GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorFC();
            return _instancia;
        }
        LFacturaCompra lfacturacompra;
      
        internal LFacturaCompra Lfacturacompra { get => lfacturacompra; set => lfacturacompra = value; }



        public FacturaCompra iniciarIngresoFactura(string numero, DateTime fecha, string prov)
        {
            FacturaCompra fc = CatalogoFC.GetInstancia().obtenerFCProv(numero,prov);
            if (fc == null)
            { 
          
            LFacturaCompra logicafc = new LFacturaCompra();
            logicafc.NumeroFC = numero;
            logicafc.FechaFC = fecha;
            logicafc.ProvFC = prov;
            Lfacturacompra = logicafc;
             }
            return fc;
           
         

        }
        //public List<Producto> listProductos()
        //{
        //    List<Producto> listp = CatalogoProductos.GetInstancia().listprod();

        //    return listp;
        //}
        public LineaFacturaCompra registrarProductoenFactura(int id, int cantidad)
        {
            LineaFacturaCompra datoslineaFactura = null;
           
            LFacturaCompra lfc = Lfacturacompra;

            if (lfc != null && id >= 1 && cantidad >= 1)
            {

                LProducto articulo = CatalogoProductos.GetInstancia().obtProdL(id);

                if (articulo != null)
                {
                    datoslineaFactura = lfc.registrarLinea(articulo, cantidad);
               
                     

                }

            }
            return datoslineaFactura;

        }
        public FacturaCompra cerrarIngresoFactura()
        {
            FacturaCompra datafacturaCompra = null;

            LFacturaCompra facturacompra = Lfacturacompra;

            if (facturacompra != null)
            {
                facturacompra.cerrarFactura();
               

                datafacturaCompra = facturacompra.getDataType();
                RegistroFacturaCompra.GetInstancia().RegistrarFactura(datafacturaCompra);
                Lfacturacompra = null;


            }

            return datafacturaCompra;
        }
        public List<FacturaCompra> listarFC()
        {
            List<FacturaCompra> listp = CatalogoFC.GetInstancia().listarFC();

            return listp;
        }
    }
}


