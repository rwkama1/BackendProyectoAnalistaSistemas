using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosCadete
    {
        Cadete Logueo(long cedula, string contraseña);
        List<Cadete> listarCadete();
        Cadete obtenerCadete(long cedula);
        void agregarCadete(Cadete addcadete);
        void eliminarCadete(Cadete delcadete);
        void modificarCadete(Cadete mcadete);
    }
}
