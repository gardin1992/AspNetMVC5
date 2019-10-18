using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitulo01.Controllers
{
    public class FabricantesController : Controller
    {
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View();
        }
    }
}