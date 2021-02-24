using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Interfaces;
using Entidades;
namespace Datos.Clases
{
    internal class DatosCajero:IDatosCajero
    {
        private static DatosCajero _instancia = null;
        private DatosCajero() { }
        public static DatosCajero GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosCajero();
            return _instancia;
        }
       
        public Cajero Logueo(long cedula, string contraseña)
        {
            Cajero cajero = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
               
                var query = (from us in db.Usuario
                             join ad in db.Cajero on us.CedulaUsu equals ad.cedulaCajero
                             where
                               us.CedulaUsu == cedula &&
                               us.ClaveUsu == contraseña
                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 Idcajero = ad.IdCajero,

                             }).FirstOrDefault();

                if (query != null)
                {
                    cajero = new Cajero(query.Idcajero, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso,false);
                }
            }
                return cajero;
            
        }
        public List<Cajero> listarCajero()
        {

            Cajero cajero = null;
            List<Cajero> list = new List<Cajero>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Cajero on us.CedulaUsu equals ad.cedulaCajero
                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,


                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        cajero = new Cajero(r.IdUsuario, r.CedulaUsu, r.NombreUsu, r.ClaveUsu, r.Sueldo, r.FechaIngreso, false);
                        list.Add(cajero);
                    }
                }

            }



            return list;
        }
        public Cajero obtenerCajero(long cedula)
        {
            Cajero cajero = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Cajero on us.CedulaUsu equals ad.cedulaCajero
                             where
                               us.CedulaUsu == cedula
                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 Idcajero = ad.IdCajero,

                             }).FirstOrDefault();

                if (query != null)
                {
                    cajero = new Cajero(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }
            return cajero;

        }
        public void agregarCajero(Cajero addcajero)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                Usuario usu = DatosAdministrador.obtenerUsuario(addcajero.CedulaUsu);

                if (usu != null)
                {


                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addcajero.CedulaUsu
                                     select Usuario;
                    foreach (var delu in queryUsuario)
                    {

                        delu.BajaUsu = false;
                    }
                    db.SaveChanges();
                }
                else {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Usuario.Add(new Usuario()
                            {
                                CedulaUsu = addcajero.CedulaUsu,
                                NombreUsu = addcajero.NombreUsu,
                                ClaveUsu = addcajero.ClaveUsu,
                                Sueldo = addcajero.Sueldo,
                                FechaIngreso = DateTime.Now,
                            });
                            db.SaveChanges();
                            db.Cajero.Add(new Cajero()
                            {
                                cedulaCajero = addcajero.CedulaUsu,
                            });
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception exsql)
                        {


                            transaction.Rollback();
                            throw new Exception("Ocurrio un error al agregar al Cajero",exsql);

                        }
                    }
                }

            }
        }
        public void eliminarCajero(Cajero delcajero)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryCajero =
                                     from Cajero in db.Cajero
                                     where Cajero.cedulaCajero == delcajero.CedulaUsu
                                     select Cajero;
                        foreach (var delc in queryCajero)
                        {
                            db.Cajero.Remove(delc);
                        }
                        db.SaveChanges();
                        var queryUsuario =
                                         from Usuario in db.Usuario
                                         where Usuario.CedulaUsu == delcajero.CedulaUsu
                                         select Usuario;
                        foreach (var delu in queryUsuario)
                        {
                            db.Usuario.Remove(delu);
                        }
                        db.SaveChanges();



                        transaction.Commit();
                    }
                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al eliminar al Cajero", exsql);

                    }

                }

            }

        }
        public void modificarCajero(Cajero mcajero)
        {

            try
            {
                using (ProyectoEntities db = new ProyectoEntities())
                {

                    var queryUsuario =
                     from Usuario in db.Usuario
                     where
                     Usuario.CedulaUsu == mcajero.CedulaUsu
                     select Usuario;
                    foreach (var Usuario in queryUsuario)
                    {
                        Usuario.NombreUsu = mcajero.NombreUsu;
                        Usuario.ClaveUsu = mcajero.ClaveUsu;
                        Usuario.Sueldo = mcajero.Sueldo;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception exsql)
            {

                throw new Exception("Ocurrio un error al modificar al Cajero", exsql);

            }

        }

    }
}
