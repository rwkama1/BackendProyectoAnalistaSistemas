using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers.Token;

namespace WebApi.Controllers
{
    public class AdminController : ApiController

    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
       
        [HttpGet]
        public Administrador getLogin(long cedula, string contrasena)
        {
            var token = "";
            Administrador adminc = null;
            Usuario _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            if (_unusuario is Administrador)
            {
                adminc = (Administrador)_unusuario;
                if (adminc == null)
                { throw new HttpResponseException(HttpStatusCode.BadRequest); }
                
                token = TokenGenerator.GenerateTokenJwt(cedula.ToString());
            }

            return adminc;
        }
        [HttpPost]
        public bool agregarAdmin([FromBody]Administrador apiusuario)

        {
            return FabricaLogica.getControladorUsuario().agregarUsuario(apiusuario);

        }
        [HttpDelete]
        public bool eliminarAdmin([FromBody]Administrador apiusuario)
        {
            return FabricaLogica.getControladorUsuario().eliminarUsuario(apiusuario);

        }
        [HttpPut]
        public HttpResponseMessage modificarAdmin(long cedula, [FromBody]Administrador apiusuario)
        {
            try
            {
                bool verdadero = true;
                verdadero = FabricaLogica.getControladorUsuario().modificarUsuario(cedula, apiusuario);
                return Request.CreateResponse(HttpStatusCode.OK, verdadero);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
      
        public Administrador getAdmin(long cedula)
        { 
            Administrador adminc = null;
            Usuario _unusuario = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            if (_unusuario is Administrador)
                adminc = (Administrador)_unusuario;
            return adminc;
           

        }
    }
}
