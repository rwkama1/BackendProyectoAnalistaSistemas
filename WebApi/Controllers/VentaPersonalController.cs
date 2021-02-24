using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class VentaPersonalController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpHead]
        public void iniciarVenta()
        {
            FabricaLogica.GetControladorVentaCompra().iniciarVenta();
        }
        [HttpPost]
        public LineaVenta registrarProductoenVenta(int id,int cantidad)
        {
            return FabricaLogica.GetControladorVentaCompra().registrarProductoenVenta(id, cantidad);
        }
        [HttpPost]
        public Venta cerrarVenta(string formaentrega, string metodopago,int cliente)
        {
            return FabricaLogica.GetControladorVentaCompra().cerrarVenta(formaentrega, metodopago,cliente);
        }
        [HttpGet]
        public Venta obtenerVenta(int id)
        {
            return FabricaLogica.GetControladorVentaCompra().obtenerVenta(id);
        }
        [HttpGet]
        public List<Venta> listVenta()
        {
            return FabricaLogica.GetControladorVentaCompra().listarV();
        }
       
        [HttpGet]
        public List<Venta> buscarVentasPersonalesMetodoPago(string criterio)
        {
            return FabricaLogica.GetControladorVentaCompra().buscarVentasPersonalesMetodoPago(criterio);
        }
        [HttpGet]
        public List<Venta> listarVentaCliente(int cedula, DateTime fecha1, DateTime fecha2)
        {

            return FabricaLogica.GetControladorVentaCompra().listarVentaCliente(cedula, fecha1, fecha2);
        }
        [HttpGet]
        [Route("api/VentaPersonal/ListarProductosmasVendidos")]
        public List<LineaVenta> listarProductosmasVendidos()
        {
            return FabricaLogica.GetControladorVentaCompra().listarProductosmasVendidos();
        }
        [HttpGet]
        [Route("api/VentaPersonal/ListarVentasCriterio")]
        public List<Venta> listarvcriterio(string criterio)
        {
            return FabricaLogica.GetControladorVentaCompra().buscarVentascriterio(criterio);
        }
    }
}
