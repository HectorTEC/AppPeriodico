using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPeriodico.Models;

namespace AppPeriodico.Controllers
{
    public class RegistroController : Controller
    {
        private BDPeriodicoEntities1 db = new BDPeriodicoEntities1();

        // GET: Registro
        public ActionResult Index()
        {
            var registro = db.Registro.Include(r => r.Publicacion).Include(r => r.Usuario);
            return View(registro.ToList());
        }

        // GET: Registro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            ViewBag.idPublicacion = new SelectList(db.Publicacion, "idPublicacion", "NombrePublicacion");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Registro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRegistro,FechaRegistro,Observaciones,idUsuario,idPublicacion,estatus")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Registro.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPublicacion = new SelectList(db.Publicacion, "idPublicacion", "NombrePublicacion", registro.idPublicacion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", registro.idUsuario);
            return View(registro);
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPublicacion = new SelectList(db.Publicacion, "idPublicacion", "NombrePublicacion", registro.idPublicacion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", registro.idUsuario);
            return View(registro);
        }

        // POST: Registro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRegistro,FechaRegistro,Observaciones,idUsuario,idPublicacion,estatus")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPublicacion = new SelectList(db.Publicacion, "idPublicacion", "NombrePublicacion", registro.idPublicacion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", registro.idUsuario);
            return View(registro);
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registro.Find(id);
            db.Registro.Remove(registro);
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
