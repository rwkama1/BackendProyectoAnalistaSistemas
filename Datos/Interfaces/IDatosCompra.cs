using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IDatosCompra
    {
        List<Compra> listarCompra();
        void agregarCompra(Compra addp);
        Compra obtenerCompra(int id);
        List<Compra> listarCompraPendientes();
        void rechazarCompra(int idcompra);
        void aceptarCompra(int idcompra);
         List<Compra> listarCompraCliente(int cedula, DateTime fecha1, DateTime fecha2);
        List<Compra> listarCompraClientee(int cedula);
    }
}
