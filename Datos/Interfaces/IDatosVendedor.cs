using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos.Interfaces
{
    public interface IDatosVendedor
    {
        Vendedor Logueo(long cedula, string contraseña);
        List<Vendedor> listarVendedor();
        Vendedor obtenerVendedor(long cedula);
        void agregarVenedor(Vendedor addvendedor);
        void eliminarVendedor(Vendedor delven);
        void modificarVendedor(Vendedor mvend);
    }
}
