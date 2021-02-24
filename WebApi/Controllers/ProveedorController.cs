using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProveedorController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        public Proveedor Get(string rut)
        {
            Proveedor apiprod = null;
            apiprod = FabricaLogica.getconProveedor().ingresarRut(rut);
            return apiprod;
        }
        [HttpGet]
        public List<Proveedor> Get()
        {
            List<Proveedor> listapiprod = FabricaLogica.getconProveedor().listProv();
            return listapiprod;

        }
        public HttpResponseMessage Post([FromBody]Proveedor apiprod)
        {
            try
            {
                bool operacion = FabricaLogica.getconProveedor().addpp(apiprod);
                return Request.CreateResponse(HttpStatusCode.OK, apiprod);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }
        public HttpResponseMessage Put(string rut,[FromBody]Proveedor apiprod)
        {
            try
            {
                bool operacion = FabricaLogica.getconProveedor().modificarProveedor(rut,apiprod);
                return Request.CreateResponse(HttpStatusCode.OK, apiprod);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }
        public HttpResponseMessage Put([FromBody]Proveedor apiprod)
        {
            try
            {
                bool operacion = FabricaLogica.getconProveedor().eliminarProveedor(apiprod);
                return Request.CreateResponse(HttpStatusCode.OK, apiprod);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }

    
}
}
