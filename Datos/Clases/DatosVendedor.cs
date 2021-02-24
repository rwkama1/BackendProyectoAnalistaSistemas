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
    internal class DatosVendedor:IDatosVendedor
    {
        private static DatosVendedor _instancia = null;
        private DatosVendedor() { }
        public static DatosVendedor GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosVendedor();
            return _instancia;
        }
     
        public Vendedor Logueo(long cedula, string contraseña)
        {

            Vendedor vendedor = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Vendedor on us.CedulaUsu equals ad.cedulaVendedor

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
                                 IdVendedor = ad.IdVendedor,

                             }).FirstOrDefault();

                if (query != null)
                {
                    vendedor = new Vendedor(query.IdVendedor, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }

            return vendedor;
        }
        public List<Vendedor> listarVendedor()
        {

            Vendedor vendedor = null;
            List<Vendedor> list = new List<Vendedor>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Usuario
                            
                             join ad in db.Vendedor on us.CedulaUsu equals ad.cedulaVendedor
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
                        vendedor = new Vendedor(r.IdUsuario, r.CedulaUsu, r.NombreUsu, r.ClaveUsu, r.Sueldo, r.FechaIngreso,false);
                        list.Add(vendedor);
                    }
                }

            }



            return list;
        }
        public Vendedor obtenerVendedor(long cedula)
        {

            Vendedor vendedor = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Vendedor on us.CedulaUsu equals ad.cedulaVendedor
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
                                 IdVendedor = ad.IdVendedor,

                             }).FirstOrDefault();

                if (query != null)
                {
                    vendedor = new Vendedor(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }

            return vendedor;
        }
        Vendedor obtenerVendedorTodos(long cedula)
        {

            Vendedor vendedor = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {
                var query = (from us in db.Usuario
                             join ad in db.Vendedor on us.CedulaUsu equals ad.cedulaVendedor
                             where
                               us.CedulaUsu == cedula &&
                               ad.BajaV == true

                             select new
                             {
                                 IdUsuario = us.Idusu,
                                 CedulaUsu = us.CedulaUsu,
                                 NombreUsu = us.NombreUsu,
                                 ClaveUsu = us.ClaveUsu,
                                 Sueldo = us.Sueldo,
                                 FechaIngreso = us.FechaIngreso,
                                 IdVendedor = ad.IdVendedor,

                             }).FirstOrDefault();

                if (query != null)
                {
                    vendedor = new Vendedor(query.IdUsuario, query.CedulaUsu, query.NombreUsu, query.ClaveUsu, query.Sueldo, query.FechaIngreso, false);
                }
            }

            return vendedor;
        }
        public void agregarVenedor(Vendedor addvendedor)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                Usuario usu = DatosAdministrador.obtenerUsuario(addvendedor.CedulaUsu);

                if (usu != null)
                {
                    var queryUsuario =
                                     from Usuario in db.Usuario
                                     where Usuario.CedulaUsu == addvendedor.CedulaUsu
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
                                CedulaUsu = addvendedor.CedulaUsu,
                                NombreUsu = addvendedor.NombreUsu,
                                ClaveUsu = addvendedor.ClaveUsu,
                                Sueldo = addvendedor.Sueldo,
                                FechaIngreso = DateTime.Now,
                            });
                            db.SaveChanges();
                            db.Vendedor.Add(new Vendedor()
                            {
                                cedulaVendedor = addvendedor.CedulaUsu,
                            });
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception exsql)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error al agregar al Vendedor", exsql);
                        }
                    }

                }
            }
        }
        public void eliminarVendedor(Vendedor delven)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryVendedor =
                                     from Vendedor in db.Vendedor
                                     where Vendedor.cedulaVendedor == delven.CedulaUsu
                                     select Vendedor;
                        foreach (var delc in queryVendedor)
                        {
                            delc.BajaV = true;
                        }
                        db.SaveChanges();
                        var queryUsuario =
                                         from Usuario in db.Usuario
                                         where Usuario.CedulaUsu == delven.CedulaUsu
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
                        throw new Exception("Ocurrio un error al eliminar al Vendedor", exsql);

                    }

                }

            }

        }
        public void modificarVendedor(Vendedor mvend)
        {

            try
            {
                using (ProyectoEntities db = new ProyectoEntities())
                {

                    var queryUsuario =
                     from Usuario in db.Usuario
                     where
                     Usuario.CedulaUsu ==mvend.CedulaUsu
                     select Usuario;
                    foreach (var Usuario in queryUsuario)
                    {
                        Usuario.NombreUsu = mvend.NombreUsu;
                        Usuario.ClaveUsu = mvend.ClaveUsu;
                        Usuario.Sueldo = mvend.Sueldo;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception exsql)
            {

                throw new Exception("Ocurrio un error al modificar al Vendedor", exsql);

            }

        }
    }

    }

