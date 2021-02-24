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
    public class CajeroController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public Cajero getLogin(long cedula, string contrasena)
        {
            var token = "";
            Cajero cad = null;
            Usuario _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            if (_unusuario is Cajero)
            {
                cad = (Cajero)_unusuario;
                if (cad == null)
                { throw new HttpResponseException(HttpStatusCode.BadRequest); }

                token = TokenGenerator.GenerateTokenJwt(cedula.ToString());
            }

            return cad;


        }
        public bool Post([FromBody]Cajero apiusuario)
        {
          return  FabricaLogica.getControladorUsuario().agregarUsuario(apiusuario);

        }
        public bool Delete([FromBody]Cajero apiusuario)
        {
            return FabricaLogica.getControladorUsuario().eliminarUsuario(apiusuario);

        }
        public bool Put(long cedula, [FromBody]Cajero apiusuario)
        {
            return FabricaLogica.getControladorUsuario().modificarUsuario(cedula, apiusuario);

        }
        public Cajero getCajero(long cedula)
        {
            Cajero cajero = null;
            Usuario _unusuario = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            if (_unusuario is Cajero)
                cajero = (Cajero)_unusuario;
            return cajero;


        }
    }
}
