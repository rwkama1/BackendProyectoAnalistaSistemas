using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
   public  class EstadoEnRevision : EstadoOrdenTaller
    {
        
        public override void cambiarPresupuestada(string estado,LOrdenTaller lorden)
        {
            
            lorden.Estado = estado;
             
        }
       
        public override void cambiarNoReparable(string estado,string comentario, LOrdenTaller lorden)
        {
            lorden.Estado = estado;
            lorden.ComentarioOT1 = comentario;
           
        }


    }
}
