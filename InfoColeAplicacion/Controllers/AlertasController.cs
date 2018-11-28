using InfoColeAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoColeAplicacion.Controllers
{
    public class AlertasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 

        // GET: Alertas
        public ActionResult Index()
        {
            CargarTiposDropDownList();
            return View();
        }

        
        public PartialViewResult CrearAlertaTrafico()
        {
            CargarTiposDropDownList();
            return PartialView("CrearAlertaTrafico");
        }

        [HttpPost]
        public ActionResult CrearAlertaTrafico([Bind(Include = "TipoID, Contenido")] Transito publicacion)
        {
                if (ModelState.IsValid)
                {
                publicacion.Fecha = DateTime.Now;
                db.Transitos.Add(publicacion);
                db.SaveChanges();
            }
            CargarTiposDropDownList();
            return PartialView(publicacion);

        }

        private void CargarTiposDropDownList(object tipoSelecionado = null)
        {
            var tiposQuery = from d in db.TipoAlertas
                                   select d;
            ViewBag.TipoID = new SelectList(tiposQuery, "TipoID", "Nombre", tipoSelecionado);
        }
    }
}