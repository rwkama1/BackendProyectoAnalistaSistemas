using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PagoController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        [Route("api/ListarVentasPersonales")]
        public List<Venta> listarVentaPersonal()
        {
            return FabricaLogica.GetControladorPago().listarVentaPersonal();

        }
        [HttpGet]
        [Route("api/ListarVentasWeb")]
        public List<Venta> listarVentaWeb()
        {
            return FabricaLogica.GetControladorPago().listarVentaWeb();

        }
        [HttpGet]
        [Route("api/SeleccionarVenta")]
        public Venta seleccionarVenta(int id)
        {
            return FabricaLogica.GetControladorPago().seleccionarVenta(id);
        }
        [HttpGet]
        [Route("api/PagarVentaEfectivo")]
        public decimal pagarVentaEfectivo(decimal montoEntregado)
        {
            return FabricaLogica.GetControladorPago().pagarVentaEfectivo(montoEntregado);
        }
        [HttpGet]
        [Route("api/PagarVentaTarjeta")]
        public bool pagarVentaTarjeta(long numeroTarjeta, int cedulaCliente, int cantidadCuotas)
        {
            return FabricaLogica.GetControladorPago().pagarVentaTarjeta(numeroTarjeta,cedulaCliente,cantidadCuotas);
        }
    }

}
