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
    public class StockerController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public Stocker getLogin(long cedula, string contrasena)
        {
            var token = "";
            Stocker sto = null;
            Usuario _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            if (_unusuario is Stocker)
            {
                sto = (Stocker)_unusuario;
                if (sto == null)
                { throw new HttpResponseException(HttpStatusCode.BadRequest); }

                token = TokenGenerator.GenerateTokenJwt(cedula.ToString());
            }

            return sto;


        }
        public bool Post([FromBody]Stocker apiusuario)
        {
           return FabricaLogica.getControladorUsuario().agregarUsuario(apiusuario);

        }
        public bool Delete([FromBody]Stocker apiusuario)
        {
            return FabricaLogica.getControladorUsuario().eliminarUsuario(apiusuario);

        }
        public bool Put(long cedula, [FromBody]Stocker apiusuario)
        {
            return FabricaLogica.getControladorUsuario().modificarUsuario(cedula, apiusuario);

        }
        public Stocker getStocker(long cedula)
        {
            Stocker stock = null;
            Usuario _unusuario = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            if (_unusuario is Stocker)
                stock = (Stocker)_unusuario;
            return stock;


        }
    }
}
