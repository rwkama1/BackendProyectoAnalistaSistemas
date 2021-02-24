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

public partial class Producto
{
    public int IdProducto { get; set; }
    public string NomProd { get; set; }
    public string DescProd { get; set; }
    public long StockProd { get; set; }
    public string UbicProd { get; set; }
    public decimal PrecioProd { get; set; }
    public string CatProd { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<LineaVenta> LineaVenta { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<LineaCompra> LineaCompra { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<LineaFacturaCompra> LineaFacturaCompra { get; set; }
    public virtual OrdenEnvio OrdenEnvio { get; set; }
    public virtual OrdenTaller OrdenTaller { get; set; }
    public virtual ProductosOE ProductosOE { get; set; }
    public bool BajaProd { get; set; }
    

    public Producto(int idProducto, string nomProd, string descProd, long stockProd, string ubicProd, decimal precioProd, string catProd,bool bajaprod)
    {
        IdProducto = idProducto;
        NomProd = nomProd;
        DescProd = descProd;
        StockProd = stockProd;
        UbicProd = ubicProd;
        PrecioProd = precioProd;
        CatProd = catProd;
        BajaProd = bajaprod;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Producto()
    {

    }
}