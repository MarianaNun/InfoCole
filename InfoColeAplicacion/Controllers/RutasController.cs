using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfoColeAplicacion.Models;

namespace InfoColeAplicacion.Controllers
{
    public class RutasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rutas
        public ActionResult Index()
        {
            
            ViewBag.ID = new SelectList(db.Lineas, "ID", "Nombre");
            return View();
        }

        public ActionResult IndexUser()
        {
            ViewBag.ID = new SelectList(db.Lineas, "ID", "Nombre");
            return View();
        }


        [HttpGet]
        public JsonResult GetRutas()
        {
            try
            {
                var rutas = db.Rutas.Include(r => r.Puntos).Include(r => r.Linea).ToList();
                var data = rutas.Select(r => new {
                    RutaId = r.RutaId,
                    Puntos = r.Puntos,
                    Linea = r.Linea
                });
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult GetRutasByLinea(int lineaId)
        {
            try
            {
                var rutas = db.Rutas.Where( r => r.ID == lineaId).Include(r => r.Puntos).Include(r => r.Linea).ToList();
                var data = rutas.Select(r => new {
                    RutaId = r.RutaId,
                    Puntos = r.Puntos,
                    Linea = r.Linea
                });
                
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Rutas.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Lineas, "ID", "Nombre");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Ruta ruta)
        {
            if (ModelState.IsValid && ruta.Puntos.Count > 0)
            {
                var verificar = db.Rutas.Where(r => r.ID == ruta.ID).FirstOrDefault();
                if(verificar == null)
                {
                    db.Rutas.Add(ruta);
                    db.SaveChanges();
                    return Json("Ruta guardada correctamente", JsonRequestBehavior.AllowGet);
                }
                return Json("Ya se ha registrado una ruta para esta linea", JsonRequestBehavior.AllowGet);

            }

            return Json("Complete correctamente los campos");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Rutas.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Lineas, "ID", "Nombre", ruta.ID);
            return Json(ruta,JsonRequestBehavior.AllowGet);
        }

        // POST: Rutas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public ActionResult Edit(Ruta ruta)
        //{
        //    foreach(PuntoRuta punto in ruta.Puntos)
        //    {
        //        //if(punto.Lat == "0")
        //        //{
        //        //    db.Entry(punto).State = EntityState.Deleted;
        //        //    //db.SaveChanges();
        //        //}
        //        if(punto.PuntoMapaId == 0)
        //        {
        //            db.Entry(punto).State = EntityState.Added;
        //            //db.SaveChanges();
        //        }
        //    }


        //    if (ModelState.IsValid)
        //    { 
        //        db.Entry(ruta).State = EntityState.Modified;
               
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ID = new SelectList(db.Lineas, "ID", "Nombre", ruta.ID);
        //    return View(ruta);
        //}

        // GET: Rutas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Ruta ruta = db.Rutas.Find(id);

                if (ruta == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Rutas.Remove(ruta);
                    db.SaveChanges();
                    return Json("LA RUTA SE ELIMINO CON EXITO");
                }
            }
            catch (Exception ex)
            {
                return Json("SE PRODUJO UN ERROR, INTENTE NUEVAMENTE");
            }
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
