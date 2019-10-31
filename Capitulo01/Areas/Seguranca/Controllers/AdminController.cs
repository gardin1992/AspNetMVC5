using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Capitulo01.Infraestrutura;
using Capitulo01.Areas.Seguranca.Models;
using System.Net;

namespace Capitulo01.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {
        // GET: Seguranca/Admin
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }

        // GET: Seguranca/Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguranca/Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario { UserName = model.Nome, Email = model.Email };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrosFromResult(result);
                }
            }

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            var uvm = new UsuarioViewModel();
            uvm.Id = usuario.Id;
            uvm.Nome = usuario.UserName;
            uvm.Email = usuario.Email;
            return View(uvm);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = GerenciadorUsuario.FindById(uvm.Id);
                usuario.UserName = uvm.Nome;
                usuario.Email = uvm.Email;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrosFromResult(result);
                }
            }
            return View(uvm);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);
            if (user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        private void AddErrosFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
    }
}