using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Interfaces;
using Entidades;
namespace Datos.Clases

{
    internal class DatosStocker:IDatosStocker
    {
        private static DatosStocker _instancia = null;
        private DatosStocker() { }
        public static DatosStocker GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosStocker();
            return _instancia;
        }
      
        public Stocker Logueo(long cedula, string contraseña)
        {

            Stocker stocker = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Stocker on us.CedulaUsu equals ad.cedulaStocker
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
                                 Idstocker = ad.IdStocker,

                             }).FirstOrDefault();

                if (query != null)
                {
                    stocker = new Stocker(query.Idstocker, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }

            }


            return stocker;


        }
        public List<Stocker> listarStocker()
        {

            Stocker stocker = null;
            List<Stocker> list = new List<Stocker>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Stocker on us.CedulaUsu equals ad.cedulaStocker
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
                        stocker = new Stocker(r.IdUsuario, r.CedulaUsu, r.NombreUsu, r.ClaveUsu, r.Sueldo, r.FechaIngreso, false);
                        list.Add(stocker);
                    }
                }

            }



            return list;
        }
        public Stocker obtenerStocker(long cedula)
        {

            Stocker stocker = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Stocker on us.CedulaUsu equals ad.cedulaStocker
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
                                 Idstocker = ad.IdStocker,

                             }).FirstOrDefault();

                if (query != null)
                {
                    stocker = new Stocker(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }

            }


            return stocker;


        }
        public void agregarStocker(Stocker addstocker)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {

                Usuario usu = DatosAdministrador.obtenerUsuario(addstocker.CedulaUsu);

                if (usu != null)
                {


                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addstocker.CedulaUsu
                                     select Usuario;
                    foreach (var delu in queryUsuario)
                    {

                        delu.BajaUsu = false;
                    }
                    db.SaveChanges();
                }
                else
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Usuario.Add(new Usuario()
                            {
                                CedulaUsu = addstocker.CedulaUsu,
                                NombreUsu = addstocker.NombreUsu,
                                ClaveUsu = addstocker.ClaveUsu,
                                Sueldo = addstocker.Sueldo,
                                FechaIngreso = DateTime.Now,
                            });
                            db.SaveChanges();
                            db.Stocker.Add(new Stocker()
                            {
                                cedulaStocker = addstocker.CedulaUsu,
                            });
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception exsql)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error al agregar al Stocker",exsql);
                        }
                    }

                
                }

            }
        }
        public void eliminarStocker(Stocker delstocker)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryStocker =
                                     from Stocker in db.Stocker
                                     where Stocker.cedulaStocker == delstocker.CedulaUsu
                                     select Stocker;
                        foreach (var delc in queryStocker)
                        {
                            db.Stocker.Remove(delc);
                        }
                        db.SaveChanges();
                        var queryUsuario =
                                         from Usuario in db.Usuario
                                         where Usuario.CedulaUsu == delstocker.CedulaUsu
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
                        throw new Exception("Ocurrio un error al eliminar al Stocker", exsql);

                    }

                }

            }

        }
        public void modificarStocker(Stocker mstocker)
        {

            try
            {
                using (ProyectoEntities db = new ProyectoEntities())
                {

                    var queryUsuario =
                     from Usuario in db.Usuario
                     where
                     Usuario.CedulaUsu == mstocker.CedulaUsu
                     select Usuario;
                    foreach (var Usuario in queryUsuario)
                    {
                        Usuario.NombreUsu = mstocker.NombreUsu;
                        Usuario.ClaveUsu = mstocker.ClaveUsu;
                        Usuario.Sueldo = mstocker.Sueldo;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception exsql)
            {

                throw new Exception("Ocurrio un error al modificar al Stocker", exsql);

            }

        }
    }
}
