using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Pagos
{
    public class LPagoTarjeta
    {
        int idpt;
        long numerot;
        int clientet;
        int cantcuotas;
        decimal totalt;
        List<LCuota> listcuotas;

        public int Idpt { get => idpt; set => idpt = value; }
        public long Numerot { get => numerot; set => numerot = value; }
        public int Clientet { get => clientet; set => clientet = value; }
        public List<LCuota> Listcuotas { get => listcuotas; set => listcuotas = value; }
        public int Cantcuotas { get => cantcuotas; set => cantcuotas = value; }
        public decimal Totalt { get => totalt; set => totalt = value; }

        public LPagoTarjeta( long numerot, int clientet, int cantidadcuotas,decimal total)
        {
            Numerot = numerot;
            Clientet = clientet;
            Cantcuotas = cantidadcuotas;
            Totalt = total;
            List<LCuota> cuotas=new List<LCuota>();
            Listcuotas = cuotas;
            LCuota cuota;   
            decimal importe = Totalt / Cantcuotas;
            for (int i = 1; i <= Cantcuotas; i++)
            {
                cuota = new LCuota(i, importe);
                cuotas.Add(cuota);
            }

        }

        public LPagoTarjeta()
        {
        }
        public PagoTarjeta getDataType()
        {
            List<Cuota> datoscuotas = new List<Cuota>();

            foreach (LCuota lv in Listcuotas)
            {
                datoscuotas.Add(lv.getDataType());
            }
            PagoTarjeta data = new PagoTarjeta(Idpt,Numerot,Clientet,Cantcuotas,Totalt, datoscuotas);
            return data;
        }
    }
}
