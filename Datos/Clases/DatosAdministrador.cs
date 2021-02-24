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
    internal class DatosAdministrador : IDatosAdmin
    {



        private static DatosAdministrador _instancia = null;
        private DatosAdministrador() { }
        public static DatosAdministrador GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosAdministrador();
            return _instancia;
        }


        public Administrador Logueo(long cedula, string contraseña)
        {

            Administrador admin = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Administrador on us.CedulaUsu equals ad.cedulaAdministrador
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
                                 IdAdministrador = ad.IdAdministrador,

                             }).FirstOrDefault();

                if (query != null)
                {
                    admin = new Administrador(query.IdAdministrador, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }



            return admin;
        }
        public List<Administrador> listarAdmin()
        {

            Administrador admin = null;
            List<Administrador> list = new List<Administrador>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Administrador on us.CedulaUsu equals ad.cedulaAdministrador
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
                        admin = new Administrador(r.IdUsuario, r.CedulaUsu, r.NombreUsu, r.ClaveUsu, r.Sueldo, r.FechaIngreso, false);
                        list.Add(admin);
                    }
                }

            }



            return list;
        }
        public void agregarAdmin(Administrador addadmin)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                Usuario usu = obtenerUsuario(addadmin.CedulaUsu);
                if (usu != null)
                {
                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addadmin.CedulaUsu
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
                                CedulaUsu = addadmin.CedulaUsu,
                                NombreUsu = addadmin.NombreUsu,
                                ClaveUsu = addadmin.ClaveUsu,
                                Sueldo = addadmin.Sueldo,
                                FechaIngreso = DateTime.Now,
                            });
                            db.SaveChanges();
                            db.Administrador.Add(new Administrador()
                            {
                                cedulaAdministrador = addadmin.CedulaUsu,
                            });
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception exsql)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error al agregar al Stocker", exsql);
                        }


                    }
                }
            }
        }
        public void eliminarAdmin(Administrador addadmin)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryAdministrador =
                                     from Administrador in db.Administrador
                                       where Administrador.cedulaAdministrador == addadmin.CedulaUsu
                                     select Administrador;
                    foreach (var del in queryAdministrador)
                    {
                        db.Administrador.Remove(del);
                    }
                    db.SaveChanges();
                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addadmin.CedulaUsu
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
                        throw new Exception("Ocurrio un error al eliminar al Administrador", exsql);

                    }

                }

            }
        }
        public void modificarAdmin(long cedula,Administrador madmin)
        {

            try
            {
                using (ProyectoEntities db = new ProyectoEntities())
                {

                    var queryUsuario =
                     from Usuario in db.Usuario
                     where
                     Usuario.CedulaUsu == cedula
                     select Usuario;
                    foreach (var Usuario in queryUsuario)
                    {
                        Usuario.NombreUsu = madmin.NombreUsu;
                        Usuario.ClaveUsu = madmin.ClaveUsu;
                        Usuario.Sueldo = madmin.Sueldo;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception exsql)
            {

                throw new Exception("Ocurrio un error al modificar al Administrador",exsql);

            }

        }     
        public Administrador obtenerAdministrador(long cedula)
        {

            Administrador admin = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Administrador on us.CedulaUsu equals ad.cedulaAdministrador
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
                                 IdAdministrador = ad.IdAdministrador,

                             }).FirstOrDefault();

                if (query != null)
                {
                    admin = new Administrador(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }



            return admin;
        }
        public static Usuario obtenerUsuario(long cedula)
        {

            Usuario admin = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario   
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
                                BajaUsu=us.BajaUsu

                             }).FirstOrDefault();

                if (query != null)
                {
                    admin = new Usuario(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, query.BajaUsu);
                }
            }



            return admin;
        }
    }
}

