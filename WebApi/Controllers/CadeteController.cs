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
    public class CadeteController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public Cadete getLogin(long cedula, string contrasena)
        {
            var token = "";
            Cadete cad = null;
            Usuario _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            if (_unusuario is Cadete)
            {
                cad = (Cadete)_unusuario;
                if (cad == null)
                { throw new HttpResponseException(HttpStatusCode.BadRequest); }

                token = TokenGenerator.GenerateTokenJwt(cedula.ToString());
            }

            return cad;


        }
        public bool Post([FromBody]Cadete apiusuario)
        {
           return FabricaLogica.getControladorUsuario().agregarUsuario(apiusuario);

        }
        [HttpPut]
        public bool EliminarCadete([FromBody]Cadete apiusuario)
        {
            return FabricaLogica.getControladorUsuario().eliminarUsuario(apiusuario);

        }
        public bool Put(long cedula,[FromBody]Cadete apiusuario)
        {
            return FabricaLogica.getControladorUsuario().modificarUsuario(cedula, apiusuario);

        }
        public Cadete getCadete(long cedula)
        {
            Cadete cadete = null;
            Usuario _unusuario = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            if (_unusuario is Cadete)
                cadete = (Cadete)_unusuario;
            return cadete;


        }
        public List<Cadete> getCadetes()
        {
            List<Cadete> listc = FabricaLogica.getControladorUsuario().listcadete();
            return listc;


        }
    }
}
