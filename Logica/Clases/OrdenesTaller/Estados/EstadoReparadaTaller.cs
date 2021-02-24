using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
   public  class EstadoReparadaTaller : EstadoOrdenTaller
    {
        public override void cambiarRetirada( string comentario, string estado, LOrdenTaller lorden)
        {

            lorden.Estado = estado;
            lorden.ComentarioOT1 = comentario;
           
        }
    }
}
