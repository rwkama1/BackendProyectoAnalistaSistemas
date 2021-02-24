using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class FacturaCompraController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        //[HttpHead]
        //public void iniciarIngresoFactura()
        //{
        //    FabricaLogica.GetControladorFC().iniciarIngresoFactura();
        //}
        [HttpGet]
        public FacturaCompra ingresarNumeroFactura(string numero,DateTime fecha,string prov)
        {
          
          return  FabricaLogica.GetControladorFC().iniciarIngresoFactura(numero,fecha,prov);
          
        }
        [HttpPost]
        public LineaFacturaCompra registrarProductoenFactura(int id, int cantidad)
        {
            return FabricaLogica.GetControladorFC().registrarProductoenFactura(id, cantidad);
        }
        [HttpPost]
        public FacturaCompra cerrarIngresoFactura()
        {
            return FabricaLogica.GetControladorFC().cerrarIngresoFactura();
        }
        [HttpGet]
        public List<FacturaCompra> Get()
        {
            List<FacturaCompra> listapiprod = FabricaLogica.GetControladorFC().listarFC();
            return listapiprod;
        }
    }
}
