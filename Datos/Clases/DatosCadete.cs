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
    internal class DatosCadete : IDatosCadete
    {
        private static DatosCadete _instancia = null;
        private DatosCadete() { }
        public static DatosCadete GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosCadete();
            return _instancia;
        }

        public Cadete Logueo(long cedula, string contraseña)
        {
            Cadete cadete = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Cadete on us.CedulaUsu equals ad.cedulaCadete
                             where
                               us.CedulaUsu == cedula &&
                               us.ClaveUsu == contraseña &&
                               us.BajaUsu == false

                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 IdCadete = ad.IdCadete,

                             }).FirstOrDefault();

                if (query != null)
                {
                    cadete = new Cadete(query.IdCadete, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }
            return cadete;

        }
        public List<Cadete> listarCadete()
        {

            Cadete cadete = null;
            List<Cadete> list = new List<Cadete>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Cadete on us.CedulaUsu equals ad.cedulaCadete
                             where us.BajaUsu == false
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
                        cadete = new Cadete(r.IdUsuario, r.CedulaUsu, r.NombreUsu, r.ClaveUsu, r.Sueldo, r.FechaIngreso, false);
                        list.Add(cadete);
                    }
                }

            }



            return list;
        }
        public Cadete obtenerCadete(long cedula)
        {

            Cadete cadete = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Cadete on us.CedulaUsu equals ad.cedulaCadete
                             where
                               us.CedulaUsu == cedula
                              && us.BajaUsu == false


                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 IdCadete = ad.cedulaCadete,

                             }).FirstOrDefault();

                if (query != null)
                {
                    cadete = new Cadete(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }



            return cadete;
        }
         Cadete obtenerCadeteTodos(long cedula)
        {

            Cadete cadete = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Cadete on us.CedulaUsu equals ad.cedulaCadete
                             where
                               us.CedulaUsu == cedula
                                && ad.BajaCad == true

                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 IdCadete = ad.cedulaCadete,
                                 BajaCad=us.BajaUsu

                             }).FirstOrDefault();

                if (query != null)
                {
                    cadete = new Cadete(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, query.BajaCad);
                }
            }



            return cadete;
        }
        public void agregarCadete(Cadete addcadete)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {

                Usuario usu = DatosAdministrador.obtenerUsuario(addcadete.CedulaUsu);

                if (usu != null)
                {


                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addcadete.CedulaUsu
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
                                CedulaUsu = addcadete.CedulaUsu,
                                NombreUsu = addcadete.NombreUsu,
                                ClaveUsu = addcadete.ClaveUsu,
                                Sueldo = addcadete.Sueldo,
                                FechaIngreso = DateTime.Now,
                            });
                            db.SaveChanges();
                            db.Cadete.Add(new Cadete()
                            {
                                cedulaCadete = addcadete.CedulaUsu,
                                BajaCad = false
                            });
                            db.SaveChanges();
                            transaction.Commit();
                        }
                   
                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al agregar al Cadete", exsql);
                    }
                }
                }

            }
        }
        public void eliminarCadete(Cadete delcadete)
        {

            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                        //var queryUsuario =
                        // from Usuario in db.Cadete
                        // where
                        // Usuario.CedulaUsu == delcadete.CedulaUsu
                        // select Usuario;
                        //foreach (var del in queryUsuario)
                        //{

                        //    del.BajaCad = true;

                        //}
                        //db.SaveChanges();
                        var queryCadete =
                        from Cadete in db.Cadete
                        where Cadete.cedulaCadete == delcadete.CedulaUsu
                        select Cadete;
                        foreach (var delc in queryCadete)
                        {
                            delc.BajaCad = true;
                        }
                        db.SaveChanges();
                        var queryUsuario =
                                         from Usuario in db.Usuario
                                         where Usuario.CedulaUsu == delcadete.CedulaUsu
                                         select Usuario;
                        foreach (var delu in queryUsuario)
                        {
                            delu.BajaUsu = true;
                        }
                        db.SaveChanges();



                        transaction.Commit();
                    }
                    catch (Exception exsql)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error al eliminar al Cadete", exsql);

                    }
                }
               

            }
        }
        public void modificarCadete(Cadete mcadete)
        {

            try
            {
                using (ProyectoEntities db = new ProyectoEntities())
                {

                    var queryUsuario =
                     from Usuario in db.Usuario
                     where
                     Usuario.CedulaUsu == mcadete.CedulaUsu

                     select Usuario;
                    foreach (var Usuario in queryUsuario)
                    {

                        Usuario.NombreUsu = mcadete.NombreUsu;
                        Usuario.ClaveUsu = mcadete.ClaveUsu;
                        Usuario.Sueldo = mcadete.Sueldo;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception exsql)
            {

                throw new Exception("Ocurrio un error al modificar al Cadete", exsql);

            }

        }

    } 
}
