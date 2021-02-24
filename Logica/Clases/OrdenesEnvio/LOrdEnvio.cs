using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesEnvio
{
    public class LOrdenEnvio
    {
        
        public int IdOE { get; set; }
        public int VentaOE { get; set; }
        public int Clienteoe { get; set; }
        public long CadeteOE { get; set; }
        public string UbicacionOE { get; set; }
        public System.DateTime FechaOE { get; set; }
        public string EstadoOE { get; set; }
        public List<LProductosOE> LProductosOrdenEnvio { get; set; }
        public string LocalidadOE { get; set; }

        public LOrdenEnvio(int idOE, int ventaOE,int clienteoe,long cadeteoe, string ubicacionOE, DateTime fechaOE, string estadoOE, List<LProductosOE> lProductosOrdenEnvio,string departamento)
        {
            IdOE = idOE;
            Clienteoe = clienteoe;
            CadeteOE = cadeteoe;
            VentaOE = ventaOE;
            UbicacionOE = ubicacionOE;
            FechaOE = fechaOE;
            EstadoOE = estadoOE;
            LProductosOrdenEnvio = lProductosOrdenEnvio;
            LocalidadOE = departamento;
        }

        public LOrdenEnvio()
        {
            IdOE = 0; 
            FechaOE = DateTime.Now;
            EstadoOE = "Pendiente";
            List<LProductosOE> lineasv = new List<LProductosOE>();
            LProductosOrdenEnvio = lineasv;
        }

        public OrdenEnvio getDataType()
        {
            List<ProductosOE> datospoe = new List<ProductosOE>();
            foreach (LProductosOE lv in LProductosOrdenEnvio)
            {
                datospoe.Add(lv.getDataType());
            }
            OrdenEnvio data = new OrdenEnvio();
            data.IdOE = IdOE;
            data.CadeteOE = CadeteOE;
            data.ClienteOE = Clienteoe;
            data.VentaOE = VentaOE;
            data.UbicacionOE = UbicacionOE;
            data.FechaOE = FechaOE;
            data.EstadoOE = EstadoOE;
            data.ProductosOrdenEnvio = datospoe;
            data.LocalidadOE = LocalidadOE;
            return data;
        }
       
    }
}
