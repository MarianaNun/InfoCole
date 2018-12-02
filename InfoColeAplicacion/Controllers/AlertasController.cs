using InfoColeAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            CargarLineasDropDown();
            return View();
        }


        public PartialViewResult CrearAlertaTrafico()
        {
            CargarTiposDropDownList();
            CargarLineasDropDown();
            return PartialView("CrearAlertaTrafico");
        }

        [HttpPost]
        public ActionResult CrearAlertaTrafico(Transito publicacion)
        {
            if (!ModelState.IsValid)
            {
                MsgBox("Incorrecto, por favor revise los campos e intente nuevamente. ");
                CargarTiposDropDownList(publicacion);
                CargarLineasDropDown();
                return View("Index");
            }
            else
            {

                publicacion.Fecha = DateTime.Now;
                db.Transitos.Add(publicacion);
                db.SaveChanges();
                CargarTiposDropDownList();
                CargarLineasDropDown();
                MsgBox("Exito al guardar el alerta de Transito.");
                ModelState.Clear();
                return View("Index");
            }
        }

        //GET
        public PartialViewResult AlertaLineas()
        {
            CargarTiposDropDownList();
            CargarLineasDropDown();
            return PartialView("AlertaLineas");
        }

        //POST
        [HttpPost]
        public ActionResult AlertaLineas(Alerta publicacion)
        {
            if (!ModelState.IsValid)
            {
                MsgBox("Incorrecto, por favor revise los campos e intente nuevamente. ");
                CargarLineasDropDown(publicacion);
                CargarTiposDropDownList();
                return View("Index");
            }
            else
            {
                publicacion.Fecha = DateTime.Now;
                db.Alertas.Add(publicacion);
                db.SaveChanges();
                CargarTiposDropDownList();
                CargarLineasDropDown();
                MsgBox("Exito al agregar alerta.");
                ModelState.Clear();
                return View("Index");
            }
        }

        public PartialViewResult EstadoLineas()
        {
            CargarTiposDropDownList();
            CargarLineasDropDown();
            return PartialView("EstadoLineas");
        }

        //POST
        [HttpPost]
        public ActionResult EstadoLineas(EstadoLinea publicacion)
        {
            if (!ModelState.IsValid)
            {
                MsgBox("Incorrecto, por favor revise los campos e intente nuevamente. ");
                CargarLineasDropDown(publicacion);
                CargarTiposDropDownList();
                return View("Index");
            }
            else
            {

                EstadoLinea lineas = db.EstadoLineas.Where(c => c.LineaID == publicacion.LineaID).FirstOrDefault();
                publicacion.Fecha = DateTime.Now;
                if (lineas != null)
                {
                    lineas.Fecha = publicacion.Fecha;
                    lineas.Contenido = publicacion.Contenido;
                    lineas.TipoID = publicacion.TipoID;
                    db.Entry(lineas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else {
                    db.EstadoLineas.Add(publicacion);
                    db.SaveChanges();
                }
                CargarTiposDropDownList();
                CargarLineasDropDown();
                MsgBox("Exito al agregar alerta.");
                ModelState.Clear();
                return View("Index");
            }
        }

        private void LimpiarCampos()
        {
            ModelState.Clear();
        }

        private void CargarTiposDropDownList(object tipoSelecionado = null)
        {
            var tiposQuery = from d in db.TipoAlertas
                             select d;
            ViewBag.TipoID = new SelectList(tiposQuery, "TipoID", "Nombre", tipoSelecionado);
        }

        private void CargarLineasDropDown(object tipoSelecionado = null)
        {
            var lineas = from d in db.Lineas
                         select d;
            ViewBag.LineaID = new SelectList(lineas, "ID", "Nombre", tipoSelecionado);
        }

        private void MsgBox(string mensaje)
        {
            string msg = "<script language=\"javascript\">";
            msg += "alert('" + mensaje + "');";
            msg += "</script>";
            Response.Write(msg);
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