using Datos;
using Logica.Clases.GestionProductos;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
    internal class ControladorOT : IControladorOT
    {
        private static ControladorOT _instancia = null;
        private ControladorOT() { }
        public static ControladorOT GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ControladorOT();
            return _instancia;
        }
        LOrdenTaller lot;

        public LOrdenTaller Lot { get => lot; set => lot = value; }
        //Ingresar nueva orden taller
        public Producto ingresarProducto(long id)
        {         
           Producto Lprod = CatalogoProductos.GetInstancia().obtProd(id);
            if (Lprod != null)
            {
                LOrdenTaller lordentaller = new LOrdenTaller();
                Lot = lordentaller;
            }
            return Lprod;
        }
        public OrdenTaller agregarOrdenTaller(OrdenTaller ordent)
        {
            LOrdenTaller lOrdenTaller = Lot;
            OrdenTaller ot = lOrdenTaller.getDataType();
            ordent.FechaOT = ot.FechaOT;
            ordent.EstadoOT = ot.EstadoOT;
            ordent.ComentarioOT = ot.ComentarioOT;
            MantenimientoOT.GetInstancia().addot(ordent);
            Lot = null;
            return ordent;
        }
        //Cambiar de estados
        public List<OrdenTaller> listarOrdenTaller()
        {
            return CatalogoOT.GetInstancia().listarOrdenTaller();

        }
        public OrdenTaller seleccionarOrden(int idot)
        {
            OrdenTaller data = CatalogoOT.GetInstancia().buscarOrdenTaller(idot);
            LOrdenTaller lOrdenTaller = CatalogoOT.GetInstancia().getLOrdTaller(data);
            Lot = lOrdenTaller;
            return data;
           

        }
        public OrdenTaller cambiarEstado(decimal precio,string comentario)
        {

            LOrdenTaller lOrdenTaller = Lot;
            OrdenTaller dataot = null;
            if (lOrdenTaller.Estado.Equals("En Revision"))
            {
                lOrdenTaller.cambiarPresupuestada("Presupuestada");
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }
           else if (lOrdenTaller.Estado.Equals("Presupuestada"))
            {
                lOrdenTaller.cambiarAceptada(precio,comentario,"Aceptada");
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }
           else if (lOrdenTaller.Estado.Equals("Aceptada"))
            {
                lOrdenTaller.reparadaAunTaller(precio,comentario,"Reparada(Aun en Taller)");
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }
            else if(lOrdenTaller.Estado.Equals("Reparada(Aun en Taller)"))
            {
                lOrdenTaller.cambiarRetirada( comentario,"Reparada(Retirada)");
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }
            else if (lOrdenTaller.Estado.Equals("Reparada(Retirada)"))
            {
                lOrdenTaller.cambiarPagada(comentario,"Reparada(Pagada)");
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }

            return dataot;
        }
        public OrdenTaller RechazarONoReparable(string comentario)
        {

            LOrdenTaller lOrdenTaller = Lot;
            OrdenTaller dataot = null;
            if (lOrdenTaller.Estado.Equals("En Revision"))
            {
                lOrdenTaller.cambiarNoReparable("No Reparable",comentario);
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }
            else if (lOrdenTaller.Estado.Equals("Presupuestada"))
            {
                lOrdenTaller.cambiarRechazada("Rechazada", comentario);
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }
           else if (lOrdenTaller.Estado.Equals("Aceptada"))
            {
                lOrdenTaller.cambiarNoRepa("No Reparable", comentario);
                dataot = lOrdenTaller.getDataType();
                MantenimientoOT.GetInstancia().cambiarEstado(dataot);
            }

            return dataot;
        }
        public List<OrdenTaller> listarOrdenTallerCriterio(string algo)
        {
            return CatalogoOT.GetInstancia().listarOrdenesTallerCriterio(algo);

        }
        public List<OrdenTaller> listarOrdenesTallerCliente(int cedula)
        {
            return CatalogoOT.GetInstancia().listarOrdenesTallerCliente(cedula);

        }
        public List<OrdenTaller> listarOrdenesTallerTecnico(int tec)
        {
            return CatalogoOT.GetInstancia().listarOrdenesTallerTecnico(tec);

        }
     
    }
}
