using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.MantenimietoCliente
{
    public class MantenimientoCliente
    {
        private static MantenimientoCliente _instancia = null;

        public static MantenimientoCliente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoCliente();
            return _instancia;
        }
        public void addcli(Cliente addp)
        {
            FabricaDatos.getCliente().agregarCliente(addp);
        }
        public void modcli(Cliente modcli)
        {
            FabricaDatos.getCliente().modificarCliente(modcli);
        }
    }
}
