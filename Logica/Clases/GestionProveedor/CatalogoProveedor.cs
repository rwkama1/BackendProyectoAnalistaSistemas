using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProveedor
{
    public class CatalogoProveedor
    {
        private static CatalogoProveedor _instancia = null;
        public static CatalogoProveedor GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoProveedor();
            return _instancia;
        }
        private List<Proveedor> lproveedor;
        public List<Proveedor> LProveedor { get { return lproveedor; } }
        public Proveedor obtProvee(string rut)
        {
            Proveedor pr = null;
            pr = FabricaDatos.getProveedor().obtProv(rut);
            return pr;
        }
        public List<Proveedor> listprovee()
        {
            lproveedor = new List<Proveedor>();
            lproveedor = FabricaDatos.getProveedor().listarProveedor();

            return lproveedor;
        }
    }
}
