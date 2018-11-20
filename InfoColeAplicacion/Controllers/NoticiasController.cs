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
    public class NoticiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly int RegistrosPorPagina = 2;
        
        private Paginador<Noticia> Paginador;

        // Listado Para Administradores
        [Authorize(Roles ="Admin")]
        public ActionResult Index(int pagina = 1)
        {

            

            int TotalNoticias = 0;
            TotalNoticias = db.Noticias.Count();
            List<Noticia> Noticias = db.Noticias.OrderByDescending(n => n.FechaPublicacion)
                                           .Skip((pagina - 1) * RegistrosPorPagina)
                                           .Take(RegistrosPorPagina)
                                           .ToList();

            var totalDePaginas = (int)Math.Ceiling((double) TotalNoticias / RegistrosPorPagina);

            Paginador = new Paginador<Noticia>()
            {
                RegistrosPorPagina = RegistrosPorPagina,
                TotalRegistros = TotalNoticias,
                TotalPaginas = totalDePaginas,
                PaginaActual = pagina,
                Resultado = Noticias
            };
                    
            return View(Paginador);
           
        }

        //Vista para la seccion de noticias que ve el usuario
        //Creo conveniente que se use una vista con listado distinto para el usuario, ya que el usuario tendra mejores estilos
        //Y en la parte administrador alcanza con usar una tabla
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
                noticia.FechaPublicacion = DateTime.Now;
                db.Noticias.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "NoticiaId,Titulo,Descripcion,LinkNoticia,LinkImagen,FechaPublicacion")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            db.Noticias.Remove(noticia);
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
