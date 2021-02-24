using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IDatosMensajes
    {
        void enviarMensaje(Mensaje addmsj);
        void responderMensaje(Mensaje msj);
        Mensaje buscarMensaje(int id);
        List<Mensaje> listarMensajesSinResponder();
        List<Mensaje> listarMensajesRespondidos(int cedula);
    }
}
