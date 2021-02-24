
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorFC
    {
        //void iniciarIngresoFactura();
        FacturaCompra iniciarIngresoFactura(string numero, DateTime fecha, string prov);
        LineaFacturaCompra registrarProductoenFactura(int id, int cantidad);      
        FacturaCompra cerrarIngresoFactura();
        List<FacturaCompra> listarFC();
    }
}
