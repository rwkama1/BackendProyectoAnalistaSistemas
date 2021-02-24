using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Pagos
{
    public class LCuota
    {
        int numero;
        decimal importe;

        public int Numero { get => numero; set => numero = value; }
        public decimal Importe { get => importe; set => importe = value; }

        public LCuota(int numero, decimal importe)
        {
            Numero = numero;
            Importe = importe;
        }
        public Cuota getDataType()
        {
            Cuota dtlineaC = new Cuota();
            dtlineaC.ImporteCu = Importe;
            dtlineaC.NumeroTCU = Numero;
          
            return dtlineaC;
        }
    }
}
