using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionProductos
{
    public class LProducto
    {
        int id;
        string nombre;
        decimal precio;
        long stock;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public long Stock { get => stock; set => stock = value; }

      
        public LProducto(int id, string nombre, decimal precio, long stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
        public LProducto()
        {
            
        }
    }
}
