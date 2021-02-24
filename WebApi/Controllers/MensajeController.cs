using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class MensajeController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public List<Mensaje> listarMensajesSinResponder()
        {

            List<Mensaje> apimsj = FabricaLogica.GetControladorMensajes().listarMensajesSinResponder();
            return apimsj;
        }
        [HttpGet]
        public Mensaje buscarMensaje(int id)
        {

            Mensaje apimsj = FabricaLogica.GetControladorMensajes().buscarMensaje(id);
            return apimsj;
        }

        [HttpGet]

        public List<Mensaje> listarMensajesRespondidos(int cedula)
        {

            List<Mensaje> apimsj = FabricaLogica.GetControladorMensajes().listarMensajesRespondidos(cedula);
            return apimsj;
        }
        public HttpResponseMessage Post([FromBody]Mensaje apimsj)
        {
            try
            {
                bool operacion = FabricaLogica.GetControladorMensajes().enviarMensaje(apimsj);
                return Request.CreateResponse(HttpStatusCode.OK, apimsj);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }
        public HttpResponseMessage Put([FromBody]Mensaje apimsj)
        {
            try
            {
                bool operacion = FabricaLogica.GetControladorMensajes().responderMensaje(apimsj);
                return Request.CreateResponse(HttpStatusCode.OK, apimsj);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }
    }
}
