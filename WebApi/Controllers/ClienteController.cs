using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public List<Cliente> Get()
        {
            List<Cliente> listcli = FabricaLogica.GetControladorCliente().listcliente();
            return listcli;


        }
        [HttpGet]
        public Cliente Get(int cedula)
        {
            return FabricaLogica.GetControladorCliente().buscarcli(cedula);


        }
        [HttpHead]
        public void Logout()
        {
            FabricaLogica.getLUsuario().logoutcli();
        }
        [HttpGet]
        public Cliente getLogin(int cedula, string pass)
        {
            Cliente cli = null;
           cli= FabricaLogica.getLUsuario().logincliente(cedula, pass);
           
            return cli;


        }
        public bool Post([FromBody]Cliente apicliente)
        {
            return FabricaLogica.GetControladorCliente().addcliente(apicliente);

        }
        public bool Put([FromBody]Cliente apicliente)
        {
            return FabricaLogica.GetControladorCliente().modificarCliente(apicliente);

        }
    }
}
