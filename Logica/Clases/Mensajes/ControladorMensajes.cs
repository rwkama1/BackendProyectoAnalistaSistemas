using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Mensajes
{
    public class ControladorMensajes:IControladorMensajes
    {
        private static ControladorMensajes _instancia = null;
        private ControladorMensajes() { }
        public static ControladorMensajes GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorMensajes();
            return _instancia;
        }
        public Mensaje buscarMensaje(int id)
        {
            Mensaje listp = CatalogoMensajes.GetInstancia().obtMensaje(id);

            return listp;
        }
        public bool enviarMensaje(Mensaje msj)
        {
            bool correcto = true;
            MantenimientoMensajes.GetInstancia().enviarMensaje(msj);
            return correcto;

        }
        public bool responderMensaje(Mensaje msj)
        {
            bool correcto = true;
            MantenimientoMensajes.GetInstancia().recibirMensaje(msj);
            return correcto;
        }
        public List<Mensaje> listarMensajesSinResponder()
        {
            List<Mensaje> listp = CatalogoMensajes.GetInstancia().listarMensajesSinResponder();

            return listp;
        }
        public List<Mensaje> listarMensajesRespondidos(int cedula)
        {
            List<Mensaje> listp = CatalogoMensajes.GetInstancia().listarMensajesRespondidos(cedula);

            return listp;
        }
    }

}
