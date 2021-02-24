using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorProducto
    {
        Producto ingresarId(long id);
        List<Producto> listP();
        bool addpp(Producto addpp);
        bool elmpp(Producto elmpp);
        bool modificarProd(int id,Producto mprod);
        List<Producto> listprodconstock();
        List<Producto> buscarlistarProductos(string criterio);
    }
}
