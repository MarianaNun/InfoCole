using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfoColeAplicacion.Models;
using InfoColeAplicacion.ViewModels;

namespace InfoColeAplicacion.Controllers
{
    public class NoticiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly int RegistrosPorPagina = 2;
        
        private Paginador<NoticiaViewModel> Paginador;

        // Listado Para Administradores
        [Authorize(Roles ="Admin")]
        public ActionResult Index(int pagina = 1)
        {
            int TotalNoticias = 0;
            TotalNoticias = db.Noticias.Count();
            List<NoticiaViewModel> Noticias = db.Noticias.OrderByDescending(n => n.FechaPublicacion)
                                           .Skip((pagina - 1) * RegistrosPorPagina)
                                           .Take(RegistrosPorPagina).Select(n => new NoticiaViewModel
                                           {
                                               NoticiaId = n.NoticiaId,
                                               Titulo = n.Titulo,
                                               FechaPublicacion = n.FechaPublicacion
                                           }).ToList();

            var totalDePaginas = (int)Math.Ceiling((double) TotalNoticias / RegistrosPorPagina);

            Paginador = new Paginador<NoticiaViewModel>()
            {
                RegistrosPorPagina = RegistrosPorPagina,
                TotalRegistros = TotalNoticias,
                TotalPaginas = totalDePaginas,
                PaginaActual = pagina,
                Resultado = Noticias
            };
            try
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = "";
                return View(Paginador);
            }
            
            return View(Paginador);
           
        }

        public ActionResult List()
        {

            //Este parte de codigo se puede usar para traer las noticias ordenadas por fecha, y a la hora de mostrar el dato Fecha De Publicacion,
            //Se muestra solo la fecha y no la hora


            return View();
        }

        // GET: Noticias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }



            return View(noticia);
        }

        // GET: Noticias/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            try
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "";
                return View();
            }
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Titulo,Descripcion,LinkNoticia,LinkImagen")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    noticia.FechaPublicacion = DateTime.Now;
                    db.Noticias.Add(noticia);
                    db.SaveChanges();
                    TempData["mensaje"] = "LA NOTICIA SE CREO CON EXITO";
                    ViewBag.Mensaje = TempData["mensaje"];
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    TempData["mensaje"] = "SE HA PRODUCIDO UN ERROR, INTENTE NUEVAMENTE";
                    ViewBag.Mensaje = TempData["mensaje"];
                    return View(noticia);
                }
            }



            return View(noticia);
        }

        // GET: Noticias/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            try
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "";
                return View(noticia);
            }
            return View(noticia);
        }

        
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "NoticiaId,Titulo,Descripcion,LinkNoticia,LinkImagen,FechaPublicacion")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(noticia).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["mensaje"] = "LA NOTICIA SE EDITO CON EXITO";
                    ViewBag.Mensaje = TempData["mensaje"];
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensaje"] = "SE HA PRODUCIDO UN ERROR, INTENTE NUEVAMENTE";
                    ViewBag.Mensaje = TempData["mensaje"];
                    return View(noticia);
                }
            }

            return View(noticia);
        }

        // GET: Noticias/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            try
            {               
                db.Noticias.Remove(noticia);
                db.SaveChanges();
                TempData["mensaje"] = "LA NOTICIA SE ELIMINO CON EXITO";
                ViewBag.Mensaje = TempData["mensaje"];
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["mensaje"] = "SE HA PRODUCIDO UN ERROR, INTENTE NUEVAMENTE";
                ViewBag.Mensaje = TempData["mensaje"];
                return View(noticia);
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
