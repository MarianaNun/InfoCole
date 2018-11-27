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
    public class TipoPuntoMapasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoPuntoMapas
        public ActionResult Index()
        {
            return View(db.TiposPuntoMapa.ToList());
        }

        // GET: TipoPuntoMapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPuntoMapa tipoPuntoMapa = db.TiposPuntoMapa.Find(id);
            if (tipoPuntoMapa == null)
            {
                return HttpNotFound();
            }
            return View(tipoPuntoMapa);
        }

        // GET: TipoPuntoMapas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPuntoMapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPuntoMapaId,Nombre")] TipoPuntoMapa tipoPuntoMapa)
        {
            if (ModelState.IsValid)
            {
                db.TiposPuntoMapa.Add(tipoPuntoMapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPuntoMapa);
        }

        // GET: TipoPuntoMapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPuntoMapa tipoPuntoMapa = db.TiposPuntoMapa.Find(id);
            if (tipoPuntoMapa == null)
            {
                return HttpNotFound();
            }
            return View(tipoPuntoMapa);
        }

        // POST: TipoPuntoMapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPuntoMapaId,Nombre")] TipoPuntoMapa tipoPuntoMapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPuntoMapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPuntoMapa);
        }

        // GET: TipoPuntoMapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPuntoMapa tipoPuntoMapa = db.TiposPuntoMapa.Find(id);
            if (tipoPuntoMapa == null)
            {
                return HttpNotFound();
            }
            return View(tipoPuntoMapa);
        }

        // POST: TipoPuntoMapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPuntoMapa tipoPuntoMapa = db.TiposPuntoMapa.Find(id);
            db.TiposPuntoMapa.Remove(tipoPuntoMapa);
            db.SaveChanges();
            return RedirectToAction("Index");
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
