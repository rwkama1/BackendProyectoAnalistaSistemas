using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Logica.Interfaces
{
    public interface IControladorOT
    {
        //Ingresar nueva orden taller
        Producto ingresarProducto(long id);
        OrdenTaller agregarOrdenTaller(OrdenTaller ordent);
      //Cambiar estado
        List<OrdenTaller> listarOrdenTaller();
        OrdenTaller seleccionarOrden(int idot);
        OrdenTaller cambiarEstado(decimal precio, string comentario);
        OrdenTaller RechazarONoReparable(string comentario);

        List<OrdenTaller> listarOrdenTallerCriterio(string algo);
        List<OrdenTaller> listarOrdenesTallerCliente(int cedula);
        List<OrdenTaller> listarOrdenesTallerTecnico(int tec);

    }
}
