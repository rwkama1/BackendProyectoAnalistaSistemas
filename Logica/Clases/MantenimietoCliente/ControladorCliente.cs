using Datos;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.MantenimietoCliente
{
    internal class ControladorCliente : IControladorCliente
    {
        private static ControladorCliente _instancia = null;
        private ControladorCliente() { }
        public static ControladorCliente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorCliente();
            return _instancia;
        }
        public bool addcliente(Cliente cli)
        {
            bool correcto = true;
            MantenimientoCliente.GetInstancia().addcli(cli);
            return correcto;

        }
        public bool modificarCliente(Cliente cliente)
        {
            bool correcto = true;
            MantenimientoCliente.GetInstancia().modcli(cliente);
            return correcto;
        }
        public List<Cliente> listcliente()
        {
         
            List<Cliente> cli = FabricaDatos.getCliente().listarCliente();

            return cli;
        }
        public  Cliente buscarcli(int cedula)
        {

            return FabricaDatos.getCliente().buscarcli(cedula);

        }

    }
}
