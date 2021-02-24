using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    internal class DatosCliente : IDatosCliente

    {

        private static DatosCliente _instancia = null;
        private DatosCliente() { }
        public static DatosCliente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosCliente();
            return _instancia;
        }
        public void agregarCliente(Cliente cli)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {

                try
                {
                    db.Cliente.Add(new Cliente()
                    {


                        NomCli = cli.NomCli,
                        DirCli= cli.DirCli,
                        CedulaCli = cli.CedulaCli,
                        telCli = cli.telCli,
                        PassCli = cli.PassCli,
                    });
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {
                    throw new Exception("Ocurrio un error al agregar el Cliente", exsql);
                }
            }
        }
        public void modificarCliente(Cliente clim)
        {
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryProd =
                      from Cliente in db.Cliente
                      where
                      Cliente.CedulaCli == clim.CedulaCli
                      select Cliente;
                    foreach (var p in queryProd)
                    {
                        p.NomCli = clim.NomCli;
                        p.DirCli= clim.DirCli;
                        p.CedulaCli = clim.CedulaCli;
                        p.telCli = clim.telCli;
                        p.PassCli = clim.PassCli;
                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al Modifcar el Cliente" +
                        "", exsql);

                }

            }
        }
        public List<Cliente> listarCliente()
        {

            Cliente cl = null;
            List<Cliente> list = new List<Cliente>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Cliente
                             select new
                             {
                                 IdCliente = p.IdCliente,
                                 CedulaCliente = p.CedulaCli,
                                 NomCliente = p.NomCli,
                                 DirCliente = p.DirCli,
                                 TelCliente = p.telCli,
                                 PassCliente = p.PassCli,
                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        cl = new Cliente(r.IdCliente, r.CedulaCliente, r.NomCliente, r.DirCliente, r.TelCliente, r.PassCliente);
                        list.Add(cl);
                    }
                }

            }



            return list;
        }
        public Cliente Logueo(int cedula, string contraseña)
        {

            Cliente cli = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from c in db.Cliente
                             where
                               c.CedulaCli == cedula &&
                               c.PassCli == contraseña
                             select new
                             {
                                 IdCliente = c.IdCliente,
                                 CedulaCliente = c.CedulaCli,
                                 NomCliente = c.NomCli,
                                 DirCliente = c.DirCli,
                                 TelCliente = c.telCli,
                                 PassCliente = c.PassCli,

                             }).FirstOrDefault();

                if (query != null)
                {
                    cli = new Cliente(query.IdCliente, query.CedulaCliente, query.NomCliente, query.DirCliente, query.TelCliente, query.PassCliente);
                }
            }



            return cli;
        }
        public Cliente buscarcli(int cedula)
        {
            Cliente cli = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from c in db.Cliente
                             where
                               c.CedulaCli == cedula
                             select new
                             {
                                 IdCliente = c.IdCliente,
                                 CedulaCliente = c.CedulaCli,
                                 NomCliente = c.NomCli,
                                 DirCliente = c.DirCli,
                                 TelCliente = c.telCli,
                                 PassCliente = c.PassCli,

                             }).FirstOrDefault();

                if (query != null)
                {
                    cli = new Cliente(query.IdCliente, query.CedulaCliente, query.NomCliente, query.DirCliente, query.TelCliente, query.PassCliente);
                }
            }
            return cli;

        }
    }
}
