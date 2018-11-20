using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace InfoColeAplicacion.Controllers
{
    public class EspacioInteraccionController : Controller
    {
        // GET: Comentarios
        [Authorize]
        public ActionResult Index()
        {
            var autenticado = User.Identity.IsAuthenticated;
            if (autenticado)
            {
                var NombreUsuario = User.Identity.Name;
                var ID = User.Identity.GetUserId();
                ViewBag.Nombre = NombreUsuario;
                ViewBag.ID = ID;
                return View();
            }
            else {
                return RedirectToAction("Login","AccountController");
            }
            
        }
    }
}