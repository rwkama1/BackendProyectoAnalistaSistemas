using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IControladorCliente
    {
        bool addcliente(Cliente cli);
        bool modificarCliente(Cliente cliente);
        List<Cliente> listcliente();
        Cliente buscarcli(int cedula);
    }
}
