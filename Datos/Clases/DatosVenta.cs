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
    internal class DatosVenta : IDatosVenta
    {
        private static DatosVenta _instancia = null;
        private DatosVenta() { }
        public static DatosVenta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosVenta();
            return _instancia;
        }
        public List<Venta> listarVenta()
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,                           
                                 TotalV = p.TotalV,
                                 FormaEntregaV=p.FormaEntregaV,
                                 EstadoV = p.EstadoV,
                                
                             }).ToList();
               

                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV,r.SubtotalV,r.TotalV,r.FormaEntregaV,r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> listarVentaFechas(int cedula, DateTime fecha1, DateTime fecha2)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.ClienteV == cedula && (fecha1 <= p.FechaV && p.FechaV <= fecha2)
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> listarVentasCobradas()
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV.Equals("Cobrada")&& p.FormaEntregaV.Equals("Envio")
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> buscarVentasCobradas(string criterio)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV.Equals("Cobrada") && p.FormaEntregaV.Equals("Envio") && (p.IdV.ToString().Contains(criterio)||p.FechaV.ToString().Contains(criterio))
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> listarVentasPersonales()
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV == "Cerrada" && p.ClienteV == null
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> buscarVentasPersonalesMetodoPago(string criterio)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV == "Cerrada" && p.ClienteV == null && p.MetodoPagoV.Contains(criterio) 
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> listarVentasWeb()
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV == "Cerrada" && p.ClienteV != null
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> buscarVentasWebMetodoPago(string criterio)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV == "Cerrada" && p.ClienteV != null && p.MetodoPagoV.Contains( criterio )
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        private List<LineaVenta> listarLineaVenta(int id)
        {

            LineaVenta pr = null;
            List<LineaVenta> list = new List<LineaVenta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.LineaVenta
                             where p.IdV == id
                             select new
                             {
                                 ProductoLFC = p.ProductoLV,
                                 IdFacturaCompra = p.IdV,
                                 CantidadLFC = p.CantidadLV,
                                 ImporteLFC = p.ImporteLV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new LineaVenta();
                        pr.ProductoLV = r.ProductoLFC;
                        pr.IdV = r.IdFacturaCompra;
                        pr.CantidadLV = r.CantidadLFC;
                        pr.ImporteLV = r.ImporteLFC;
                       

                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public Venta obtenerVenta(int id)
        {
            Venta prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var r = (from p in db.Venta
                             where p.IdV == id
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,
                                

                             }).FirstOrDefault();

                if (r != null)
                {
                    prod = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV,  listarLineaVenta(r.IdV));
                }
                return prod;

            }
        }
        public void agregarVenta(Venta addp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var fc = new Venta()
                        {
                      
                        FechaV = addp.FechaV,
                        VencimientoV = addp.VencimientoV,
                        MetodoPagoV = addp.MetodoPagoV,
                        ClienteV = addp.ClienteV,
                        TarjetaV = null,
                        ImpuestosV = addp.ImpuestosV,
                        SubtotalV = addp.SubtotalV,
                        TotalV = addp.TotalV,
                        FormaEntregaV = addp.FormaEntregaV,
                        EstadoV = addp.EstadoV
                        };
                        db.Venta.Add(fc);
                        db.SaveChanges();
                        int id = fc.IdV;
                        foreach (LineaVenta l in addp.LineaVenta)
                        {
                            db.LineaVenta.Add(new LineaVenta()
                            {
                                IdV = id,
                                ProductoLV = l.ProductoLV,
                                CantidadLV = l.CantidadLV,
                                ImporteLV= l.ImporteLV,

                            });
                            db.SaveChanges();


                        }

                        transaction.Commit();

                    }

                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al agregar la Venta", exsql);
                    }
                }

            }
        }
        public void cobrarVenta(Venta addp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryProd =
                          from Venta in db.Venta
                          where
                          Venta.IdV == addp.IdV
                          select Venta;

                        foreach (var p in queryProd)
                        {
                            p.TarjetaV = addp.TarjetaV;
                            p.EstadoV = addp.EstadoV;
                        }
                        db.SaveChanges();
                        foreach (LineaVenta l in addp.LineaVenta)
                        {
                            var query =
                            from Producto in db.Producto
                            where
                            Producto.IdProducto == l.ProductoLV
                            select Producto;

                            foreach (var s in query)
                            {
                                s.StockProd-= l.CantidadLV;
                            }
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al cobrar la venta", exsql);

                    }
                }
            }
        }
        public List<LineaVenta> listarProductosmasVendidos()
        {
            LineaVenta pr = null;
            List<LineaVenta> list = new List<LineaVenta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.LineaVenta
                             group p by p.ProductoLV into g
                             orderby g.Count() descending
                             select new
                             {
                                 idproducto = g.Key,
                                 cantidadventas = g.Count()
                             });
            
        
                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new LineaVenta();
                        pr.ProductoLV = r.idproducto;
                        pr.Cantidad = r.cantidadventas;
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> buscarVentascriterio(string criterio)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV == "Cerrada" && p.ClienteV.ToString().Contains(criterio)
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> listarVentasCobradasTodas()
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV.Equals("Cobrada")
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> listarVentasClientes(int cedula)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.ClienteV == cedula
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Venta> buscarVentasCobradastodas(string criterio)
        {

            Venta pr = null;
            List<Venta> list = new List<Venta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Venta
                             where p.EstadoV.Equals("Cobrada") && (p.IdV.ToString().Contains(criterio) || p.FechaV.ToString().Contains(criterio))
                             select new
                             {
                                 IdV = p.IdV,
                                 FechaV = p.FechaV,
                                 VencimientoV = p.VencimientoV,
                                 ClienteV = p.ClienteV,
                                 MetodoPago = p.MetodoPagoV,
                                 TarjetaV = p.TarjetaV,
                                 ImpuestosV = p.ImpuestosV,
                                 SubtotalV = p.SubtotalV,
                                 TotalV = p.TotalV,
                                 FormaEntregaV = p.FormaEntregaV,
                                 EstadoV = p.EstadoV,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Venta(r.IdV, r.FechaV, r.VencimientoV, r.MetodoPago, r.ClienteV, r.TarjetaV, r.ImpuestosV, r.SubtotalV, r.TotalV, r.FormaEntregaV, r.EstadoV, listarLineaVenta(r.IdV));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }


    }
}
