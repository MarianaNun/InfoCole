using InfoColeAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InfoColeAplicacion.Controllers
{
    public class PuntoMapaController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Tipos = this.ObtenerTipos();
            return View();
        }

        public List<SelectListItem> ObtenerTipos()
        {
            List<SelectListItem> listado =  new List<SelectListItem>();
            var tipos = db.TiposPuntoMapa.ToList();
            foreach(TipoPuntoMapa tipo in tipos)
            {
                listado.Add(new SelectListItem {Text = tipo.Nombre, Value = tipo.TipoPuntoMapaId.ToString() });
            }
            return listado;
        }

        [HttpGet]
        public JsonResult GetLocations()
        {

            return Json(db.Puntos.Include(p => p.Tipo).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLocationsByType(int tipo)
        {
            return Json(db.Puntos.Include(p => p.Tipo).Where(p => p.TipoPuntoMapaId == tipo).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditarPunto(PuntoMapa punto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(punto).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("EL PUNTO SE EDITO CON EXITO");
                }
                catch(Exception ex)
                {
                    return Json("Se ha producido un error");
                }
            }

            return Json("LA OPERACIÓN FALLO, VUELVa A INTENTARLO");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PuntoMapa puntoMapa = db.Puntos.Find(id);

                if (puntoMapa == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Puntos.Remove(puntoMapa);
                    db.SaveChanges();
                    return Json("EL PUNTO SE ELIMINO CON EXITO");
                }
            }
            catch (Exception ex)
            {
                return Json("SE PRODUJO UN ERROR, INTENTE NUEVAMENTE");
            }
        }

        public ActionResult Create()
        {
            ViewBag.Tipos = this.ObtenerTipos();
            return View();
        }


        [HttpPost]
        public ActionResult Create(PuntoMapa puntoMapa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Puntos.Add(puntoMapa);
                    db.SaveChanges();
                    return Json("El punto se ha guardado correctamente");
                }
                catch(Exception ex)
                {
                    return Json("Se ha producido un error");
                }
            }

            return Json("Ingrese correctamente los datos");
        }
    }
}