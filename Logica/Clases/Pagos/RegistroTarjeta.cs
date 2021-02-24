using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Pagos
{
    public class RegistroTarjeta
    {
        private static RegistroTarjeta _instancia = null;
        public static RegistroTarjeta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new RegistroTarjeta();
            return _instancia;
        }
        public void RegistrarTarjeta(PagoTarjeta tj)
        {
            FabricaDatos.GetDatosTarjeta().agregarTarjeta(tj);

        }
    }
}
