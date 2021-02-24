using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Logica.Interfaces
{
    public interface IAutenticacion
    {
        Usuario iniciarsesion(long cedula, string contraseña);
        void logout();
        Cliente logincliente(int cedula, string contraseña);
        void logoutcli();
    }
}
