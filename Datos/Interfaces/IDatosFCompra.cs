
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
   public interface IDatosFCompra
    {
        List<FacturaCompra> ListarFC();
        FacturaCompra obtenerFactura(string numerofc);
        
        FacturaCompra obtenerFacturaProvNumber(string numerofc, string prov);
       void agregarFacturaCompra(FacturaCompra addp);
        
    }
}
