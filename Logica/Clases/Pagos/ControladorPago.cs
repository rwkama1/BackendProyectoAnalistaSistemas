using Logica.Clases.Ventas_y_Compras;
using Logica.Interfaces;
using ProveedorTarjeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Pagos
{
    internal class ControladorPago:IControladorPago
    {
        private static ControladorPago _instancia = null;
        private ControladorPago() { }
        public static ControladorPago GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorPago();
            return _instancia;
        }
        LVenta lventa;
        public LVenta Lventa { get => lventa; set => lventa = value; }
        public List<Venta> listarVentaPersonal()
        {
            List<Venta> lv = new List<Venta>();
            lv = CatalogoVenta.GetInstancia().listarVentaPersonal();

            return lv;

        }
        public List<Venta> listarVentaWeb()
        {
            List<Venta> lv = new List<Venta>();
            lv = CatalogoVenta.GetInstancia().listarVentaWeb();

            return lv;

        }
        public Venta seleccionarVenta(int id)
        {
            Venta c = CatalogoVenta.GetInstancia().obtenerVenta(id);
            LVenta venta = CatalogoVenta.GetInstancia().obtenerLVenta(c);
            Lventa = venta;
            return c;
        }
        public decimal pagarVentaEfectivo(decimal montoEntregado)
        {
            decimal vuelto = -1;
            Venta dventa;
            LVenta venta = Lventa;

            if (venta != null)
            {
                String estado = venta.EstadoV1;

                if (estado.Equals("Cerrada"))
                {
                    bool tieneLineas = venta.tieneLineas();

                    if (tieneLineas)
                    {
                        vuelto = venta.calcularVuelto(montoEntregado);

                        if (vuelto >= 0)
                        {
                            venta.cobrarEfectivo();
                            dventa= venta.getDataType2();
                            dventa.TarjetaV = null;
                            RegistroVenta.GetInstancia().cobrarVenta(dventa);

                            Lventa =null;
                        }
                    }
                }
            }

            return vuelto;
        }
        public bool pagarVentaTarjeta(long numeroTarjeta, int cedulaCliente, int cantidadCuotas)
        {
            bool aceptada = false;
            Venta dventa;
            LVenta venta = Lventa;

            if (venta != null && numeroTarjeta >= 1 && cedulaCliente >= 1 && cantidadCuotas >= 1)
            {
                string estado = venta.EstadoV1;

                if (estado.Equals("Cerrada"))
                {
                    bool tieneLineas = venta.tieneLineas();

                    if (tieneLineas)
                    {
                        decimal total = venta.TotalV1;
                        aceptada = ProveedorTarjetas.GetInstancia().comprobarYCargar(numeroTarjeta, cedulaCliente, cantidadCuotas, total);

                        if (aceptada)
                        {
                            venta.cobrarConTarjeta(numeroTarjeta, cedulaCliente, cantidadCuotas); 
                            dventa = venta.getDataType2();
                            RegistroVenta.GetInstancia().cobrarVenta(dventa);
                            Lventa =null;
                        }
                    }
                }
            }

            return aceptada;
        }
    }
}
