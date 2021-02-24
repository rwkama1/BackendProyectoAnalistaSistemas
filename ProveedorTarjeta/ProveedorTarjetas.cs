using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorTarjeta
{
    public class ProveedorTarjetas
    {
        private static ProveedorTarjetas _instancia = null;
        private ProveedorTarjetas() { }
        public static ProveedorTarjetas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ProveedorTarjetas();
            return _instancia;
        }
        public bool comprobarYCargar(long numeroTarjeta, int cedulaCliente, int cantidadCuotas, decimal monto)
        {
            int numero = new Random().Next(100) + 1;

            return numero > 25;
        }
        //public static bool CheckCreditCard(string creditCardNumber)
        //{
        //    StringBuilder digitsOnly = new StringBuilder();
        //    creditCardNumber.(c =>
        //    {
        //        if (Char.IsDigit(c)) digitsOnly.Append(c);
        //    });

        //    if (digitsOnly.Length > 18 || digitsOnly.Length < 15) return false;

        //    int sum = 0;
        //    int digit = 0;
        //    int addend = 0;
        //    bool timesTwo = false;

        //    for (int i = digitsOnly.Length - 1; i >= 0; i--)
        //    {
        //        digit = Int32.Parse(digitsOnly.ToString(i, 1));
        //        if (timesTwo)
        //        {
        //            addend = digit * 2;
        //            if (addend > 9)
        //            {
        //                addend -= 9;
        //            }
        //        }
        //        else
        //        {
        //            addend = digit;
        //        }
        //        sum += addend;
        //        timesTwo = !timesTwo;
        //    }
        //    return (sum % 10) == 0;
        //}
    }
}
