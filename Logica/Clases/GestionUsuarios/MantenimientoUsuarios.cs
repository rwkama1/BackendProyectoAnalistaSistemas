using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.GestionUsuarios
{
    public class MantenimientoUsuarios
    {
        private static MantenimientoUsuarios _instancia = null;

        public static MantenimientoUsuarios GetInstancia()
        {
            if (_instancia == null)
                _instancia = new MantenimientoUsuarios();
            return _instancia;
        }

        public void agregarUsuario(Usuario addusuario)
        {
            if (addusuario is Administrador)
            {
                FabricaDatos.getPAdmin().agregarAdmin((Administrador)addusuario);
            }
            else if (addusuario is Cadete)
            { FabricaDatos.getPCadete().agregarCadete((Cadete)addusuario); }
            else if (addusuario is Cajero)
            { FabricaDatos.getPCajero().agregarCajero((Cajero)addusuario); }
            else if (addusuario is Stocker)
            { FabricaDatos.getPStocker().agregarStocker((Stocker)addusuario); }
            else if (addusuario is Tecnico)
            { FabricaDatos.getPTecnicos().agregarTecnico((Tecnico)addusuario); }
            else if (addusuario is Vendedor)
            { FabricaDatos.getPVendeor().agregarVenedor((Vendedor)addusuario); }
        }
        public void eliminarUsuario(Usuario delusuario)
        {
            if (delusuario is Administrador)
            {
                FabricaDatos.getPAdmin().eliminarAdmin((Administrador)delusuario);
            }
            else if (delusuario is Cadete)
            { FabricaDatos.getPCadete().eliminarCadete((Cadete)delusuario); }
            else if (delusuario is Cajero)
            { FabricaDatos.getPCajero().eliminarCajero((Cajero)delusuario); }
            else if (delusuario is Stocker)
            { FabricaDatos.getPStocker().eliminarStocker((Stocker)delusuario); }
            else if (delusuario is Tecnico)
            { FabricaDatos.getPTecnicos().eliminarTecnico((Tecnico)delusuario); }
            else if (delusuario is Vendedor)
            { FabricaDatos.getPVendeor().eliminarVendedor((Vendedor)delusuario); }

        }
        public void modificarUsuario(long cedula,Usuario musuario)
        {
            if (musuario is Administrador)
            {
                FabricaDatos.getPAdmin().modificarAdmin(cedula, (Administrador)musuario);
            }
            else if (musuario is Cadete)
            { FabricaDatos.getPCadete().modificarCadete((Cadete)musuario); }
            else if (musuario is Cajero)
            { FabricaDatos.getPCajero().modificarCajero((Cajero)musuario); }
            else if (musuario is Stocker)
            { FabricaDatos.getPStocker().modificarStocker((Stocker)musuario); }
            else if (musuario is Tecnico)
            { FabricaDatos.getPTecnicos().modificarTecnico((Tecnico)musuario); }
            else if (musuario is Vendedor)
            { FabricaDatos.getPVendeor().modificarVendedor((Vendedor)musuario); }



        }
    }
    
}
