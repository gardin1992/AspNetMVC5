using Capitulo01.Contexts;
using Capitulo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitulo01.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {

            context.Fabricantes.Add(fabricante);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}