using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class OrdenEnvioController : ApiController
    {
        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet, Route("api/ListarVentasCobradas")]
        public List<Venta> listarVentasCobradas()
        {
            return FabricaLogica.GetControladorOE().listarVentasCobradas();


        }
     
        [HttpGet, Route("api/BuscarVentasCobradas")]
        public List<Venta> buscarVentasCobradas(string criterio)

        {
            return FabricaLogica.GetControladorVentaCompra().buscarVentasCobradasCriterio(criterio);


        }
        [HttpGet, Route("api/SeleccionarVentaCobrada")]
        public Venta seleccionarVenta(int idventa)
        {
            return FabricaLogica.GetControladorOE().seleccionarVenta(idventa);
        }
        [HttpGet, Route("api/AgregarOrdenEnvio")]
        public OrdenEnvio agregarOrdenEnvio(long cadete, int cliente, int idventa, string destino,string localidad)
        {
           return FabricaLogica.GetControladorOE().agregarOrdenEnvio(cadete,cliente,idventa, destino,localidad);
        }
        [HttpGet, Route("api/ListarOrdenEnvioPendientes")]
        public List<OrdenEnvio> listarOrdenEnvioPendientes()
        {
            return FabricaLogica.GetControladorOE().listarOrdenEnvioPendientes();


        }
        [HttpGet, Route("api/ListarOrdenesEnvioCadete")]
        public List<OrdenEnvio> listarordenenviocadete(long cadete)
        {
            return FabricaLogica.GetControladorOE().listarOrdenEnvioCadete(cadete);


        }
        [HttpGet, Route("api/ListarOrdenesEnvioCliente")]
        public List<OrdenEnvio> listarordenenviocliente(int cliente)
        {
            return FabricaLogica.GetControladorOE().listarOrdenEnvioCliente(cliente);


        }
        [HttpGet, Route("api/SeleccionarOrdenEnvio")]
        public OrdenEnvio seleccionarOrdenEnvio(int id)
        {
            return FabricaLogica.GetControladorOE().seleccionarOrdenEnvio(id);
        }
        [HttpPost]
        public void cambiarEstado([FromBody]OrdenEnvio orden)
        {
            FabricaLogica.GetControladorOE().cambiarEstado(orden);
        }


    }
}
