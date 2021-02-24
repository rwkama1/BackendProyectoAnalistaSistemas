using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProveedor
{
    public class MantenimientoProveedor
    {
        private static MantenimientoProveedor _instancia = null;

        public static MantenimientoProveedor GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoProveedor();
            return _instancia;
        }
        public void addpr(Proveedor addpr)
        {
            FabricaDatos.getProveedor().agregarProveedor(addpr);
        }
        public void modpr(string rut,Proveedor modpr)
        {
            FabricaDatos.getProveedor().modificarProveedor(rut,modpr);
        }
        public void elmpr(Proveedor elmpr)
        {
            FabricaDatos.getProveedor().eliminarProv(elmpr);
        }
    }
}
