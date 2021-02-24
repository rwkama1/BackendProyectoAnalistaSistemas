using Datos;
using Entidades;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionUsuarios
{
    public class ControladorUsuario : IControladorUsuario
    {
        private static ControladorUsuario _instancia = null;
        private ControladorUsuario() { }
        public static ControladorUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorUsuario();
            return _instancia;
        }
        private Usuario lusu;

        public Usuario Lusu { get { return lusu; } set { lusu = value; } }
        public Usuario ingresarCedula(long cedula)
        {
            Usuario usuic = Lusu;
            if (cedula >= 1)
            {
                usuic = CatalogoUsuarios.GetInstancia().obtenerUsuario(cedula);
                Lusu = usuic;

            }
            else
            {
                throw new Exception("La cedula ingresada no es valida ");
            }

            return usuic;
        }
        public bool agregarUsuario(Usuario agregarusuario)
        {
            bool correcto = false;
            Usuario propusu = Lusu;
            if (propusu == null )
            {
                correcto = true;
                MantenimientoUsuarios.GetInstancia().agregarUsuario(agregarusuario);
                return correcto;
               
            }
            else
            {
               
                throw new Exception("No se puede agregar un usario ya existente");
                
            }
        }
        public bool eliminarUsuario(Usuario eliusuaruio)
        {
            bool correcto = false;
            Usuario propusu = Lusu;
            if (propusu != null)
            {
                correcto = true;
                MantenimientoUsuarios.GetInstancia().eliminarUsuario(eliusuaruio);
              
                return correcto;

            }
            else
            {
              
                throw new Exception("El usuario que se intenta eliminar no existe");

            }
        }
        public bool modificarUsuario(long cedula,Usuario musuario)
        {

            bool correcto = false;
            Usuario propusu = Lusu;
            if (propusu != null)
            {
                correcto = true;
                MantenimientoUsuarios.GetInstancia().modificarUsuario(cedula,musuario);
              
                return correcto;

            }
            else
            {

                throw new Exception("El usuario que se intenta modificar no existe");

            }

        }
        public List<Usuario> listUsuario()
        {
            List<Usuario> lusuario = CatalogoUsuarios.GetInstancia().listUsuario();
         
            return lusuario;
        }
        public List<Tecnico> listtecnico()
        {
            List<Tecnico> listtecnico = CatalogoUsuarios.GetInstancia().listtecnico();

            return listtecnico;
        }
        public List<Cadete> listcadete()
        {
            List<Cadete> listcadete = CatalogoUsuarios.GetInstancia().listcadete();

            return listcadete;
        }

        public List<Vendedor> listvendeor()
        {
            List<Vendedor> listvendeor = CatalogoUsuarios.GetInstancia().listvendeor();

            return listvendeor;
        }
    }
}
