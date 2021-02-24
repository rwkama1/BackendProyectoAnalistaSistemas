using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesEnvio
{
    public class MantenimientoOE
    {
        private static MantenimientoOE _instancia = null;
        public static MantenimientoOE GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoOE();
            return _instancia;
        }
        public void agregarOrdenEnvio(OrdenEnvio addp)
        {
            FabricaDatos.GetOrdenEnvio().agregarOE(addp);
        }
        public void cambiarestado(OrdenEnvio addp)
        {
            FabricaDatos.GetOrdenEnvio().cambiarEstado(addp);
        }
    }
   
  

}
