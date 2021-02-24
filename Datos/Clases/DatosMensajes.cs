using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    internal class DatosMensajes:IDatosMensajes
    {

        private static DatosMensajes _instancia = null;
        private DatosMensajes() { }
        public static DatosMensajes GetInstancia()
        {
            if (_instancia == null)
                _instancia = new DatosMensajes();
            return _instancia;
        }
        public Mensaje buscarMensaje(int id)
        {
            Mensaje mj = null;
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Mensaje
                             where
                               p.IdMensaje == id
                             select new
                             {
                                 IdMensaje = p.IdMensaje,
                                 Fechaenvio = p.Fechaenvio,
                                 ComentarioMens = p.ComentarioMens,
                                 Respuesta = p.RespuestaMens,
                                 Clicom = p.Clicom,
                                 Fecharespuesta = p.Fecharespuesta,
                                 ven = p.Vendresp,

                             }).FirstOrDefault();


                if (query != null)
                {
                   

                        mj = new Mensaje(query.IdMensaje, query.ComentarioMens, query.Clicom, query.ven, query.Respuesta, query.Fechaenvio, query.Fecharespuesta);

                       
                   
                }

            }

            return mj;
        }
    
        public void enviarMensaje(Mensaje addmsj)
        {
           
           
            using (ProyectoEntities db = new ProyectoEntities())
            {
           
                try
                {
                    db.Mensaje.Add(new Mensaje()
                    {

                        ComentarioMens = addmsj.ComentarioMens,
                        RespuestaMens = "Sin Respuesta",
                        Fechaenvio = DateTime.Now,
                        Fecharespuesta = null,
                        Clicom = addmsj.Clicom,
                        Vendresp=null
                     
                    });
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {
                    throw new Exception("Ocurrio un error al enviar el mensaje", exsql);
                }
            }
        }
        public void responderMensaje(Mensaje msj)
        {
            
            using (ProyectoEntities db = new ProyectoEntities())
            {
                try
                {
                    var queryProd =
                      from Mensaje in db.Mensaje
                      where
                      Mensaje.IdMensaje == msj.IdMensaje
                      select Mensaje;
                    foreach (var p in queryProd)
                    {
                        p.RespuestaMens = msj.RespuestaMens;
                        p.Vendresp = msj.Vendresp;
                        p.Fecharespuesta = DateTime.Now;
                        


                    }
                    db.SaveChanges();
                }
                catch (Exception exsql)
                {

                    throw new Exception("Ocurrio un error al responder el Mensaje" +
                        "", exsql);

                }

            }
        }
        public List<Mensaje> listarMensajesSinResponder()
        {

            Mensaje mj = null;
            List<Mensaje> list = new List<Mensaje>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Mensaje
                             select new
                             {
                                 IdMensaje = p.IdMensaje,
                                 Fechaenvio = p.Fechaenvio,
                                 ComentarioMens = p.ComentarioMens,
                                 Respuesta = p.RespuestaMens,
                                 Clicom = p.Clicom,
                                 Fecharespuesta = p.Fecharespuesta,
                                 ven = p.Vendresp,

                             }).ToList();

                
                if (query != null)
                {
                    foreach (var r in query)
                    {
                       
                        mj = new Mensaje(r.IdMensaje, r.ComentarioMens, r.Clicom, r.ven, r.Respuesta, r.Fechaenvio, r.Fecharespuesta);

                        list.Add(mj);
                    }
                }

            }

            return list;
        }
        public List<Mensaje> listarMensajesRespondidos(int cedula)
        {

            Mensaje mj = null;
            List<Mensaje> list = new List<Mensaje>();
            using (ProyectoEntities db = new ProyectoEntities())
            {

                var query = (from p in db.Mensaje
                             where
                               p.Clicom == cedula
                             select new
                             {
                                 IdMensaje = p.IdMensaje,
                                 Fechaenvio = p.Fechaenvio,
                                 ComentarioMens = p.ComentarioMens,
                                 Respuesta = p.RespuestaMens,
                                 Clicom = p.Clicom,
                                 Fecharespuesta = p.Fecharespuesta,
                                 ven = p.Vendresp,

                             }).ToList();


                if (query != null)
                {
                    foreach (var r in query)
                    {
                        
                        mj = new Mensaje(r.IdMensaje,r.ComentarioMens,r.Clicom,r.ven,r.Respuesta,r.Fechaenvio,r.Fecharespuesta);

                        list.Add(mj);
                    }
                }

            }

            return list;
        }


    }
}
