using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        public Producto Get(long id)
        {

            Producto apiprod = null;


            apiprod = FabricaLogica.getConProd().ingresarId(id);
            return apiprod;
        }

        [HttpGet]
        public List<Producto> Get()
        {

            List<Producto> listapiprod = FabricaLogica.getConProd().listP();
            return listapiprod;



        }
        [HttpGet]
        [Route("api/ListarProductosConStock")]
        public List<Producto> ListarProductosConStock()
        {

            return FabricaLogica.getConProd().listprodconstock();



        }
        [HttpGet]
        [Route("api/BuscarProductosporCriterio")]
        public List<Producto> BuscarProductosporCriterio(string criterio)
        {

            return FabricaLogica.getConProd().buscarlistarProductos(criterio);



        }
        public HttpResponseMessage Post([FromBody]Producto apiprod)
        {
            try
            {
                bool operacion = FabricaLogica.getConProd().addpp(apiprod);
                return Request.CreateResponse(HttpStatusCode.OK, apiprod);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }
        public HttpResponseMessage Put(int id,[FromBody]Producto apiprod)
        {
            try
            {
                bool operacion = FabricaLogica.getConProd().modificarProd(id,apiprod);
                return Request.CreateResponse(HttpStatusCode.OK, apiprod);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }
        [HttpPut]
        public HttpResponseMessage EliminarProd([FromBody]Producto apiprod)
        {
            try
            {
                bool operacion = FabricaLogica.getConProd().elmpp(apiprod);
                return Request.CreateResponse(HttpStatusCode.OK, apiprod);
            }
            catch (Exception ex)
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); }

        }

    }
}
