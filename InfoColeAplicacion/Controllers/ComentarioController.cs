using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfoColeAplicacion.Models;
using Microsoft.AspNet.Identity;

namespace InfoColeAplicacion.Controllers
{
    public class ComentarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentario
        public ActionResult Index()
        {
            
            var autenticado = User.Identity.IsAuthenticated;
            if (autenticado)
            {
                var ID = User.Identity.GetUserId();
                ViewBag.ID = ID;
            }
            var comentario = from c in db.Comentarios select c;

            comentario = comentario.OrderByDescending(c => c.Fecha);

            return View(comentario.ToList());
        }

        // GET: Comentario/Details/5
        [Authorize]
        public ActionResult Details()
        {
            var autenticado = User.Identity.IsAuthenticated;
            if (autenticado)
            {
                var ID = User.Identity.GetUserId();
                ViewBag.ID = ID;
            }
            var comentario = from c in db.Comentarios
                             //where (c.User.Habilitado)
                             select c;

            comentario = comentario.OrderByDescending(c => c.Fecha);

            return View(comentario.ToList());
        }

        // GET: Comentario/Create
        [Authorize]
        public ActionResult Create()
        {
            var autenticado = User.Identity.IsAuthenticated;
            if (autenticado)
            {
                var ID = User.Identity.GetUserId();
                var NombreUsuario = User.Identity.GetUserName();
                ViewBag.Nombre = NombreUsuario;
                ViewBag.ID = ID;

                Comentario model = new Comentario();
                model.ApplicationUserId = ID;
                
                List<SelectListItem> li = new List<SelectListItem>();
                foreach (var linea in db.Lineas)
                {
                    li.Add(new SelectListItem { Text = linea.Nombre, Value = linea.ID.ToString() });
                }
                ViewData["linea"] = li;

                var selectList = new SelectList(db.Lineas.ToList(), "Id", "Name");
                ViewData["Lineas"] = selectList;


                return PartialView(model);

               // return View();
            }
            else
            {
                return RedirectToAction("Login", "AccountController");
            }

        }

        // POST: Comentario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comentario comentario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    comentario.Fecha = DateTime.Now;
                    db.Comentarios.Add(comentario);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully." });
                }
                return View("Index", "Comentario");
            }
            catch (Exception ex){
                return new JsonResult
                {
                    Data = new { ErrorMessage = ex.Message, Success = false },
                    ContentEncoding = System.Text.Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return PartialView(comentario);
        }

        // POST: Comentario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()] Comentario comentario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(comentario).State = EntityState.Modified;
                    db.SaveChanges();
                    //return Json(new { success = true });

                    return Json(new { success = true, message = "Updated Successfully." });
                }

                return View("Index", "Comentario");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
   

        // GET: Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            else {
                if (comentario.Tipo)
                {
                    ViewBag.Tipo = "Información";
                }
                else {
                    ViewBag.Tipo = "Queja";
                }
            }
            return PartialView(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
                Comentario comentario = db.Comentarios.Find(id);
                db.Comentarios.Remove(comentario);
                db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully." });
            //return RedirectToAction("Index", "Comentario");
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
