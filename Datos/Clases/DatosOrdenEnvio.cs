using Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Datos.Clases
{
    internal class DatosOrdenEnvio : IDatosOrdenEnvio
    {
        private static DatosOrdenEnvio _instancia = null;
        private DatosOrdenEnvio() { }
        public static DatosOrdenEnvio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosOrdenEnvio();
            return _instancia;
        }
        public void agregarOE(OrdenEnvio cli)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var fc = new OrdenEnvio()
                        {
                            CadeteOE=cli.CadeteOE,
                            ClienteOE = cli.ClienteOE,
                            VentaOE = cli.VentaOE,
                            LocalidadOE = cli.LocalidadOE,
                            UbicacionOE = cli.UbicacionOE,
                            FechaOE = cli.FechaOE,
                            EstadoOE = cli.EstadoOE,

                        };
                        db.OrdenEnvio.Add(fc);
                        db.SaveChanges();
                        int id = fc.IdOE;
                        foreach (ProductosOE l in cli.ProductosOrdenEnvio)
                        {
                            db.ProductosOE.Add(new ProductosOE()
                            {
                               IdOrdenE = id,
                               POE = l.POE,
                            });
                            db.SaveChanges();

                        }

                        transaction.Commit();
                    }

                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al agregar la Orden de Envio", exsql);
                    }
                }
            }
        }
        public void cambiarEstado(OrdenEnvio ot)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryot =
                      from OrdenEnvio in db.OrdenEnvio
                      where
                      OrdenEnvio.IdOE == ot.IdOE
                      select OrdenEnvio;

                    foreach (var p in queryot)
                    {
                        p.EstadoOE = "Aceptada";
                     
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al modificar la Orden de Envio", exsql);

                }

            }

        }
        public List<OrdenEnvio> listarOrdenesEnvioPendiente()
        {

            OrdenEnvio ot = null;
            List<OrdenEnvio> list = new List<OrdenEnvio>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenEnvio
                             where p.EstadoOE.Equals("Pendiente")
                             select new
                             {
                                 IdOE = p.IdOE,
                                 VentaOE = p.VentaOE,
                                 ClienteOE = p.ClienteOE,
                                 CadeteOE = p.CadeteOE,
                                 DepartamentoOE=p.LocalidadOE,
                                 UbicacionOE = p.UbicacionOE,
                                 FechaOE = p.FechaOE,
                                 EstadoOE = p.EstadoOE,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenEnvio(r.IdOE, r.VentaOE,r.ClienteOE,r.CadeteOE, r.UbicacionOE, r.FechaOE, r.EstadoOE, listarProductosOE(r.IdOE),r.DepartamentoOE);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
        public List<OrdenEnvio> listarOrdenesEnvioCadete(long cadete)
        {

            OrdenEnvio ot = null;
            List<OrdenEnvio> list = new List<OrdenEnvio>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenEnvio
                             where p.CadeteOE.Equals(cadete)&& p.EstadoOE.Equals("Pendiente")
                             select new
                             {
                                 IdOE = p.IdOE,
                                 VentaOE = p.VentaOE,
                                 ClienteOE = p.ClienteOE,
                                 DepartamentoOE = p.LocalidadOE,
                                 CadeteOE = p.CadeteOE,
                                 UbicacionOE = p.UbicacionOE,
                                 FechaOE = p.FechaOE,
                                 EstadoOE = p.EstadoOE,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenEnvio(r.IdOE, r.VentaOE, r.ClienteOE, r.CadeteOE, r.UbicacionOE, r.FechaOE, r.EstadoOE, listarProductosOE(r.IdOE), r.DepartamentoOE);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
        public List<OrdenEnvio> listarOrdenesEnvioCliente(int cliente)
        {

            OrdenEnvio ot = null;
            List<OrdenEnvio> list = new List<OrdenEnvio>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenEnvio
                             where p.ClienteOE.Equals(cliente) && p.EstadoOE.Equals("Pendiente")
                             select new
                             {
                                 IdOE = p.IdOE,
                                 VentaOE = p.VentaOE,
                                 ClienteOE = p.ClienteOE,
                                 DepartamentoOE = p.LocalidadOE,
                                 CadeteOE = p.CadeteOE,
                                 UbicacionOE = p.UbicacionOE,
                                 FechaOE = p.FechaOE,
                                 EstadoOE = p.EstadoOE,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenEnvio(r.IdOE, r.VentaOE, r.ClienteOE, r.CadeteOE, r.UbicacionOE, r.FechaOE, r.EstadoOE, listarProductosOE(r.IdOE), r.DepartamentoOE);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
        internal List<ProductosOE> listarProductosOE(int id)
        {

            ProductosOE ot = null;
            List<ProductosOE> list = new List<ProductosOE>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.ProductosOE
                             where p.IdOrdenE.Equals(id)
                             select new
                             {
                                 IdProdOE = p.IdProdOE,
                                  POE = p.POE,
                                 IdOrdenE = p.IdOrdenE,
                                


                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new ProductosOE(r.IdProdOE, r.POE, r.IdOrdenE);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
        public List<OrdenEnvio> listarOrdenesEnvio()
        {

            OrdenEnvio ot = null;
            List<OrdenEnvio> list = new List<OrdenEnvio>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenEnvio
                            
                             select new
                             {
                                 IdOE = p.IdOE,
                                 VentaOE = p.VentaOE,
                                 ClienteOE = p.ClienteOE,
                                 DepartamentoOE = p.LocalidadOE,
                                 CadeteOE = p.CadeteOE,
                                 UbicacionOE = p.UbicacionOE,
                                 FechaOE = p.FechaOE,
                                 EstadoOE = p.EstadoOE,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenEnvio(r.IdOE, r.VentaOE, r.ClienteOE, r.CadeteOE, r.UbicacionOE, r.FechaOE, r.EstadoOE, listarProductosOE(r.IdOE),r.DepartamentoOE);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }

        public OrdenEnvio buscarOrdenesEnvio(int id)
        {

            OrdenEnvio ot = null;
         
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var r = (from p in db.OrdenEnvio
                             where p.IdOE.Equals(id)
                             select new
                             {
                                 IdOE = p.IdOE,
                                 VentaOE = p.VentaOE,
                                 ClienteOE = p.ClienteOE,
                                 CadeteOE = p.CadeteOE,
                                 DepartamentoOE = p.LocalidadOE,
                                 UbicacionOE = p.UbicacionOE,
                                 FechaOE = p.FechaOE,
                                 EstadoOE = p.EstadoOE,

                             }).FirstOrDefault();


                if (r != null)
                {
                    

                        ot = new OrdenEnvio(r.IdOE, r.VentaOE,r.ClienteOE,r.CadeteOE, r.UbicacionOE, r.FechaOE, r.EstadoOE, listarProductosOE(r.IdOE),r.DepartamentoOE);

                       
                  
                }

            }

            return ot;
        }
    }
}

