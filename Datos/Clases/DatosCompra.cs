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
    internal class DatosCompra : IDatosCompra
    {
        private static DatosCompra _instancia = null;
        private DatosCompra() { }
        public static DatosCompra GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosCompra();
            return _instancia;
        }
        public List<Compra> listarCompraPendientes()
        {

            Compra pr = null;
            List<Compra> list = new List<Compra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Compra
                             where p.EstadoC.Equals("Pendiente")
                             select new
                             {
                                 IdC = p.IdC,
                                 FechaC = p.FechaC,
                                 ClienteC = p.ClienteC,
                                 MetodoPagoC = p.MetodoPagoC,
                                 ImpuestosC = p.ImpuestosC,
                                 SubtotalC = p.SubtotalC,
                                 TotalC = p.TotalC,
                                 FormaEntregaC = p.FormaEntregaC,
                                 EstadoC = p.EstadoC,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Compra(r.IdC, r.FechaC, r.MetodoPagoC, r.ClienteC, r.ImpuestosC, r.SubtotalC, r.TotalC, r.FormaEntregaC, r.EstadoC, listarLCompra(r.IdC));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Compra> listarCompra()
        {

            Compra pr = null;
            List<Compra> list = new List<Compra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Compra
                             select new
                             {
                                 IdC = p.IdC,
                                 FechaC = p.FechaC,
                                 ClienteC= p.ClienteC,
                                 MetodoPagoC = p.MetodoPagoC,
                                 ImpuestosC = p.ImpuestosC,
                                 SubtotalC = p.SubtotalC,
                                 TotalC = p.TotalC,
                                 FormaEntregaC = p.FormaEntregaC,
                                 EstadoC= p.EstadoC,
                               
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Compra(r.IdC, r.FechaC, r.MetodoPagoC, r.ClienteC, r.ImpuestosC, r.SubtotalC, r.TotalC, r.FormaEntregaC, r.EstadoC, listarLCompra(r.IdC));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
       
        public List<Compra> listarCompraCliente(int cedula,DateTime fecha1,DateTime fecha2)
        {

            Compra pr = null;
            List<Compra> list = new List<Compra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Compra
                             where p.ClienteC == cedula && (fecha1 <= p.FechaC && p.FechaC <= fecha2)
                             select new
                             {
                                 IdC = p.IdC,
                                 FechaC = p.FechaC,
                                 ClienteC = p.ClienteC,
                                 MetodoPagoC = p.MetodoPagoC,
                                 ImpuestosC = p.ImpuestosC,
                                 SubtotalC = p.SubtotalC,
                                 TotalC = p.TotalC,
                                 FormaEntregaC = p.FormaEntregaC,
                                 EstadoC = p.EstadoC,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Compra(r.IdC, r.FechaC, r.MetodoPagoC, r.ClienteC, r.ImpuestosC, r.SubtotalC, r.TotalC, r.FormaEntregaC, r.EstadoC, listarLCompra(r.IdC));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Compra> listarCompraClientee(int cedula)
        {

            Compra pr = null;
            List<Compra> list = new List<Compra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Compra
                             where p.ClienteC == cedula 
                             select new
                             {
                                 IdC = p.IdC,
                                 FechaC = p.FechaC,
                                 ClienteC = p.ClienteC,
                                 MetodoPagoC = p.MetodoPagoC,
                                 ImpuestosC = p.ImpuestosC,
                                 SubtotalC = p.SubtotalC,
                                 TotalC = p.TotalC,
                                 FormaEntregaC = p.FormaEntregaC,
                                 EstadoC = p.EstadoC,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Compra(r.IdC, r.FechaC, r.MetodoPagoC, r.ClienteC, r.ImpuestosC, r.SubtotalC, r.TotalC, r.FormaEntregaC, r.EstadoC, listarLCompra(r.IdC));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        private List<LineaCompra> listarLCompra(int id)
        {

            LineaCompra pr = null;
            List<LineaCompra> list = new List<LineaCompra>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.LineaCompra
                             where p.IdC == id
                             select new
                             {
                                 IdLC = p.IdLC,
                                 ProductoLC =p.ProductoLC ,
                                 IdC= p.IdC,
                                 CantidadLC = p.CantidadLC,
                                 ImporteLC = p.ImporteLC,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new LineaCompra();
                        pr.IdLC = r.IdLC;
                        pr.ProductoLC = r.ProductoLC;
                        pr.IdC = r.IdC;
                        pr.CantidadLC = r.CantidadLC;
                        pr.ImporteLC = r.ImporteLC;

                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public Compra obtenerCompra(int id)
        {
            Compra prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var r = (from p in db.Compra
                         where p.IdC == id
                         select new
                         {
                             IdC = p.IdC,
                             FechaC = p.FechaC,
                             ClienteC = p.ClienteC,
                             MetodoPagoC = p.MetodoPagoC,
                             ImpuestosC = p.ImpuestosC,
                             SubtotalC = p.SubtotalC,
                             TotalC = p.TotalC,
                             FormaEntregaC = p.FormaEntregaC,
                             EstadoC = p.EstadoC,
                           
                         }).FirstOrDefault();

                if (r != null)
                {
                    prod = new Compra(r.IdC, r.FechaC, r.MetodoPagoC, r.ClienteC, r.ImpuestosC, r.SubtotalC, r.TotalC, r.FormaEntregaC, r.EstadoC, listarLCompra(r.IdC));
                }
                return prod;

            }
        }
        public void agregarCompra(Compra addp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var fc = new Compra()
                        {
                            FechaC = addp.FechaC,
                            MetodoPagoC = addp.MetodoPagoC,
                            ClienteC = addp.ClienteC,
                            ImpuestosC = addp.ImpuestosC,
                            SubtotalC = addp.SubtotalC,
                            TotalC = addp.TotalC,
                            FormaEntregaC = addp.FormaEntregaC,
                            EstadoC =addp.EstadoC,
                        };
                        db.Compra.Add(fc);
                        db.SaveChanges();
                        int id = fc.IdC;
                        foreach (LineaCompra l in addp.LineaCompra)
                        {
                            db.LineaCompra.Add(new LineaCompra()
                            {
                                IdC = id,
                                ProductoLC = l.ProductoLC,
                                CantidadLC = l.CantidadLC,
                                ImporteLC = l.ImporteLC,

                            });
                            db.SaveChanges();

                           
                        }

                        transaction.Commit();

                    }

                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al agregar la Compra", exsql);
                    }
                }

            }
        }
        public void rechazarCompra(int idcompra)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryProd =
                      from Compra in db.Compra
                      where
                      Compra.IdC == idcompra
                      select Compra;

                    foreach (var p in queryProd)
                    {
                        p.EstadoC = "Rechazada";   
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al rechazar la compra", exsql);

                }

            }
        }
        public void aceptarCompra(int idcompra)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryProd =
                      from Compra in db.Compra
                      where
                      Compra.IdC == idcompra
                      select Compra;

                    foreach (var p in queryProd)
                    {
                        p.EstadoC ="Aceptada";
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al aceptar la compra", exsql);

                }

            }
        }
    }
}
