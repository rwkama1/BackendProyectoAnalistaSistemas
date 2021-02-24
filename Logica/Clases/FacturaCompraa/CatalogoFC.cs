using Datos;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.FacturaCompraa
{
    public class CatalogoFC
    {
        private static CatalogoFC _instancia = null;
        public static CatalogoFC GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoFC();
            return _instancia;
        }
     
        List<FacturaCompra> lfacturacompra= FabricaDatos.GetDatosFCompra().ListarFC();

        
        internal List<FacturaCompra> Lfacturacompra1 { get => lfacturacompra; set => lfacturacompra = value; }
        public FacturaCompra obtenerFCProv(string numero,string prov)
        {
            FacturaCompra pr = null;
               
            {

                pr = FabricaDatos.GetDatosFCompra().obtenerFacturaProvNumber(numero,prov);

            }
          
            return pr;
        }
       
        public List<FacturaCompra> listarFC()
        {
            List<FacturaCompra> lfc = new List<FacturaCompra>();
            lfc = FabricaDatos.GetDatosFCompra().ListarFC();

            return lfc;

        }


    }
}
