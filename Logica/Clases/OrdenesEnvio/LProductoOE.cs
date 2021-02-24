using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesEnvio
{
    public class LProductosOE
    {
      

        public int IdProdOE { get; set; }
        public int POE { get; set; }
        public int IdOrdenE { get; set; }

        public LProductosOE(int idProdOE, int pOE, int idOrdenE)
        {
            IdProdOE = idProdOE;
            POE = pOE;
            IdOrdenE = idOrdenE;
        }
        public LProductosOE()
        {
            IdProdOE = 0;
            IdOrdenE = 0;
            POE = 0;
        }

        public ProductosOE getDataType()
        {
            ProductosOE data = new ProductosOE();
            data.IdProdOE=IdProdOE;
            data.POE = POE;
            data.IdOrdenE = IdOrdenE;
            return data;
        }
       
    }
}
