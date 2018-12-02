using InfoColeAplicacion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoColeAplicacion.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var noticia = from n in db.Noticias select n;
            noticia = noticia.OrderByDescending(n => n.FechaPublicacion);
            return View(noticia.Take(9).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var transito = from t in db.Transitos select t;
            transito = transito.OrderByDescending(t => t.Fecha);
            Transito primerAlerta = transito.FirstOrDefault();
            ViewBag.EstadoTransito = primerAlerta;

            var alerta = from a in db.Alertas select a;
            alerta = alerta.OrderByDescending(a => a.Fecha);
            List<Alerta> alertasTransito = alerta.Take(3).ToList();
            ViewBag.AlertaTransito = alertasTransito;

            var estadoLineas = from e in db.EstadoLineas 
                              join a in db.Lineas
                             on e.LineaID equals a.ID
                              select new TransitoViewModels
                              {
                                  contenido =e.Contenido,
                                  tipo = e.TipoID,
                                  linea = a.Nombre
                              };
            ViewBag.EstadoLineas = estadoLineas;

            return View();
        }

        
        public ActionResult Contact()
        {
            var noticia = from n in db.Noticias select n;
            noticia = noticia.OrderByDescending(n => n.FechaPublicacion);

            return View(noticia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}