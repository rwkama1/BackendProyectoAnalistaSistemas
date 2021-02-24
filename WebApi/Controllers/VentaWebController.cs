using Logica;
using Logica.Clases.Ventas_y_Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class VentaWebController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public List<Compra> listarSolicitudCompras()
        {
           
           return FabricaLogica.GetControladorVentaCompra().listarSolicitudCompras();

            

        }
        [HttpGet]
        public Compra seleccionarCompra(int id)
        {
            return FabricaLogica.GetControladorVentaCompra().seleccionarCompra(id);
        }
        [HttpGet]
        [Route("api/VentaWeb/AceptarCompra")]
        public Venta aceptarSolicitud(int idcompra)
        {
            return FabricaLogica.GetControladorVentaCompra().aceptarSolicitud(idcompra);
        }
        [HttpGet]
        [Route("api/VentaWeb/RechazarCompra")]
        public Compra rechazarSolicitud(int idcompra)
        {
            return FabricaLogica.GetControladorVentaCompra().rechazarCompra(idcompra);
        }
        [HttpGet]
        public List<Venta> buscarVentasWebMetodoPago(string criterio)
        {
            return FabricaLogica.GetControladorVentaCompra().buscarVentasWebMetodoPago(criterio);
        }
        [HttpGet]
        [Route("api/VentaWeb/ListarVentasCobradasTodas")]
        public List<Venta> ListarVentasCobradasTodas()
        {
            return FabricaLogica.GetControladorVentaCompra().listarVentasCobradasTodas();
        }
        [HttpGet]
        [Route("api/VentaWeb/ListarVentasClientes")]
        public List<Venta> listarVentasClientes(int cedula)
        {
            return FabricaLogica.GetControladorVentaCompra().listarVentasClientes(cedula);
        }
        [HttpGet]
        [Route("api/VentaWeb/BuscarVentasCobradastodas")]
        public List<Venta> buscarVentasCobradastodas(string criterio)
        {
            return FabricaLogica.GetControladorVentaCompra().buscarVentasCobradastodas(criterio);
        }
    }
}
