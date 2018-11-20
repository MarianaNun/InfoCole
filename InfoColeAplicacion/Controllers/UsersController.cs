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
    public class UsersController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly int RegistrosPorPagina = 4;
        private Paginador<ApplicationUser> Paginador;
        // GET: Users
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int pagina = 1)
        {

            int TotalUsuarios = 0;
            TotalUsuarios = db.Users.Count();
            List<ApplicationUser> Usuarios = db.Users.OrderByDescending(n => n.UserName)
                                           .Skip((pagina - 1) * RegistrosPorPagina)
                                           .Take(RegistrosPorPagina)
                                           .ToList();

            var totalDePaginas = (int)Math.Ceiling((double)TotalUsuarios / RegistrosPorPagina);

            Paginador = new Paginador<ApplicationUser>()
            {
                RegistrosPorPagina = RegistrosPorPagina,
                TotalRegistros = TotalUsuarios,
                TotalPaginas = totalDePaginas,
                PaginaActual = pagina,
                Resultado = Usuarios
            };

            return View(Paginador);
        }


        
        public ActionResult HabilitacionDeUsuario(bool habilitado, string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuario = userManager.FindById(id);

            usuario.Habilitado = ! (habilitado);
            
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }


    }
}