using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
   public class RegistroCompra
    {
        private static RegistroCompra _instancia = null;
        public static RegistroCompra GetInstancia()
        {
            if (_instancia == null)
                _instancia = new RegistroCompra();
            return _instancia;
        }




        public void RegistrarCompra(Compra v)
        {
            FabricaDatos.GetDatosCompra().agregarCompra(v);

        }
        public void aceptarCompra(int id)
        {
            FabricaDatos.GetDatosCompra().aceptarCompra(id);

        }
        public void rechazarCompra(int id)
        {
            FabricaDatos.GetDatosCompra().rechazarCompra(id);

        }
    }
}
