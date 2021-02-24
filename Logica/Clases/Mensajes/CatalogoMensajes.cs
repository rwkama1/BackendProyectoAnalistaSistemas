using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Mensajes
{
   public  class CatalogoMensajes
    {
        private static CatalogoMensajes _instancia = null;
        public static CatalogoMensajes GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoMensajes();
            return _instancia;
        }
        private List<Mensaje> lmsj;
        public List<Mensaje> LMsj { get { return lmsj; } }
     
        public List<Mensaje> listarMensajesRespondidos(int cedula)
        {
            lmsj = new List<Mensaje>();
            lmsj = FabricaDatos.GetDatosMensajes().listarMensajesRespondidos( cedula);

            return lmsj;
        }
        public List<Mensaje> listarMensajesSinResponder()
        {
            lmsj = new List<Mensaje>();
            lmsj = FabricaDatos.GetDatosMensajes().listarMensajesSinResponder();

            return lmsj;
        }
        public Mensaje obtMensaje(int id)
        {
            Mensaje pr = null;
            pr = FabricaDatos.GetDatosMensajes().buscarMensaje(id);
            return pr;
        }
    }
}
