using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosCajero
    {
        Cajero Logueo(long cedula, string contraseña);
        List<Cajero> listarCajero();
        Cajero obtenerCajero(long cedula);
        void agregarCajero(Cajero addcajero);
        void eliminarCajero(Cajero delcajero);
        void modificarCajero(Cajero mcajero);
    }
}
