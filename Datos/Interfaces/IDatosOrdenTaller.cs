using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosOrdenTaller
    {
        void agregarOT(OrdenTaller cli);
        void cambiarEstado(OrdenTaller ot);
        OrdenTaller buscarOrdenTaller(int idot);
        List<OrdenTaller> listarOrdenesTaller();
        List<OrdenTaller> listarOrdenesTallerCriterio(string algo);
        List<OrdenTaller> listarOrdenesTallerCliente(int cedula);
        List<OrdenTaller> listarOrdenesTallerTecnico(int tecnico);
    }
}
