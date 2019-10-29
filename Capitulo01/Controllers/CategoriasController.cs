using Capitulo01.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.Tabelas;

namespace Capitulo01.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Categorias
        public ActionResult Index()
        {

            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {

            context.Categorias.Add(categoria);
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            // Categoria categoria = context.Categorias.Where(c => c.Categori// aId == id).Include("Categoria.Produtos").First();

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();

            TempData["Message"] = "Categoria "
                + categoria.Nome.ToUpper()
                + " foi removido.";

            return RedirectToAction("Index");
        }
    }
}