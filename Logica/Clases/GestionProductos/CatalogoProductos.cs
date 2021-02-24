using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProductos
{
    public class CatalogoProductos
    {
        private static CatalogoProductos _instancia = null;
        public static CatalogoProductos GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoProductos();
            return _instancia;
        }
        private List<Producto> lprod= FabricaDatos.getPProd().listarProductos();

        //private List<LProducto> logicaproducto;

        
        //public CatalogoProductos()
        //    {
        //    logicaproducto = new List<LProducto>();
        //    logicaproducto = FabricaDatos.getPProd().listarProductos();
        //    }
        //public List<LProducto> Logicaproducto { get => logicaproducto; set => logicaproducto = value; }
        public List<Producto> Lprod { get => lprod; set => lprod = value; }

        public Producto obtProd(long id)
        {
            Producto pr = null;
            if (id >= 1)
            {

                pr = FabricaDatos.getPProd().obtenerProducto(id);
              

            }
            else
            { throw new Exception("El id del producto debe ser mayor o igual a 1"); }
            return pr;
        }
        public List<Producto> listprod()
        {
            Lprod = new List<Producto>();
            Lprod = FabricaDatos.getPProd().listarProductos();

            return Lprod;
        }
        public List<Producto> buscarlistarProductos(string criterio)
        {
            return FabricaDatos.getPProd().buscarlistarProductos(criterio);
        }
        public List<Producto> listprodconstock()
        {
            

            return FabricaDatos.getPProd().listarProductosConStock();
        }
        public LProducto obtProdL(long id)
        {
            LProducto producto = null;
            Producto pr = null;
            if (id >= 1)
            {

                pr = FabricaDatos.getPProd().obtenerProducto(id);

               producto = new LProducto(pr.IdProducto, pr.NomProd, pr.PrecioProd, pr.StockProd);
            }
            else
            { throw new Exception("El id del producto debe ser mayor o igual a 1"); }
            return producto;
        }

    }

}
