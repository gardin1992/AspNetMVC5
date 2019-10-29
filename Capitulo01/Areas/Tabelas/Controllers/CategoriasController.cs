using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.Tabelas;
using Servico.Tabelas;

namespace Capitulo01.Areas.Tabelas.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }

                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
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
            return GravarCategoria(categoria);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, FormCollection colletion)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                
                TempData["Message"] = "Categoria "
                + categoria.Nome.ToUpper()
                + " foi removido.";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}