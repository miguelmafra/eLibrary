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
    public class AssuntosController : Controller
    {
        // GET: Assuntos
        public ActionResult Index()
        {
            MeuContexto contexto = new MeuContexto();

            List<Assunto> assuntos = contexto.Assuntos.ToList();

           
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Assuntos.Add(assunto);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assunto);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Assunto ass = contexto.Assuntos.Find(id);

            if (ass == null)
            {
                return HttpNotFound();
            }

            return View(ass);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Assunto ass = contexto.Assuntos.Find(id);

            if (ass == null)
            {
                return HttpNotFound();
            }

            return View(ass);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Assunto ass)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(ass).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ass);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Assunto ass = contexto.Assuntos.Find(id);
            if (ass == null)
            {
                return HttpNotFound();
            }

            return View(ass);

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Assunto ass = contexto.Assuntos.Find(id);

            contexto.Assuntos.Remove(ass);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}