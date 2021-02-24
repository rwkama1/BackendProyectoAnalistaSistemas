using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorUsuario
    {
        Usuario ingresarCedula(long cedula);
        bool agregarUsuario(Usuario agregarusuario);
        bool eliminarUsuario(Usuario eliusuaruio);
        bool modificarUsuario(long cedula,Usuario musuario);
        List<Usuario> listUsuario();
        List<Tecnico> listtecnico();
        List<Cadete> listcadete();
        List<Vendedor> listvendeor();


    }
}
