using Logica.Clases.GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.OrdenesTaller
{
    public class LOrdenTaller
    {
        int IdOT;
        int ProductoOT;
        System.DateTime FechaOT;
        int ClienteOT;
        string DeclaracionCOT;
        decimal PrecioOT;
        string ComentarioOT;
        LProducto Producto;
       public EstadoOrdenTaller EstadoOT;
        string estado;
        long TecnicoOT;

        public int IdOT1 { get => IdOT; set => IdOT = value; }
        public int ProductoOT1 { get => ProductoOT; set => ProductoOT = value; }
        public DateTime FechaOT1 { get => FechaOT; set => FechaOT = value; }
        public int ClienteOT1 { get => ClienteOT; set => ClienteOT = value; }
        public string DeclaracionCOT1 { get => DeclaracionCOT; set => DeclaracionCOT = value; }
        public decimal PrecioOT1 { get => PrecioOT; set => PrecioOT = value; }
        public string ComentarioOT1 { get => ComentarioOT; set => ComentarioOT = value; }
        public LProducto Producto1 { get => Producto; set => Producto = value; }
        //public EstadoOrdenTaller EstadoOT1 { get => EstadoOT; set => EstadoOT = value; }
        public string Estado { get => estado; set => estado = value; }
        public long TecnicoOT1 { get => TecnicoOT; set => TecnicoOT = value; }
        public LOrdenTaller()
        {
            EstadoOT = new EstadoEnRevision();
            Estado = "En Revision";
            ComentarioOT1 = "Sin Comentario";
            FechaOT1 = DateTime.Now;
            PrecioOT1 = 0;
        }
 
        public void cambiarPresupuestada(string estado)
        {
            EstadoOT = new EstadoEnRevision();
            EstadoOT.cambiarPresupuestada(estado,this);
            EstadoOT = new EstadoPresupuestada();

        }
        public void cambiarNoReparable(string estado,string comentario)
        {
            EstadoOT = new EstadoEnRevision();
            EstadoOT.cambiarNoReparable(estado,comentario, this);
            EstadoOT = new EstadoNoReparable();
        }
        public void reparadaAunTaller(decimal precio, string comentario, string estado)
        {
            EstadoOT = new EstadoAceptada();
            EstadoOT.reparadaAunTaller(precio,comentario, estado, this);
            EstadoOT = new EstadoReparadaTaller();
        }
        public void cambiarNoRepa(string estado, string comentario)
        {
            EstadoOT = new EstadoAceptada();
            EstadoOT.cambiarNoRep(estado, comentario, this);
            EstadoOT = new EstadoNoReparable();
        }
        public void cambiarAceptada(decimal precio, string comentario, string estado)
        {
            EstadoOT = new EstadoPresupuestada();
            EstadoOT.cambiarAceptada(precio,comentario,estado, this);
            EstadoOT = new EstadoAceptada();
        }
        public void cambiarRechazada(string estado, string comentario)
        {
            EstadoOT = new EstadoPresupuestada();
            EstadoOT.cambiarRechazada(estado,comentario, this);
            EstadoOT = new EstadoRechazada();
        }
        public void cambiarPagada(string comentario, string estado)
        {
            EstadoOT = new EstadoReparadaRetirada();
            EstadoOT.cambiarPagada(comentario,estado, this);
            EstadoOT = new EstadoReparadaPagada();
        }
        public void cambiarRetirada(string comentario, string estado)
        {
            EstadoOT = new EstadoReparadaTaller();
           
            EstadoOT.cambiarRetirada(comentario, estado, this);
            EstadoOT = new EstadoReparadaRetirada();
        }
        public OrdenTaller getDataType()
        {      
            OrdenTaller data = new OrdenTaller(IdOT1, ProductoOT1, FechaOT1, ClienteOT1, DeclaracionCOT1,Estado ,PrecioOT1, ComentarioOT1, TecnicoOT);
            return data;
        }
       
    }
}
