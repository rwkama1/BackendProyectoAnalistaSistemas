using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorPago
    {
        List<Venta> listarVentaPersonal();
        List<Venta> listarVentaWeb();
        Venta seleccionarVenta(int id);
        decimal pagarVentaEfectivo(decimal montoEntregado);
        bool pagarVentaTarjeta(long numeroTarjeta, int cedulaCliente, int cantidadCuotas);
    }
}
