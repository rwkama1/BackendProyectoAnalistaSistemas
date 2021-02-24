using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IDatosTarjeta
    {
        void agregarTarjeta(PagoTarjeta addp);
         List<PagoTarjeta> listarPagoTarjeta();
        PagoTarjeta obtenerTarjeta(long numero);
    }
}
