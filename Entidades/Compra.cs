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

public partial class Compra
{
    public int IdC { get; set; }
    public System.DateTime FechaC { get; set; }
    public string MetodoPagoC { get; set; }
    public Nullable<int> ClienteC { get; set; }
    public decimal ImpuestosC { get; set; }
    public decimal SubtotalC { get; set; }
    public decimal TotalC { get; set; }
    public string FormaEntregaC { get; set; }
    public string EstadoC { get; set; }
    public List<LineaCompra> LineaCompra { get; set; }

    public Compra(int idC, DateTime fechaC, string metodoPagoC, int? clienteC, decimal impuestosC, decimal subtotalC, decimal totalC, string formaEntregaC, string estadoC, List<LineaCompra> lineaCompra)
    {
        IdC = idC;
        FechaC = fechaC;
        MetodoPagoC = metodoPagoC;
        ClienteC = clienteC;
        ImpuestosC = impuestosC;
        SubtotalC = subtotalC;
        TotalC = totalC;
        FormaEntregaC = formaEntregaC;
        EstadoC = estadoC;
        LineaCompra = lineaCompra;
    }

    public Compra()
    {

    }
}