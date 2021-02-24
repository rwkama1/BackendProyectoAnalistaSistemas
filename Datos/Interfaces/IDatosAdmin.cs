using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos.Interfaces
{
    public interface IDatosAdmin
    {
        Administrador Logueo(long cedula, string contraseña);
        List<Administrador> listarAdmin();
        void agregarAdmin(Administrador addadmin);
        void eliminarAdmin(Administrador addadmin);
        void modificarAdmin(long cedula,Administrador madmin);
        Administrador obtenerAdministrador(long cedula);
    }
        
}
