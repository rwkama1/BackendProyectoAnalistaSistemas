//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class OrdenTaller
{
    public int IdOT { get; set; }
    public int ProductoOT { get; set; }
    public System.DateTime FechaOT { get; set; }
    public int ClienteOT { get; set; }
    public string DeclaracionCOT { get; set; }
    public string EstadoOT { get; set; }
    public decimal PrecioOT { get; set; }
    public string ComentarioOT { get; set; }
    public long TecnicoOT { get; set; }
    public virtual Producto Producto { get; set; }

    public OrdenTaller(int idOT, int productoOT, DateTime fechaOT, int clienteOT, string declaracionCOT, string estadoOT, decimal precioOT, string comentarioOT,long tecnicoOT)
    {
        IdOT = idOT;
        ProductoOT = productoOT;
        FechaOT = fechaOT;
        ClienteOT = clienteOT;
        DeclaracionCOT = declaracionCOT;
        EstadoOT = estadoOT;
        PrecioOT = precioOT;
        ComentarioOT = comentarioOT;
        TecnicoOT = tecnicoOT;
    }

    public OrdenTaller()
    {
    }
}