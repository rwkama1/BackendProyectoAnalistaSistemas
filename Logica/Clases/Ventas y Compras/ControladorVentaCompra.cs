using Datos;
using Logica.Clases.GestionProductos;
using Logica.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Ventas_y_Compras
{
    public class ControladorVentaCompra : IControladorVentaCompra
    {
        private static ControladorVentaCompra _instancia = null;
        private ControladorVentaCompra() { }
        public static ControladorVentaCompra GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorVentaCompra();
            return _instancia;
        }
        LCompra lcompra;
        LVenta lventa;
      
        public LCompra Lcompra { get => lcompra; set => lcompra = value; }
        public LVenta Lventa { get => lventa; set => lventa = value; }
       


        //Realizar Compra
        public void iniciarSolicitudCompra()
        {
                LCompra logicac = new LCompra();
                Lcompra = logicac; 
        }
        public LineaCompra registrarProductoenCompra(int id, int cantidad)
        {
            LineaCompra datoslineaCompra = null;

            LCompra lfc = Lcompra;

            if (lfc != null && id >= 1 && cantidad >= 1)
            {
                string estado = lfc.EstadoC1;
                if (estado == "Abierta")
                {
                    LProducto articulo = CatalogoProductos.GetInstancia().obtProdL(id);

                    if (articulo != null)
                    {
                        datoslineaCompra = lfc.registrarLinea(articulo, cantidad);



                    }
                }
            }
            return datoslineaCompra;

        }
        public Compra cerrarSolicitudCompra(string formaentrega,string metodopago,int cliente)
        {
            Compra dataCompra = null;

            LCompra lcompra = Lcompra;

            if (lcompra != null)
            {
                string estado = lcompra.EstadoC1;
                if (estado == "Abierta")
                {
                    bool tieneLineas = lcompra.tieneLineas();
                    if (tieneLineas)
                    {
                        lcompra.FormaEntregaC1 = formaentrega;
                        lcompra.MetodoPagoC1 = metodopago;
                        lcompra.Cliente = cliente;
                        lcompra.cerrarCompra();
                        dataCompra = lcompra.getDataType();
                        RegistroCompra.GetInstancia().RegistrarCompra(dataCompra);
                        Lcompra = null;
                    }
                }

                    

            }

            return dataCompra;
        }
        //Venta Web
        public List<Compra> listarSolicitudCompras()
        {
            List<Compra> lv = new List<Compra>();
            lv = CatalogoCompra.GetInstancia().listarComprasPendientes();

            return lv;

        }
        public Compra seleccionarCompra(int id)
        {

            Compra compra = CatalogoCompra.GetInstancia().obtenerCompra(id);
            LVenta logicaventa = RegistroVenta.GetInstancia().convertirCompraVenta(compra);
            Lventa = logicaventa;
            return compra;

        }
        public Venta aceptarSolicitud(int idcompra)
        {
        
            RegistroCompra.GetInstancia().aceptarCompra(idcompra);
            LVenta lventa = Lventa;
            Venta venta = lventa.getDataType2();
            venta.EstadoV = "Cerrada";
            RegistroVenta.GetInstancia().RegistrarVenta(venta);
            Lventa = null;
            return venta;

        }
        public Compra rechazarCompra(int id)
        {
           
            RegistroCompra.GetInstancia().rechazarCompra(id);
            Compra compra = CatalogoCompra.GetInstancia().obtenerCompra(id);
            Lventa = null;
            return compra;

        }
        //Venta Personal
        public void iniciarVenta()
        {
            LVenta ven = new LVenta();
            Lventa = ven;
        }
        public LineaVenta registrarProductoenVenta(int id, int cantidad)
        {
            LineaVenta datoslineaVenta = null;

            LVenta venta = Lventa;

            if (venta != null && id >= 1 && cantidad >= 1)
            {
                string estado = venta.EstadoV1;
                if (estado == "Abierta")
                {
                    
                    
                        LProducto articulo = CatalogoProductos.GetInstancia().obtProdL(id);

                        if (articulo != null)
                        {
                            datoslineaVenta = venta.registrarLinea(articulo, cantidad);



                        }
                   
                }
            }
            return datoslineaVenta;

        }
        public Venta cerrarVenta(string formaentrega, string metodopago,int cliente)
        {
            Venta dataventa = null;

            LVenta venta = Lventa;

            if (venta != null)
            {
                string estado = venta.EstadoV1;
                if (estado == "Abierta")
                {
                    bool tieneLineas = venta.tieneLineas();
                    if (tieneLineas)
                    {
                        venta.cerrarVenta();
                        dataventa = venta.getDataType();
                        dataventa.MetodoPagoV = metodopago;
                        dataventa.FormaEntregaV = formaentrega;
                        dataventa.ClienteV = cliente;
                        RegistroVenta.GetInstancia().RegistrarVenta(dataventa);
                        Lventa = null;
                    }
                }
            }

            return dataventa;
        }
        public List<Compra> listarC()
        {
            List<Compra> listp = CatalogoCompra.GetInstancia().listarCompra();

            return listp;
        }
        public Compra obtenerCompra(int id)
        {
            Compra c = CatalogoCompra.GetInstancia().obtenerCompra(id);

            return c;
        }
        public List<Venta> listarV()
        {
            List<Venta> listp = CatalogoVenta.GetInstancia().listarVenta();

            return listp;
        }
        public Venta obtenerVenta(int id)
        {
            Venta c = CatalogoVenta.GetInstancia().obtenerVenta(id);

            return c;
        }
        public List<Venta> buscarVentasWebMetodoPago(string criterio)
        {
            return CatalogoVenta.GetInstancia().buscarVentasWebMetodoPago(criterio);
        }
        public List<Venta> buscarVentasPersonalesMetodoPago(string criterio)
        {
            return CatalogoVenta.GetInstancia().buscarVentasPersonalesMetodoPago(criterio);
        }
        public List<Venta> buscarVentasCobradasCriterio(string criterio)
        {

            return CatalogoVenta.GetInstancia().buscarVentasCobradasCriterio(criterio);
        }
        public List<Compra> listarCompraCliente(int cedula, DateTime fecha1, DateTime fecha2)
        {

            List<Compra> lv = CatalogoCompra.GetInstancia().ListarComprasFechas(cedula, fecha1, fecha2);

            return lv;
        }
        public List<Venta> listarVentaCliente(int cedula, DateTime fecha1, DateTime fecha2)
        {

            List<Venta> lv = CatalogoVenta.GetInstancia().listarVentaFechas(cedula, fecha1, fecha2);

            return lv;
        }
        public List<Compra> listarCompraCliente(int cedula)
        {

            List<Compra> lv = CatalogoCompra.GetInstancia().listarCompraClientee(cedula);

            return lv;
        }
        public List<LineaVenta> listarProductosmasVendidos()
        {
            return CatalogoVenta.GetInstancia().listarProductosmasVendidos();
        }
        public List<Venta> buscarVentascriterio(string criterio)
        {
            return CatalogoVenta.GetInstancia().buscarVentascriterio(criterio);
        }

        public List<Venta> listarVentasCobradasTodas()
        {
            return CatalogoVenta.GetInstancia().listarVentasCobradasTodas();
        }
        public List<Venta> listarVentasClientes(int cedula)
        { return CatalogoVenta.GetInstancia().listarVentasClientes(cedula); }
        public List<Venta> buscarVentasCobradastodas(string criterio)
        { return CatalogoVenta.GetInstancia().buscarVentasCobradastodas(criterio); }
    }
}


