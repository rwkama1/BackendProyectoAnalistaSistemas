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
    internal class DatosTarjeta:IDatosTarjeta
    {
        private static DatosTarjeta _instancia = null;
        private DatosTarjeta() { }
        public static DatosTarjeta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosTarjeta();
            return _instancia;
        }
        public void agregarTarjeta(PagoTarjeta addp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try

                    {
                        var fc = new PagoTarjeta()
                        {

                            NumeroT = addp.NumeroT,
                            ClienteT=addp.ClienteT,
                            CantidadCuT=addp.CantidadCuT,
                            TotalT=addp.TotalT,
                           
                        };
                        db.PagoTarjeta.Add(fc);
                        db.SaveChanges();
                        long numero = fc.NumeroT;
                        foreach (Cuota l in addp.Listacuotas)
                        {
                            db.Cuota.Add(new Cuota()
                            {
                                
                                NumeroTCU = numero,
                                ImporteCu = l.ImporteCu,


                            });
                            db.SaveChanges();


                        }

                        transaction.Commit();

                    }

                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al agregar la Tarjeta", exsql);
                    }
                }

            }
        }
        private List<Cuota> listarCuotas(long numero)
        {

            Cuota pr = null;
            List<Cuota> list = new List<Cuota>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Cuota
                             where p.NumeroTCU == numero
                             select new
                             {
                                 IDCu = p.IDCu,
                                 ImporteCu = p.ImporteCu,
                                 NumeroTCU = p.NumeroTCU,

            }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Cuota();
                        pr.IDCu = r.IDCu;
                        pr.ImporteCu = r.ImporteCu;
                        pr.NumeroTCU = r.NumeroTCU;

                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<PagoTarjeta> listarPagoTarjeta()
        {

            PagoTarjeta pr = null;
            List<PagoTarjeta> list = new List<PagoTarjeta>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.PagoTarjeta
                             select new
                             {
                          IDPT = p.IDPT,
                          NumeroT = p.NumeroT,
                          ClienteT = p.ClienteT,
                         CantidadCuT = p.CantidadCuT,
                          TotalT = p.TotalT,
               

            }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new PagoTarjeta(r.IDPT, r.NumeroT, r.ClienteT, r.CantidadCuT, r.TotalT, listarCuotas(r.NumeroT));
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public PagoTarjeta obtenerTarjeta(long numero)
        {

            PagoTarjeta pr = null;
           
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.PagoTarjeta
                             select new
                             {
                                 IDPT = p.IDPT,
                                 NumeroT = p.NumeroT,
                                 ClienteT = p.ClienteT,
                                 CantidadCuT = p.CantidadCuT,
                                 TotalT = p.TotalT,


                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new PagoTarjeta(r.IDPT, r.NumeroT, r.ClienteT, r.CantidadCuT, r.TotalT, listarCuotas(r.NumeroT));
                       
                    }
                }

            }



            return pr;
        }
    }

}
