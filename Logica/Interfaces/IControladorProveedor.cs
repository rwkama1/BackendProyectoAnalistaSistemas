using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{

    public interface IControladorProveedor
    {
        Proveedor ingresarRut(string rut);
        List<Proveedor> listProv();
        bool addpp(Proveedor addpp);
        bool eliminarProveedor(Proveedor elmpp);
        bool modificarProveedor(string rut,Proveedor mprod);
    }
}
