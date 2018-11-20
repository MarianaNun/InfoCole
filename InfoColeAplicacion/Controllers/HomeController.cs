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

            return View();
        }

        
        public ActionResult Contact()
        {
            var noticia = from n in db.Noticias select n;
            noticia = noticia.OrderByDescending(n => n.FechaPublicacion);

            return View(noticia);
        }
    }
}