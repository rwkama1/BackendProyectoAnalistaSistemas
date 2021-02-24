using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using Logica;

namespace WebApi.Controllers
{
    public class AutenticacionController : ApiController
    {
        [HttpGet]
        public Usuario Get(long cedula, string contrasena)
        {

            Usuario _unusuario = null;
            _unusuario = FabricaLogica.getLUsuario().iniciarsesion(cedula, contrasena);
            return _unusuario;

        }
        [HttpGet]
        public void Getlogout()
        {
            FabricaLogica.getLUsuario().logout();
        }
    }
}
