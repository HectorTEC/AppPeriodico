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
    public class PublicacionController : Controller
    {
        private BDPeriodicoEntities1  db = new BDPeriodicoEntities1();

        // GET: Publicacion
        public ActionResult Index()
        {
            var publicacion = db.Publicacion.Include(p => p.Categoria).Include(p => p.Usuario).Include(p => p.TipoPublicacion);
            return View(publicacion.ToList());
        }

        // GET: Publicacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacion.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // GET: Publicacion/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "NombreCategoria");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario");
            ViewBag.idTipoPublicacion = new SelectList(db.TipoPublicacion, "idTipoPublicacion", "Descripcion");
            return View();
        }

        // POST: Publicacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPublicacion,NombrePublicacion,FechaPublicacion,Descripcion,estatus,idCategoria,idUsuario,idTipoPublicacion")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Publicacion.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "NombreCategoria", publicacion.idCategoria);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", publicacion.idUsuario);
            ViewBag.idTipoPublicacion = new SelectList(db.TipoPublicacion, "idTipoPublicacion", "Descripcion");
            return View(publicacion);
        }

        // GET: Publicacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacion.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "NombreCategoria", publicacion.idCategoria);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", publicacion.idUsuario);
            ViewBag.idTipoPublicacion = new SelectList(db.TipoPublicacion, "idTipoPublicacion", "Descripcion");
            return View(publicacion);
        }

        // POST: Publicacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPublicacion,NombrePublicacion,FechaPublicacion,Descripcion,estatus,idCategoria,idUsuario,idTipoPublicacion")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "NombreCategoria", publicacion.idCategoria);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", publicacion.idUsuario);
            ViewBag.idTipoPublicacion = new SelectList(db.TipoPublicacion, "idTipoPublicacion", "Descripcion",publicacion.idTipoPublicacion);
            return View(publicacion);
        }

        // GET: Publicacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacion.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // POST: Publicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacion publicacion = db.Publicacion.Find(id);
            db.Publicacion.Remove(publicacion);
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
