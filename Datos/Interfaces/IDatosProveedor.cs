using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IDatosProveedor
    {
        Proveedor obtProv(string rut);
        List<Proveedor> listarProveedor();
        void agregarProveedor(Proveedor adprov);
        void eliminarProv(Proveedor delp);
        void modificarProveedor(string rut,Proveedor mprod);
    }
}
