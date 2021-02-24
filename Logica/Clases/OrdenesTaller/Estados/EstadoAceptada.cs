using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
   public class EstadoAceptada : EstadoOrdenTaller
    {
        public  override  void reparadaAunTaller(decimal precio, string comentario, string estado, LOrdenTaller lorden)
        {

            lorden.Estado = estado;
            lorden.PrecioOT1 = precio;
            lorden.ComentarioOT1 = comentario;
           
        }
        public  override void cambiarNoRep(string estado, string comentario, LOrdenTaller lorden)
        {
            lorden.Estado = estado;
            lorden.ComentarioOT1 = comentario;
           
        }

       
    }
}
