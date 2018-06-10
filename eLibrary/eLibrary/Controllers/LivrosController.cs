using eLibrary.Models;
using eLibrary.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace eLibrary.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {

            MeuContexto contexto = new MeuContexto();

            List<Livro> livros = contexto.Livros.ToList();

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Livros.Add(livro);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Livro liv = contexto.Livros.Find(id);

            if (liv == null)
            {
                return HttpNotFound();
            }

            return View(liv);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Livro liv = contexto.Livros.Find(id);

            if (liv == null)
            {
                return HttpNotFound();
            }

            return View(liv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro liv)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(liv).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liv);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Livro liv = contexto.Livros.Find(id);
            if (liv == null)
            {
                return HttpNotFound();
            }

            return View(liv);

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Livro liv = contexto.Livros.Find(id);

            contexto.Livros.Remove(liv);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
