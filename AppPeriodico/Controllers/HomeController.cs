using AppPeriodico.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppPeriodico.Models;
using AppPeriodico.Models.ViewModels;
using System.Data.Entity;
using System.Net;

namespace AppPeriodico.Controllers
{
    public class HomeController : Controller
    {
        private BDPeriodicoEntities1 db = new BDPeriodicoEntities1();

        /*-----------------------------------*/ /*-----------------------------------*/
        //Index de Publicacion
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            List<ListPublicacionViewModels> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.Publicacion
                       select new ListPublicacionViewModels
                       {
                           idPublicacion = d.idPublicacion,
                           idCategoria = d.idCategoria,
                           NombrePublicacion = d.NombrePublicacion,
                           Descripcion = d.Descripcion,
                           FechaPublicacion = d.FechaPublicacion,
                           idUsuario = d.idUsuario,
                           idTipoPublicacion = d.idTipoPublicacion,
                       }).ToList();
            }
            return View(lst);
        }
        /*-----------------------------------*/ /*-----------------------------------*/
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Usuario()
        {
            List<ListUsuarioViewModels> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.Usuario
                       select new ListUsuarioViewModels
                       {
                           idUsuario = d.idUsuario,
                           NombreUsuario = d.NombreUsuario,
                           Contraseña = d.Contraseña,
                           idTipoUsuario = d.idTipoUsuario,
                           idComentario = d.idComentario
                       }).ToList();
            }
            return View(lst);
        }
        /*-----------------------------------*/
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Categoria()
        {
            List<ListCategoriaViewModels> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.Categoria
                       select new ListCategoriaViewModels
                       {
                           idCategoria = d.idCategoria,
                           NombreCategoria = d.NombreCategoria,
                           Estatus = d.Estatus,

                       }).ToList();
            }
            return View(lst);
        }
        /*-----------------------------------*/

        [AuthorizeUser(idOperacion: 2)]
        public ActionResult VerUsuarioPublico()
        {
            List<ListUsuarioViewModels> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.Usuario
                       select new ListUsuarioViewModels
                       {
                           idUsuario = d.idUsuario,
                           NombreUsuario = d.NombreUsuario,
                           Contraseña = d.Contraseña,

                       }).ToList();
            }
            return View(lst);
        }
        /*-----------------------------------*/ /*-----------------------------------*/
        [AuthorizeUser(idOperacion: 5)]
        public ActionResult TipoUsuario()
        {
            List<ListTipoUsuarioViewModels> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.TipoUsuario
                       select new ListTipoUsuarioViewModels
                       {
                           idTipoUsuario = d.idTipoUsuario,
                           TipoUsuario1 = d.TipoUsuario1,
                       }).ToList();
            }
            return View(lst);
        }
        /*-----------------------------------*/ /*-----------------------------------*/ /*-----------------------------------*/
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult TipoPublicacion()
        {
            List<ListTipoPublicacion> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.TipoPublicacion
                       select new ListTipoPublicacion
                       {
                           idTipoPublicacion = d.idTipoPublicacion,
                           Descripcion = d.Descripcion,
                           Estatus = d.Estatus,

                       }).ToList();
            }
            return View(lst);
        }
        /*-----------------------------------*/ /*-----------------------------------*/ /*-----------------------------------*/
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Comentario()
        {
            List<ListComentario> lst;
            using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
            {
                lst = (from d in db.Comentario
                       select new ListComentario
                       {
                           idComentario = d.idComentario,
                           Descripcion = d.Descripcion,
                           Estatus = d.Estatus,

                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {

            return View();
        }
        // GET: Publicacions/Create
     
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "NombreCategoria");
            ViewBag.id = new SelectList(db.Usuario, "idUsuario", "NombreUsuario");
            ViewBag.idTipoPublicacion = new SelectList(db.TipoPublicacion, "idTipoPublicacion", "Descripcion");
            return View();
        }

        // POST: Publicacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPublicacion,idCategoria,NombrePublicacion,Descripcion,FechaPublicacion,idUsuario,idTipoPublicacion,estatus")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Publicacion.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "NombreCategoria", publicacion.idCategoria);
            ViewBag.id = new SelectList(db.Usuario, "idUsuario", "NombreUsuario", publicacion.idUsuario);
            ViewBag.idTipoPublicacion = new SelectList(db.TipoPublicacion, "idTipoPublicacion", "Descripcion",publicacion.idTipoPublicacion);
            return View(publicacion);
        }

      
        [HttpPost]

        public ActionResult Nuevo(ListPublicacionViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDPeriodicoEntities1 db = new BDPeriodicoEntities1())
                    {
                        var oTabla = new Publicacion();
                        oTabla.idPublicacion = model.idPublicacion;
                        oTabla.idCategoria = model.idCategoria;
                        oTabla.NombrePublicacion = model.NombrePublicacion;
                        oTabla.Descripcion = model.Descripcion;
                        oTabla.FechaPublicacion = model.FechaPublicacion;
                        oTabla.estatus = model.estatus;
                        oTabla.idUsuario = model.idUsuario;
                        oTabla.idTipoPublicacion = model.idTipoPublicacion;



                        db.Publicacion.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Home/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}