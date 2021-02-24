using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosStocker
    {
        Stocker Logueo(long cedula, string contraseña);
        List<Stocker> listarStocker();
        Stocker obtenerStocker(long cedula);
        void agregarStocker(Stocker addstocker);
        void eliminarStocker(Stocker delstocker);
        void modificarStocker(Stocker mstocker);
    }
}
