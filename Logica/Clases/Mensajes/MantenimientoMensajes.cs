using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Mensajes
{
    public class MantenimientoMensajes
    {
        private static MantenimientoMensajes _instancia = null;
        private MantenimientoMensajes() { }
        public static MantenimientoMensajes GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoMensajes();
            return _instancia;
        }
        public void enviarMensaje(Mensaje msj)
        {
            FabricaDatos.GetDatosMensajes().enviarMensaje(msj);
        }
        public void recibirMensaje(Mensaje msj)
        {
            FabricaDatos.GetDatosMensajes().responderMensaje(msj);
        }
    }
}
