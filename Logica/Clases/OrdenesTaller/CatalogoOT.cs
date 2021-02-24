using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
    public class CatalogoOT
    {
        private static CatalogoOT _instancia = null;
        public static CatalogoOT GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoOT();
            return _instancia;
        }
        public List<OrdenTaller> listarOrdenTaller()
        {
            return FabricaDatos.GetOrdenTaller().listarOrdenesTaller();

        }
        public List<OrdenTaller> listarOrdenesTallerCriterio(string algo)
        {
            return FabricaDatos.GetOrdenTaller().listarOrdenesTallerCriterio(algo);

        }
        public List<OrdenTaller> listarOrdenesTallerCliente(int cedula)
        {
            return FabricaDatos.GetOrdenTaller().listarOrdenesTallerCliente(cedula);

        }
        public List<OrdenTaller> listarOrdenesTallerTecnico(int tec)
        {
            return FabricaDatos.GetOrdenTaller().listarOrdenesTallerTecnico(tec);

        }

        public OrdenTaller buscarOrdenTaller(int idot)
        {
            return FabricaDatos.GetOrdenTaller().buscarOrdenTaller(idot);

        }
        public LOrdenTaller getLOrdTaller(OrdenTaller dtot)
        {
            LOrdenTaller logicaot = new LOrdenTaller();
            logicaot.IdOT1 = dtot.IdOT;
            logicaot.ProductoOT1 = dtot.ProductoOT;
           logicaot.FechaOT1 = dtot.FechaOT;
           logicaot.ClienteOT1 = dtot.ClienteOT;
           logicaot.DeclaracionCOT1 = dtot.DeclaracionCOT;
           logicaot.PrecioOT1 = dtot.PrecioOT;
            logicaot.ComentarioOT1 = dtot.ComentarioOT;
           logicaot.Estado = dtot.EstadoOT;
            logicaot.TecnicoOT1 = dtot.TecnicoOT;
            return logicaot;
        }
    }
   
   

}
