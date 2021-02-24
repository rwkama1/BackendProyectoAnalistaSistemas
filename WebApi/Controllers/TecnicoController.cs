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
    public class TecnicoController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [HttpGet]
        public Tecnico getLogin(long cedula, string contrasena)
        {
            var token = "";
            Tecnico sto = null;
            Usuario _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            if (_unusuario is Tecnico)
            {
                sto = (Tecnico)_unusuario;
                if (sto == null)
                { throw new HttpResponseException(HttpStatusCode.BadRequest); }

                token = TokenGenerator.GenerateTokenJwt(cedula.ToString());
            }

            return sto;

        }
        public bool Post([FromBody]Tecnico apiusuario)
        {
           return FabricaLogica.getControladorUsuario().agregarUsuario(apiusuario);

        }
        public bool Put([FromBody]Tecnico apiusuario)
        {
            return FabricaLogica.getControladorUsuario().eliminarUsuario(apiusuario);

        }
        public bool Put(long cedula, [FromBody]Tecnico apiusuario)
        {
            return FabricaLogica.getControladorUsuario().modificarUsuario(cedula, apiusuario);

        }
        public Tecnico getTecnico(long cedula)
        {
            Tecnico tecn = null;
            Usuario _unusuario = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            if (_unusuario is Tecnico)
                tecn = (Tecnico)_unusuario;
            return tecn;


        }
        public List<Tecnico> getTecnicos()
        {
            List<Tecnico> listt = FabricaLogica.getControladorUsuario().listtecnico();
            return listt;


        }

    }
}
