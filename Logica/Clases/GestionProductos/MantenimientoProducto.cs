using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProductos
{
    public class MantenimientoProducto
    {
        private static MantenimientoProducto _instancia = null;

        public static MantenimientoProducto GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoProducto();
            return _instancia;
        }
        public void addp(Producto addp)
        {
            FabricaDatos.getPProd().agregarProducto(addp);
        }
        public void modp(int id,Producto modp)
        {
            FabricaDatos.getPProd().modProd(id,modp);
        }
        public void elmp(Producto elmp)
        {
            FabricaDatos.getPProd().elmProd(elmp);
        }
    }
}
