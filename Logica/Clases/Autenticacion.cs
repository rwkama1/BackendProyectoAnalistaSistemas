using Datos;

using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica.Clases
{
    public class Autenticacion:IAutenticacion
    {
        private static Autenticacion _instancia = null;
        private Autenticacion() { }
        public static Autenticacion GetInstancia()
        {
            if (_instancia == null)
                _instancia = new Autenticacion();
            return _instancia;
        }
        private Usuario lusu;

        public Usuario Lusu {get {return lusu; }  set { lusu = value; } }

        public Usuario iniciarsesion(long cedula, string contraseña)
        {
            Usuario usulogin = Lusu;
            try
            {
                if (cedula >= 1)
                {
                    usulogin = FabricaDatos.getPAdmin().Logueo(cedula, contraseña);
                    if (usulogin == null)
                    {
                        usulogin = FabricaDatos.getPCadete().Logueo(cedula, contraseña);
                    }
                    if (usulogin == null)
                    { usulogin = FabricaDatos.getPStocker().Logueo(cedula, contraseña); }
                    if (usulogin == null)
                    { usulogin = FabricaDatos.getPTecnicos().Logueo(cedula, contraseña); }
                    if (usulogin == null)
                    { usulogin = FabricaDatos.getPVendeor().Logueo(cedula, contraseña); }
                    if (usulogin == null)
                    { usulogin = FabricaDatos.getPCajero().Logueo(cedula, contraseña); }
                    Lusu=usulogin;
                }
                else
                { throw new Exception("La cedula debes ser mayor o igual a 1"); }
            }
            catch(Exception ex)
            { throw new Exception(ex.Message); }
            return usulogin;
        }
        public void logout()
        {
            Usuario usulogout = Lusu;
            if (usulogout != null)
                usulogout = null;
        }
        private Cliente lcli;

        public Cliente Lcli { get { return lcli; } set { lcli = value; } }
       
        public Cliente logincliente(int cedula, string contraseña)
        {
            Cliente usulogin = Lcli;

            usulogin = FabricaDatos.getCliente().Logueo(cedula, contraseña);


            return usulogin;
        }
        public void logoutcli()
        {
            Cliente clilogout = Lcli;
            if (clilogout != null)
                clilogout = null;
        }
    }


}
