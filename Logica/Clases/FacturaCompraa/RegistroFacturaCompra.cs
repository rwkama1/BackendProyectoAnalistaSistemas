using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.FacturaCompraa
{
    public class RegistroFacturaCompra
    {
        private static RegistroFacturaCompra _instancia = null;
        public static RegistroFacturaCompra GetInstancia()
        {
            if (_instancia == null)
                _instancia = new RegistroFacturaCompra();
            return _instancia;
        }
      

      

        public void RegistrarFactura(FacturaCompra v)
        {
            FabricaDatos.GetDatosFCompra().agregarFacturaCompra(v);

        }
       
        //public void ActualizarFactura(FacturaCompra f)
        //{
        //    FabricaDatos.GetDatosFCompra().actualizarDatosFC(f);
        //}
        //public void RegistrarLineaFactura(LineaFacturaCompra lf,string numero)
        //{
        //    FabricaDatos.GetDatosFCompra().registrarLineaFactura(lf,numero);
        //}
        //public void ActualizarStock(LineaFacturaCompra st)
        //{
        //    FabricaDatos.GetDatosFCompra().actualizarStock(st);
        //}
       
    }
}
