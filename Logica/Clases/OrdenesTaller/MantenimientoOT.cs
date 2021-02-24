using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
    public class MantenimientoOT
    {
        private static MantenimientoOT _instancia = null;

        public static MantenimientoOT GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoOT();
            return _instancia;
        }
        public void addot(OrdenTaller addp)
        {
            FabricaDatos.GetOrdenTaller().agregarOT(addp);
        }
        public void cambiarEstado(OrdenTaller ordent)
        {
            FabricaDatos.GetOrdenTaller().cambiarEstado(ordent);
        }
        //public void modp(Producto modp)
        //{
        //    FabricaDatos.getPProd().modProd(modp);
        //}
        //public void elmp(Producto elmp)
        //{
        //    FabricaDatos.getPProd().elmProd(elmp);
        //}
    }
}
