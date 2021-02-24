using Datos.Interfaces;
using Entidades;


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    internal class DatosFCompra : IDatosFCompra
    {



        private static DatosFCompra _instancia = null;
        private DatosFCompra() { }
        public static DatosFCompra GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosFCompra();
            return _instancia;
        }

        public List<FacturaCompra> ListarFC()
        {

            FacturaCompra pr = null;
            List<FacturaCompra> list = new List<FacturaCompra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.FacturaCompra
                             select new
                             {
                                 IdFC = p.IdFC,
                                 NumeroFC = p.NumeroFC,
                                 ProvFC = p.ProvFC,
                                 FechaFC = p.FechaFC,
                                 Impuestos=p.ImpuestosFC,
                                 Subtotal=p.SubtotalFC,
                                 Total=p.TotalFC
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new FacturaCompra(r.IdFC,r.NumeroFC,r.ProvFC,r.FechaFC,r.Impuestos,r.Subtotal,r.Total,ListarLFC(r.IdFC));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        private List<LineaFacturaCompra> ListarLFC(int id)
        {

            LineaFacturaCompra pr = null;
            List<LineaFacturaCompra> list = new List<LineaFacturaCompra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.LineaFacturaCompra
                             where p.IdFacturaCompra == id
                             select new
                             {
                                 ProductoLFC = p.ProductoLFC,
                                 IdFacturaCompra = p.IdFacturaCompra,
                                 CantidadLFC = p.CantidadLFC,
                                 ImporteLFC = p.ImporteLFC,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new LineaFacturaCompra();
                        pr.ProductoLFC = r.ProductoLFC;
                        pr.IdFacturaCompra = r.IdFacturaCompra;
                        pr.CantidadLFC = r.CantidadLFC;
                        pr.ImporteLFC = r.ImporteLFC;
                      
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public FacturaCompra obtenerFactura(string numerofc)
        {
            FacturaCompra prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.FacturaCompra
                             where p.NumeroFC == numerofc
                             select new
                             {
                                 IdFC = p.IdFC,
                                 NumeroFC = p.NumeroFC,
                                 ProvFC = p.ProvFC,
                                 FechaFC = p.FechaFC,
                                 Impuestos = p.ImpuestosFC,
                                 Subtotal = p.SubtotalFC,
                                 Total = p.TotalFC,

                             }).FirstOrDefault();

                if (query != null)
                {
                    prod = new FacturaCompra();
                    prod.IdFC = query.IdFC;
                    prod.NumeroFC = query.NumeroFC;
                    prod.ProvFC = query.ProvFC;
                    prod.FechaFC = query.FechaFC;
                    prod.ImpuestosFC = query.Impuestos;
                    prod.SubtotalFC = query.Subtotal;
                    prod.TotalFC = query.Total;
                    prod.Listalineas = ListarLFC(query.IdFC);
                }
                return prod;

            }
        }
        public FacturaCompra obtenerFacturaProvNumber(string numerofc, string prov)
        {
            FacturaCompra prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.FacturaCompra
                             where p.NumeroFC == numerofc && p.ProvFC == prov
                             select new
                             {
                                 IdFC = p.IdFC,
                                 NumeroFC = p.NumeroFC,
                                 ProvFC = p.ProvFC,
                                 FechaFC = p.FechaFC,
                                 Impuestos = p.ImpuestosFC,
                                 Subtotal = p.SubtotalFC,
                                 Total = p.TotalFC
                             }).FirstOrDefault();

                if (query != null)
                {
                    prod = new FacturaCompra();
                    prod.IdFC = query.IdFC;
                    prod.NumeroFC = query.NumeroFC;
                    prod.ProvFC = query.ProvFC;
                    prod.FechaFC = query.FechaFC;
                    prod.ImpuestosFC = query.Impuestos;
                    prod.SubtotalFC = query.Subtotal;
                    prod.TotalFC = query.Total;
                    prod.Listalineas = ListarLFC(query.IdFC);
                }
                return prod;

            }
        }
        public void agregarFacturaCompra(FacturaCompra addp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var fc = new FacturaCompra()
                        {
                            NumeroFC = addp.NumeroFC,
                            FechaFC = addp.FechaFC,
                            ProvFC = addp.ProvFC,
                            ImpuestosFC = addp.ImpuestosFC,
                            SubtotalFC = addp.SubtotalFC,
                            TotalFC = addp.TotalFC

                        };
                        db.FacturaCompra.Add(fc);
                        db.SaveChanges();
                        int id = fc.IdFC;
                        foreach (LineaFacturaCompra l in addp.Listalineas)
                        {
                            db.LineaFacturaCompra.Add(new LineaFacturaCompra()
                            {
                                IdFacturaCompra = id,
                                ProductoLFC = l.ProductoLFC,
                                CantidadLFC = l.CantidadLFC,
                                ImporteLFC = l.ImporteLFC,

                            });
                            db.SaveChanges();

                            var queryProd =
                              from Producto in db.Producto
                              where
                              Producto.IdProducto == l.ProductoLFC
                              select Producto;

                            foreach (var p in queryProd)
                            {
                                p.StockProd += l.CantidadLFC;

                            }
                            db.SaveChanges();
                        }

                        transaction.Commit();

                    }

                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al agregar la Factura", exsql);
                    }
                }

            }
        }
     


    }
}
