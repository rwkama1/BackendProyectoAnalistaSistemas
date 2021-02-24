using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using Logica;
using WebApi.Controllers.Token;

namespace WebApi.Controllers
{
    public class VendedorController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public Vendedor getLogin(long cedula, string contrasena)
        {
            var token = "";
            Vendedor sto = null;
            Usuario _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            if (_unusuario is Vendedor)
            {
                sto = (Vendedor)_unusuario;
                if (sto == null)
                { throw new HttpResponseException(HttpStatusCode.BadRequest); }

                token = TokenGenerator.GenerateTokenJwt(cedula.ToString());
            }

            return sto;



        }
        public bool Post([FromBody]Vendedor apiusuario)
        {
             return FabricaLogica.getControladorUsuario().agregarUsuario(apiusuario);

        }
        public bool Put([FromBody]Vendedor apiusuario)
        {
            return FabricaLogica.getControladorUsuario().eliminarUsuario(apiusuario);

        }
        public bool Put(long cedula, [FromBody]Vendedor apiusuario)
        {
            return FabricaLogica.getControladorUsuario().modificarUsuario(cedula, apiusuario);

        }
        public Vendedor getVendedor(long cedula)
        {
            Vendedor vend = null;
            Usuario _unusuario = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            if (_unusuario is Vendedor)
                vend = (Vendedor)_unusuario;
            return vend;


        }
        public  List<Vendedor> getVendedor()
        {
            List<Vendedor> listc = FabricaLogica.getControladorUsuario().listvendeor();
            return listc;
         


        }
    }
}
