using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UsuController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        public Usuario GetingresarCedula(long cedula)
        {
            Usuario apiusu = null;
            apiusu = FabricaLogica.getControladorUsuario().ingresarCedula(cedula);
            return apiusu;
        }
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listusu = FabricaLogica.getControladorUsuario().listUsuario();
            return listusu;
        }
       


    }
}
