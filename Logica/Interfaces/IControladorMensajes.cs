using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorMensajes
    {
        bool enviarMensaje(Mensaje msj);
        bool responderMensaje(Mensaje msj);
        List<Mensaje> listarMensajesSinResponder();
        List<Mensaje> listarMensajesRespondidos(int cedula);
        Mensaje buscarMensaje(int id);


    }
}
