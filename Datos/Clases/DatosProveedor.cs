using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    internal class DatosProveedor : IDatosProveedor
    {
        private static DatosProveedor _instancia = null;
        private DatosProveedor() { }
        public static DatosProveedor GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosProveedor();
            return _instancia;
        }
        public Proveedor obtProv(string rut)
        {
            Proveedor prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Proveedor
                             where us.RutProv == rut && us.BajaProv==false
                             select new
                             {
                                 IdProv = us.IdProveedor,
                                 NomProve = us.NomProve,
                                 DirProv = us.DirProve,
                                 RutProv = us.RutProv,
                                 TelProv = us.telProve,


                             }).FirstOrDefault();

                if (query != null)
                {
                    prod = new Proveedor(query.IdProv, query.RutProv, query.NomProve, query.DirProv, query.TelProv,false);
                }
            }
            return prod;

        }
         Proveedor obtProvTodos(string rut)
        {
            Proveedor prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Proveedor
                             where us.RutProv == rut && us.BajaProv == true
                             select new
                             {
                                 IdProv = us.IdProveedor,
                                 NomProve = us.NomProve,
                                 DirProv = us.DirProve,
                                 RutProv = us.RutProv,
                                 TelProv = us.telProve,


                             }).FirstOrDefault();

                if (query != null)
                {
                    prod = new Proveedor(query.IdProv, query.RutProv, query.NomProve, query.DirProv, query.TelProv, false);
                }
            }
            return prod;

        }
        public List<Proveedor> listarProveedor()
        {

            Proveedor pr = null;
            List<Proveedor> list = new List<Proveedor>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Proveedor
                             where p.BajaProv == false
                             select new
                             {
                                 IdProv = p.IdProveedor,
                                 NomProve = p.NomProve,
                                 DirProv = p.DirProve,
                                 RutProv = p.RutProv,
                                 TelProv = p.telProve,
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Proveedor(r.IdProv, r.RutProv, r.NomProve, r.DirProv, r.TelProv,false);
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public void agregarProveedor(Proveedor adprov)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                Proveedor prov = obtProvTodos(adprov.RutProv);
                try
                {
                    if (prov != null)
                    {
                        var queryProd =
                         from Proveedor in db.Proveedor
                         where
                         Proveedor.RutProv == adprov.RutProv
                         select Proveedor;
                        foreach (var p in queryProd)
                        {
                            p.BajaProv = false;
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Proveedor.Add(new Proveedor()
                        {


                            NomProve = adprov.NomProve,
                            RutProv = adprov.RutProv,
                            DirProve = adprov.DirProve,
                            telProve = adprov.telProve,
                        });
                        db.SaveChanges();
                    }
                }
                catch (Exception exsql)
                {
                    throw new Exception("Ocurrio un error al agregar el Proveedor", exsql);
                }
            }
        }
        public void eliminarProv(Proveedor delp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queProd =
                    from Proveedor in db.Proveedor
                    where Proveedor.RutProv == delp.RutProv
                    select Proveedor;

                    foreach (var delc in queProd)
                    {
                        delc.BajaProv = true;
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al eliminar el Proveedor", exsql);

                }

            }

        }
        public void modificarProveedor(string rut,Proveedor mprod)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryProd =
                      from Proveedor in db.Proveedor
                      where
                      Proveedor.RutProv == rut
                      select Proveedor;
                    foreach (var p in queryProd)
                    {
                        p.NomProve = mprod.NomProve;
                        p.DirProve = mprod.DirProve;
                        p.RutProv = mprod.RutProv;
                        p.telProve = mprod.telProve;
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al Modifcar el Proveedor", exsql);

                }

            }

        }
    }
}
