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
    internal class DatosOrdenTaller : IDatosOrdenTaller
    {
        private static DatosOrdenTaller _instancia = null;
        private DatosOrdenTaller() { }
        public static DatosOrdenTaller GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosOrdenTaller();
            return _instancia;
        }
        public void agregarOT(OrdenTaller cli)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {

                try
                {
                    db.OrdenTaller.Add(new OrdenTaller()
                    {
                        ProductoOT = cli.ProductoOT,
                        FechaOT = cli.FechaOT,
                        ClienteOT = cli.ClienteOT,
                        DeclaracionCOT = cli.DeclaracionCOT,
                        EstadoOT = cli.EstadoOT,
                        PrecioOT = cli.PrecioOT,
                        ComentarioOT = cli.ComentarioOT,
                        TecnicoOT = cli.TecnicoOT
                });
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {
                    throw new Exception("Ocurrio un error al agregar la Orden de Taller", exsql);
                }
            }
        }
        public void cambiarEstado(OrdenTaller ot)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryot =
                      from OrdenTaller in db.OrdenTaller
                      where
                      OrdenTaller.IdOT == ot.IdOT
                      select OrdenTaller;

                    foreach (var p in queryot)
                    {
                        p.EstadoOT = ot.EstadoOT;
                        p.PrecioOT = ot.PrecioOT;
                        p.ComentarioOT = ot.ComentarioOT;
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al modificar la Orden de Taller", exsql);

                }

            }

        }
        public List<OrdenTaller> listarOrdenesTaller()
        {

            OrdenTaller ot = null;
            List<OrdenTaller> list = new List<OrdenTaller>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenTaller
                             select new
                             {
                                 IdOT = p.IdOT,
                                 ProductoOT = p.ProductoOT,
                                 FechaOT = p.FechaOT,
                                 ClienteOT = p.ClienteOT,
                                 DeclaracionCOT = p.DeclaracionCOT,
                                 EstadoOT = p.EstadoOT,
                                 PrecioOT = p.PrecioOT,
                                 ComentarioOT = p.ComentarioOT,
                                 TecnicoOT=p.TecnicoOT,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenTaller(r.IdOT, r.ProductoOT, r.FechaOT, r.ClienteOT, r.DeclaracionCOT, r.EstadoOT, r.PrecioOT, r.ComentarioOT,r.TecnicoOT);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
        public List<OrdenTaller> listarOrdenesTallerCliente(int cedula)
        {

            OrdenTaller ot = null;
            List<OrdenTaller> list = new List<OrdenTaller>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenTaller
                             where p.ClienteOT.Equals(cedula)
                             select new
                             {
                                 IdOT = p.IdOT,
                                 ProductoOT = p.ProductoOT,
                                 FechaOT = p.FechaOT,
                                 ClienteOT = p.ClienteOT,
                                 DeclaracionCOT = p.DeclaracionCOT,
                                 EstadoOT = p.EstadoOT,
                                 PrecioOT = p.PrecioOT,
                                 ComentarioOT = p.ComentarioOT,
                                 TecnicoOT = p.TecnicoOT,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenTaller(r.IdOT, r.ProductoOT, r.FechaOT, r.ClienteOT, r.DeclaracionCOT, r.EstadoOT, r.PrecioOT, r.ComentarioOT, r.TecnicoOT);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
        public OrdenTaller buscarOrdenTaller(int idot)
        {
            OrdenTaller ot = null;         
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var r = (from p in db.OrdenTaller
                             where p.IdOT==idot
                             select new
                             {
                                 IdOT = p.IdOT,
                                 ProductoOT = p.ProductoOT,
                                 FechaOT = p.FechaOT,
                                 ClienteOT = p.ClienteOT,
                                 DeclaracionCOT = p.DeclaracionCOT,
                                 EstadoOT = p.EstadoOT,
                                 PrecioOT = p.PrecioOT,
                                 ComentarioOT = p.ComentarioOT,
                                 TecnicoOT = p.TecnicoOT,

            }).FirstOrDefault();
                if (r != null)
                {         

                        ot = new OrdenTaller(r.IdOT, r.ProductoOT, r.FechaOT, r.ClienteOT, r.DeclaracionCOT, r.EstadoOT, r.PrecioOT, r.ComentarioOT,r.TecnicoOT); 
                }

            }

            return ot;
        }
        public List<OrdenTaller> listarOrdenesTallerCriterio(string algo)
        {

            OrdenTaller ot = null;
            List<OrdenTaller> list = new List<OrdenTaller>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenTaller
                             where p.EstadoOT.Contains(algo)
                             select new
                             {
                                 IdOT = p.IdOT,
                                 ProductoOT = p.ProductoOT,
                                 FechaOT = p.FechaOT,
                                 ClienteOT = p.ClienteOT,
                                 DeclaracionCOT = p.DeclaracionCOT,
                                 EstadoOT = p.EstadoOT,
                                 PrecioOT = p.PrecioOT,
                                 ComentarioOT = p.ComentarioOT,
                                  TecnicoOT = p.TecnicoOT,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenTaller(r.IdOT, r.ProductoOT, r.FechaOT, r.ClienteOT, r.DeclaracionCOT, r.EstadoOT, r.PrecioOT, r.ComentarioOT, r.TecnicoOT);

                        list.Add(ot);
                    }
                }

            }

            return list;
            //}
        }
        public List<OrdenTaller> listarOrdenesTallerTecnico(int tecnico)
        {

            OrdenTaller ot = null;
            List<OrdenTaller> list = new List<OrdenTaller>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.OrdenTaller
                             where p.TecnicoOT.Equals(tecnico)
                             select new
                             {
                                 IdOT = p.IdOT,
                                 ProductoOT = p.ProductoOT,
                                 FechaOT = p.FechaOT,
                                 ClienteOT = p.ClienteOT,
                                 DeclaracionCOT = p.DeclaracionCOT,
                                 EstadoOT = p.EstadoOT,
                                 PrecioOT = p.PrecioOT,
                                 ComentarioOT = p.ComentarioOT,
                                 TecnicoOT = p.TecnicoOT,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {

                        ot = new OrdenTaller(r.IdOT, r.ProductoOT, r.FechaOT, r.ClienteOT, r.DeclaracionCOT, r.EstadoOT, r.PrecioOT, r.ComentarioOT, r.TecnicoOT);

                        list.Add(ot);
                    }
                }

            }

            return list;
        }
    }
}

