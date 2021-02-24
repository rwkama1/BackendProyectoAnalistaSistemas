using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
   public abstract class  EstadoOrdenTaller
    {
        public virtual void cambiarPresupuestada(string estado, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
    }
        public virtual void cambiarNoReparable(string estado, string comentario, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
}
        public virtual void reparadaAunTaller(decimal precio, string comentario, string estado, LOrdenTaller lorden)
{
    throw new Exception("No disponible");
}
        public virtual void cambiarNoRep(string estado, string comentario, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
        }
        public virtual void cambiarAceptada(decimal precio, string comentario, string estado, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
        }
        public virtual void cambiarRechazada(string estado, string comentario, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
        }
        public virtual void cambiarPagada(string comentario, string estado, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
        }
        public virtual void cambiarRetirada(string comentario, string estado, LOrdenTaller lorden)
        {
            throw new Exception("No disponible");
        }



    }
}
