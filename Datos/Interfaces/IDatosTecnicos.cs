using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosTecnicos
    {
        Tecnico Logueo(long cedula, string contraseña);
        List<Tecnico> listarTecnico();
        Tecnico obtenerTecnico(long cedula);
        void agregarTecnico(Tecnico addtecn);
        void eliminarTecnico(Tecnico deltecn);
        void modificarTecnico(Tecnico mtec);
    }
}
