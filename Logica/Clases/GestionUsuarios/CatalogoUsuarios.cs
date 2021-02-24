using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica.Clases.GestionUsuarios
{
    public class CatalogoUsuarios

    {
        private static CatalogoUsuarios _instancia = null;
        public static CatalogoUsuarios GetInstancia()
        {
            if (_instancia == null)
                _instancia = new CatalogoUsuarios();
            return _instancia;
        }
        private List<Usuario> lusuario;
        public List<Usuario> Lusuario { get { return lusuario; }  }
       
        public Usuario obtenerUsuario(long cedula)
        {
            Usuario obtsu = null;
            if (cedula >= 1)
            {
                obtsu = FabricaDatos.getPAdmin().obtenerAdministrador(cedula);
                if (obtsu == null)
                {
                    obtsu = FabricaDatos.getPCadete().obtenerCadete(cedula);
                }
                if (obtsu == null)
                { obtsu = FabricaDatos.getPStocker().obtenerStocker(cedula); }
                if (obtsu == null)
                { obtsu = FabricaDatos.getPTecnicos().obtenerTecnico(cedula); }
                if (obtsu == null)
                { obtsu = FabricaDatos.getPVendeor().obtenerVendedor(cedula); }
                if (obtsu == null)
                { obtsu = FabricaDatos.getPCajero().obtenerCajero(cedula); }
              
            }
            else
            { throw new Exception("La cedula debes ser mayor o igual a 1"); }
            return obtsu;
        }
        public List<Usuario> listUsuario()
        {
            lusuario = new List<Usuario>();

            lusuario.AddRange(FabricaDatos.getPAdmin().listarAdmin());
            lusuario.AddRange(FabricaDatos.getPCadete().listarCadete());
            lusuario.AddRange(FabricaDatos.getPCajero().listarCajero());
            lusuario.AddRange(FabricaDatos.getPStocker().listarStocker());
            lusuario.AddRange(FabricaDatos.getPTecnicos().listarTecnico());
            lusuario.AddRange(FabricaDatos.getPVendeor().listarVendedor());
            return lusuario;
        }
        public List<Tecnico> listtecnico()
        {
            List<Tecnico> listtecnico = FabricaDatos.getPTecnicos().listarTecnico();

            return listtecnico;
        }
        public List<Cadete> listcadete()
        {
            List<Cadete> listcadete = FabricaDatos.getPCadete().listarCadete();

            return listcadete;
        }

        public List<Vendedor> listvendeor()
        {
            List<Vendedor> listvendeor = FabricaDatos.getPVendeor().listarVendedor();

            return listvendeor;
        }
    }
}
