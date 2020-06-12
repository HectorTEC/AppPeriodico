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
    public class TipoPublicacionController : Controller
    {
        private BDPeriodicoEntities1 db = new BDPeriodicoEntities1();

        // GET: TipoPublicacion
        public ActionResult Index()
        {
            return View(db.TipoPublicacion.ToList());
        }

        // GET: TipoPublicacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPublicacion tipoPublicacion = db.TipoPublicacion.Find(id);
            if (tipoPublicacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPublicacion);
        }

        // GET: TipoPublicacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPublicacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoPublicacion,Descripcion,Estatus")] TipoPublicacion tipoPublicacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoPublicacion.Add(tipoPublicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPublicacion);
        }

        // GET: TipoPublicacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPublicacion tipoPublicacion = db.TipoPublicacion.Find(id);
            if (tipoPublicacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPublicacion);
        }

        // POST: TipoPublicacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoPublicacion,Descripcion,Estatus")] TipoPublicacion tipoPublicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPublicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPublicacion);
        }

        // GET: TipoPublicacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPublicacion tipoPublicacion = db.TipoPublicacion.Find(id);
            if (tipoPublicacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPublicacion);
        }

        // POST: TipoPublicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPublicacion tipoPublicacion = db.TipoPublicacion.Find(id);
            db.TipoPublicacion.Remove(tipoPublicacion);
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
