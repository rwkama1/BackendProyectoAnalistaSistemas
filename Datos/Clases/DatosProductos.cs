using Datos.Interfaces;
using Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    internal class DatosProductos: IDatosProductos
    {
        private static DatosProductos _instancia = null;
        private DatosProductos() { }
        public static DatosProductos GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosProductos();
            return _instancia;
        }
        public Producto obtenerProducto(long idprod)
        {
            Producto prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Producto
                             where us.IdProducto == idprod &&
                             us.BajaProd == false
                             select new
                             {
                                 IdProducto = us.IdProducto,
                                 NomProd = us.NomProd,
                                 DesProd = us.DescProd,
                                 StockProd = us.StockProd,
                                 UbicProd = us.UbicProd,
                                 PrecioProd = us.PrecioProd,
                                 CatProd = us.CatProd,

                             }).FirstOrDefault();

                if (query != null)
                {
                    prod = new Producto(query.IdProducto, query.NomProd, query.DesProd, query.StockProd, query.UbicProd, query.PrecioProd, query.CatProd,false);
                }
            }
            return prod;

        }
        public Producto obtenerProductoTodos(long idprod)
        {
            Producto prod = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from us in db.Producto
                             where us.IdProducto == idprod &&
                             us.BajaProd == true
                             select new
                             {
                                 IdProducto = us.IdProducto,
                                 NomProd = us.NomProd,
                                 DesProd = us.DescProd,
                                 StockProd = us.StockProd,
                                 UbicProd = us.UbicProd,
                                 PrecioProd = us.PrecioProd,
                                 CatProd = us.CatProd,

                             }).FirstOrDefault();

                if (query != null)
                {
                    prod = new Producto(query.IdProducto, query.NomProd, query.DesProd, query.StockProd, query.UbicProd, query.PrecioProd, query.CatProd, false);
                }
            }
            return prod;

        }
        public List<Producto> listarProductos()
        {

            Producto pr = null;
            List<Producto> list = new List<Producto>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Producto
                             where p.BajaProd == false
                             select new
                             {
                                 Idprod = p.IdProducto,
                                 NombProd = p.NomProd,
                                 DesProd = p.DescProd,
                                 StockProd = p.StockProd,
                                 UbicProd = p.UbicProd,
                                 PrecioProd = p.PrecioProd,
                                 CatProd = p.CatProd,
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Producto(r.Idprod, r.NombProd, r.DesProd, r.StockProd, r.UbicProd, r.PrecioProd
, r.CatProd,false);
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Producto> buscarlistarProductos(string criterio)
        {

            Producto pr = null;
            List<Producto> list = new List<Producto>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Producto
                             where (p.NomProd.Contains(criterio) || p.CatProd.Contains(criterio)|| p.UbicProd.Contains(criterio)|| p.PrecioProd.ToString().Contains(criterio))
                             && p.StockProd>0 &&
                             p.BajaProd == false
                             select new
                             {
                                 Idprod = p.IdProducto,
                                 NombProd = p.NomProd,
                                 DesProd = p.DescProd,
                                 StockProd = p.StockProd,
                                 UbicProd = p.UbicProd,
                                 PrecioProd = p.PrecioProd,
                                 CatProd = p.CatProd,
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Producto(r.Idprod, r.NombProd, r.DesProd, r.StockProd, r.UbicProd, r.PrecioProd
, r.CatProd,false);
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public List<Producto> listarProductosConStock()
        {

            Producto pr = null;
            List<Producto> list = new List<Producto>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Producto
                             where p.StockProd>0 &&
                             p.BajaProd == false
                             select new
                             {
                                 Idprod = p.IdProducto,
                                 NombProd = p.NomProd,
                                 DesProd = p.DescProd,
                                 StockProd = p.StockProd,
                                 UbicProd = p.UbicProd,
                                 PrecioProd = p.PrecioProd,
                                 CatProd = p.CatProd,
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        pr = new Producto(r.Idprod, r.NombProd, r.DesProd, r.StockProd, r.UbicProd, r.PrecioProd
, r.CatProd,false);
                        list.Add(pr);
                    }
                }

            }



            return list;
        }
        public void agregarProducto(Producto addp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                Producto prod = obtenerProductoTodos(addp.IdProducto);
                try
                {
                    if (prod != null)
                    {

                        var queryProd =
             from Producto in db.Producto
             where Producto.IdProducto == addp.IdProducto
             select Producto;
                        foreach (var delc in queryProd)
                        {
                           
                            delc.BajaProd = false;
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Producto.Add(new Producto()
                        {

                            NomProd = addp.NomProd,
                            PrecioProd = addp.PrecioProd,
                            StockProd = addp.StockProd,
                            UbicProd = addp.UbicProd,
                            DescProd = addp.DescProd,
                            CatProd = addp.CatProd
                        });
                        db.SaveChanges();
                    }
                    }
                catch (Exception exsql)
                {
                    throw new Exception("Ocurrio un error al agregar el Producto", exsql);
                }
            }
        }
        public void elmProd(Producto delp)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queProd =
                    from Producto in db.Producto
                    where Producto.IdProducto == delp.IdProducto
                    select Producto;

                    foreach (var delc in queProd)
                    {
                        delc.BajaProd = true;
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al eliminar el Producto", exsql);

                }

            }

        }
        public void modProd(int id,Producto mprod)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryProd =
                      from Producto in db.Producto
                      where
                      Producto.IdProducto == id
                      select Producto;

                    foreach (var p in queryProd)
                    {
                        p.NomProd = mprod.NomProd;
                        p.PrecioProd = mprod.PrecioProd;
                        p.CatProd = mprod.CatProd;
                        p.StockProd = mprod.StockProd;
                        p.UbicProd = mprod.UbicProd;
                        p.DescProd = mprod.DescProd;
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al Modifcar el Producto", exsql);

                }

            }

        }
       


    }
}
