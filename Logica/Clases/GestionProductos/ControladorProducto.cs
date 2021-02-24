using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProductos
{
    public class ControladorProducto:IControladorProducto
    {
        private static ControladorProducto _instancia = null;
        private ControladorProducto() { }
        public static ControladorProducto GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorProducto();
            return _instancia;
        }
        private Producto lpro;

        public Producto Lpro { get { return lpro; } set { lpro = value; } }
        public Producto ingresarId(long id)
        {
            Producto prod = Lpro;
            if (id >= 1)
            {
                prod = CatalogoProductos.GetInstancia().obtProd(id);
                Lpro = prod;

            }
            else
            {
                throw new Exception("El ID ingresado no es valido ");
            }

            return prod;
        }
        public List<Producto> listP()
        {
            List<Producto> listp = CatalogoProductos.GetInstancia().listprod();

            return listp;
        }
        public bool addpp(Producto addpp)
        {
            bool correcto = false;
            Producto propusu = Lpro;
            if (propusu == null)
            {
                correcto = true;
                MantenimientoProducto.GetInstancia().addp(addpp);
                return correcto;

            }
            else
            {

                throw new Exception("No se puede agregar un producto ya existente");

            }
        }
        public bool elmpp(Producto elmpp)
        {
            bool correcto = false;
            Producto propusu = Lpro;
            if (propusu != null)
            {
                correcto = true;
                MantenimientoProducto.GetInstancia().elmp(elmpp);

                return correcto;

            }
            else
            {

                throw new Exception("El producto que se intenta eliminar no existe");

            }
        }
        public bool modificarProd(int id,Producto mprod)
        {
            bool correcto = false;
            Producto propusu = Lpro;
            if (propusu != null)
            {
                correcto = true;
                MantenimientoProducto.GetInstancia().modp(id,mprod);

                return correcto;

            }
            else
            {

                throw new Exception("El producto que se intenta modificar no existe");

            }



        }
        public List<Producto> listprodconstock()
        {


            return CatalogoProductos.GetInstancia().listprodconstock();
        }
        public List<Producto> buscarlistarProductos(string criterio)
        {
            return CatalogoProductos.GetInstancia().buscarlistarProductos(criterio);
        }

    }
}

