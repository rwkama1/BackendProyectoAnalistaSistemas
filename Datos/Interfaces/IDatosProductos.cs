using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos.Interfaces
{
    public interface IDatosProductos
    {
        Producto obtenerProducto(long idprod);
        List<Producto> listarProductos();
        void agregarProducto(Producto addp);
        void elmProd(Producto delp);
        void modProd(int id,Producto mprod);
        List<Producto> listarProductosConStock();
        List<Producto> buscarlistarProductos(string criterio);
        //List<LProducto> listarLProductos();
    }
}
