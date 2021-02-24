using Datos;
using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
   public class CatalogoCompra
    {
        private static CatalogoCompra _instancia = null;
        public static CatalogoCompra GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoCompra();
            return _instancia;
        }


        public Compra obtenerCompra(int numero)
        {
            Compra pr = null;
            pr = FabricaDatos.GetDatosCompra().obtenerCompra(numero);
            return pr;
        }
        public List<Compra> listarCompra()
        {
            List<Compra> lv = new List<Compra>();
            lv = FabricaDatos.GetDatosCompra().listarCompra();

            return lv;

        }
        public List<Compra> listarComprasPendientes()
        {
            List<Compra> lv = new List<Compra>();
            lv = FabricaDatos.GetDatosCompra().listarCompraPendientes();

            return lv;

        }
        public List<Compra> ListarComprasFechas(int cedula, DateTime fecha1, DateTime fecha2)
        {
            List<Compra> lv = FabricaDatos.GetDatosCompra().listarCompraCliente(cedula,fecha1,fecha2);
            return lv;
        }
        public List<Compra> listarCompraClientee(int cedula)
        {
            return FabricaDatos.GetDatosCompra().listarCompraClientee(cedula);
        }

    }
}
