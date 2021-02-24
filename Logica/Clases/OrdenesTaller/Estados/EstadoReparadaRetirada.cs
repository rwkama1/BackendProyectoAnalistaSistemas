using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
   public  class EstadoReparadaRetirada : EstadoOrdenTaller
    {
        public override void cambiarPagada(string comentario, string estado, LOrdenTaller lorden)
        {

            lorden.Estado = estado;
            lorden.ComentarioOT1 = comentario;
          
        }
    }
}
