using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CompraController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpHead]
        public void iniciarSolicitudCompra()
        {
            FabricaLogica.GetControladorVentaCompra().iniciarSolicitudCompra();
        }
        [HttpPost]
        public LineaCompra registrarProductoenCompra(int id, int cantidad)
        {
            return FabricaLogica.GetControladorVentaCompra().registrarProductoenCompra(id, cantidad);
        }
        [HttpPost]
        public Compra cerrarSolicitudCompra(string formaentrega,string metodopago,int cliente)
        {
            return FabricaLogica.GetControladorVentaCompra().cerrarSolicitudCompra(formaentrega,metodopago,cliente);
        }
        [HttpGet]
        public List<Compra> Get()
        {
            List<Compra> listapiprod = FabricaLogica.GetControladorVentaCompra().listarC();
            return listapiprod;
        }
        [HttpGet]
        public Compra Get(int id)
        {
            Compra com = FabricaLogica.GetControladorVentaCompra().obtenerCompra(id);
            return com;
        }
        [HttpGet]
        public List<Compra> listarCompraCliente(int cedula, DateTime fecha1, DateTime fecha2)
        {

            List<Compra> lv = FabricaLogica.GetControladorVentaCompra().listarCompraCliente(cedula, fecha1, fecha2);

            return lv;
        }
        [HttpGet]
        public List<Compra> listarCompraCliente(int cedula)
        {
            return FabricaLogica.GetControladorVentaCompra().listarCompraCliente(cedula);
        }
    }
}
