using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosOrdenEnvio
    {
        List<OrdenEnvio> listarOrdenesEnvio();
        void agregarOE(OrdenEnvio cli);
        List<OrdenEnvio> listarOrdenesEnvioPendiente();
        void cambiarEstado(OrdenEnvio ot);
        OrdenEnvio buscarOrdenesEnvio(int id);
        List<OrdenEnvio> listarOrdenesEnvioCadete(long cadete);
        List<OrdenEnvio> listarOrdenesEnvioCliente(int cliente);
    }
}
