using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesEnvio
{
    public class CatalogoOE
    {
        private static CatalogoOE _instancia = null;
        public static CatalogoOE GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoOE();
            return _instancia;
        }
        public List<OrdenEnvio> listarOrdenEnvioPendiente()
        {
            return FabricaDatos.GetOrdenEnvio().listarOrdenesEnvioPendiente();
        }
        public List<OrdenEnvio> listarOrdenEnvioCadete(long cadete)
        {
            return FabricaDatos.GetOrdenEnvio().listarOrdenesEnvioCadete(cadete);
        }
        public List<OrdenEnvio> listarOrdenEnvioCliente(int cliente)
        {
            return FabricaDatos.GetOrdenEnvio().listarOrdenesEnvioCliente(cliente);
        }
        public LOrdenEnvio obtenerProductoOrdenEnvio(Venta v)
        {
            List <LProductosOE> listproductosoe = new List<LProductosOE>();

            foreach (LineaVenta lv  in v.LineaVenta)
            {
                LProductosOE productoe = new LProductosOE();

                productoe.POE = lv.ProductoLV;

                listproductosoe.Add(productoe);

            }
            LOrdenEnvio logicaoe = new LOrdenEnvio();
            logicaoe.LProductosOrdenEnvio = listproductosoe;
          
            return logicaoe;
        }
        public OrdenEnvio buscarOE(int id)
        {
            return FabricaDatos.GetOrdenEnvio().buscarOrdenesEnvio(id);
        }



        }

    }
