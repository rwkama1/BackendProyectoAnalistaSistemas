using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class OrdenTallerController : ApiController
    {
        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        //Ingresar nueva orden taller
        [HttpGet]
        public Producto ingresarProducto(long id)
        {
            return FabricaLogica.GetControladorOT().ingresarProducto(id);
        }
        [HttpPost]
        public OrdenTaller agregarOrdenTaller([FromBody] OrdenTaller ordenTaller)
        {
            return FabricaLogica.GetControladorOT().agregarOrdenTaller(ordenTaller);
        }
        //Cambiar Estado
        [HttpGet]
        public List<OrdenTaller> listarOrdenTaller()
        {
            return FabricaLogica.GetControladorOT().listarOrdenTaller();

        }
        [HttpGet, Route("api/SeleccionarOrdenTaller")]
        public OrdenTaller seleccionarOrden(int idot)
        {
            return FabricaLogica.GetControladorOT().seleccionarOrden(idot);
        }
        [HttpGet, Route("api/CambiarEstadoOrdenTaller")]
        public OrdenTaller cambiarEstado(decimal precio, string comentario)
        {
            return FabricaLogica.GetControladorOT().cambiarEstado(precio,comentario);
        }
        [HttpGet, Route("api/RechazarOrdenTaller")]
        public OrdenTaller rechazarOrdenTaller(string comentario)
        {
            return FabricaLogica.GetControladorOT().RechazarONoReparable(comentario);
        }
        [HttpGet, Route("api/ListarOrdenTallerCriterio")]
        public List<OrdenTaller> listarOrdenTallerCriterio(string algo)
        {
            return FabricaLogica.GetControladorOT().listarOrdenTallerCriterio(algo);

        }
        [HttpGet, Route("api/ListarOrdenTallerCliente")]
        public List<OrdenTaller> listarOrdenTallerCliente(int cedula)
        {
            return FabricaLogica.GetControladorOT().listarOrdenesTallerCliente(cedula);

        }
        [HttpGet, Route("api/ListarOrdenTallerTecnico")]
        public List<OrdenTaller> listarOrdenTallerTecnico(int tecnico)
        {
            return FabricaLogica.GetControladorOT().listarOrdenesTallerCliente(tecnico);

        }

    }
}
