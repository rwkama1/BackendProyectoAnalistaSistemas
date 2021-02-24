using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IDatosCliente
    {
        void agregarCliente(Cliente cli);
        void modificarCliente(Cliente clim);
        List<Cliente> listarCliente();
        Cliente Logueo(int cedula, string contraseña);
        Cliente buscarcli(int cedula);
    }
}
