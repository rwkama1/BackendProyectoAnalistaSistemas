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
    internal class DatosTecnicos:IDatosTecnicos
    {
        private static DatosTecnicos _instancia = null;
        private DatosTecnicos() { }
        public static DatosTecnicos GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosTecnicos();
            return _instancia;
        }
       
        public Tecnico Logueo(long cedula, string contraseña)
        {
            Tecnico tecnico = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Tecnico on us.CedulaUsu equals ad.cedulaTecnico
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
                                 IdTecnico = ad.IdTecnico,

                             }).FirstOrDefault();

                if (query != null)
                {
                    tecnico = new Tecnico(query.IdTecnico, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }
            return tecnico;
        }
        public List<Tecnico> listarTecnico()
        {

            Tecnico tecnico = null;
            List<Tecnico> list = new List<Tecnico>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                             join ad in db.Tecnico on us.CedulaUsu equals ad.cedulaTecnico
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
                        tecnico = new Tecnico(r.IdUsuario, r.CedulaUsu, r.NombreUsu, r.ClaveUsu, r.Sueldo, r.FechaIngreso,false);
                        list.Add(tecnico);
                    }
                }

            }



            return list;
        }
        public Tecnico obtenerTecnico(long cedula)
        {
            Tecnico tecnico = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Tecnico on us.CedulaUsu equals ad.cedulaTecnico
                             where
                               us.CedulaUsu == cedula &&
                              us.BajaUsu == false
                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 IdTecnico = ad.IdTecnico,

                             }).FirstOrDefault();

                if (query != null)
                {
                    tecnico = new Tecnico(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }
            return tecnico;
        }
        public Tecnico obtenerTecnicoTodos(long cedula)
        {
            Tecnico tecnico = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Tecnico on us.CedulaUsu equals ad.cedulaTecnico
                             where
                               us.CedulaUsu == cedula &&
                              ad.BajaTec == true
                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 IdTecnico = ad.IdTecnico,

                             }).FirstOrDefault();

                if (query != null)
                {
                    tecnico = new Tecnico(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }
            return tecnico;
        }
        public void agregarTecnico(Tecnico addtecn)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                Usuario usu = DatosAdministrador.obtenerUsuario(addtecn.CedulaUsu);

                if (usu != null)
                {


                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addtecn.CedulaUsu
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
                                CedulaUsu = addtecn.CedulaUsu,
                                NombreUsu = addtecn.NombreUsu,
                                ClaveUsu = addtecn.ClaveUsu,
                                Sueldo = addtecn.Sueldo,
                                FechaIngreso = DateTime.Now,
                            });
                            db.SaveChanges();
                            db.Tecnico.Add(new Tecnico()
                            {
                                cedulaTecnico = addtecn.CedulaUsu,
                            });
                            db.SaveChanges();
                            transaction.Commit();

                        }
                        catch (Exception exsql)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error al agregar al Tecnico", exsql);

                        }

                    }


                }
            }
        }
        public void eliminarTecnico(Tecnico deltecn)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryTecnico =
                                     from Tecnico in db.Tecnico
                                     where Tecnico.cedulaTecnico == deltecn.CedulaUsu
                                     select Tecnico;
                        foreach (var delc in queryTecnico)
                        {
                            delc.BajaTec = true;
                        }
                        db.SaveChanges();
                        var queryUsuario =
                                         from Usuario in db.Usuario
                                         where Usuario.CedulaUsu == deltecn.CedulaUsu
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
                        throw new Exception("Ocurrio un error al eliminar al Tecnico",exsql);

                    }

                }

            }

        }
        public void modificarTecnico(Tecnico mtec)
        {

            try
            {
                using (ProyectoEntities db = new ProyectoEntities())
                {

                    var queryUsuario =
                     from Usuario in db.Usuario
                     where
                     Usuario.CedulaUsu == mtec.CedulaUsu
                     select Usuario;
                    foreach (var Usuario in queryUsuario)
                    {
                        Usuario.NombreUsu = mtec.NombreUsu;
                        Usuario.ClaveUsu = mtec.ClaveUsu;
                        Usuario.Sueldo = mtec.Sueldo;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception exsql)
            {

                throw new Exception("Ocurrio un error al modificar al Tecnico", exsql);

            }

        }

    }
}
