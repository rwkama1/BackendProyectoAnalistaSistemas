using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProveedor
{
    public class ControladorProveedor : IControladorProveedor
    {

        private static ControladorProveedor _instancia = null;
        private ControladorProveedor() { }
        public static ControladorProveedor GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorProveedor();
            return _instancia;
        }
        private Proveedor lprob;
        public Proveedor Lprob { get { return lprob; } set { lprob = value; } }

        public Proveedor ingresarRut(string rut)
        {
            Proveedor prod = Lprob;

            prod = CatalogoProveedor.GetInstancia().obtProvee(rut);
            Lprob = prod;
            return prod;
        }
        public List<Proveedor> listProv()
        {
            List<Proveedor> listp = CatalogoProveedor.GetInstancia().listprovee();

            return listp;
        }
        public bool addpp(Proveedor addpp)
        {
            bool correcto = false;
            Proveedor propusu = Lprob;
            if (propusu == null)
            {
                correcto = true;
                MantenimientoProveedor.GetInstancia().addpr(addpp);
                return correcto;

            }
            else
            {

                throw new Exception("No se puede agregar un proveedor ya existente");

            }
        }
        public bool eliminarProveedor(Proveedor elmpp)
        {
            bool correcto = false;
            Proveedor propusu = Lprob;
            if (propusu != null)
            {
                correcto = true;
                MantenimientoProveedor.GetInstancia().elmpr(elmpp);

                return correcto;

            }
            else
            {

                throw new Exception("El proveedor que se intenta eliminar no existe");

            }
        }
        public bool modificarProveedor(string rut,Proveedor mprod)
        {
            bool correcto = false;
            Proveedor propusu = Lprob;
            if (propusu != null)
            {
                correcto = true;
                MantenimientoProveedor.GetInstancia().modpr(rut,mprod);

                return correcto;

            }
            else
            {

                throw new Exception("El proveedor que se intenta modificar no existe");

            }



        }

    }
}
