using eLibrary.Models;
using eLibrary.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;



namespace eLibrary.Controllers
{
    public class LivrosController : Controller
    {


        public MeuContexto Contexto = new MeuContexto();

        public LivrosController()
        {

        }

        // GET: Livros
        public ActionResult Index()
        {



            var livros = this.Contexto.Livros.ToList();
            var editoras = this.Contexto.Editoras.ToList();
            var assuntos = this.Contexto.Assuntos.ToList();
            var categorias = this.Contexto.Categorias.ToList();

            var model = new LivroViewModel(livros, editoras, categorias, assuntos);

            return View(model);
        }


        public ActionResult Create()
        {



            ViewBag.EditoraID = new SelectList(
            this.Contexto.Editoras.ToList(),
            "EditoraID",
            "Nome"
             );

            ViewBag.CategoriaID = new SelectList(
            this.Contexto.Categorias.ToList(),
            "CategoriaID",
            "Nome"
             );

            ViewBag.AssuntoID = new SelectList(
            this.Contexto.Assuntos.ToList(),
            "AssuntoID",
            "Nome"
             );
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro, string editoraId, string categoriaId, string assuntoId)
        {
            if (ModelState.IsValid)
            {
                livro.Status = true;
                this.Contexto.Livros.Add(livro);
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EditoraID = new SelectList(
            this.Contexto.Editoras.ToList(),
            "EditoraID",
            "Nome",
            editoraId
             );

            ViewBag.CategoriaID = new SelectList(
            this.Contexto.Categorias.ToList(),
            "CategoriaID",
            "Nome",
            categoriaId
             );

            ViewBag.AssuntoID = new SelectList(
            this.Contexto.Assuntos.ToList(),
            "AssuntoID",
            "Nome",
            assuntoId
             );

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
            var livro = this.Contexto.Livros.FirstOrDefault(_ => _.LivroID == id);
            var editoras = this.Contexto.Editoras.ToList();
            var assuntos = this.Contexto.Assuntos.ToList();
            var categorias = this.Contexto.Categorias.ToList();

            ViewBag.EditoraID = new SelectList(
                this.Contexto.Editoras.ToList(),
                "EditoraID",
                "Nome"
                );

            ViewBag.CategoriaID = new SelectList(
            this.Contexto.Categorias.ToList(),
            "CategoriaID",
            "Nome"
            );

            ViewBag.AssuntoID = new SelectList(
            this.Contexto.Assuntos.ToList(),
            "AssuntoID",
            "Nome"
            );

            var model = new EditViewModel(livro, categorias, editoras, assuntos);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro, string editoraId, string categoriaId, string assuntoId)
        {
            if (ModelState.IsValid)
            {
                livro.CategoriaID = int.Parse(categoriaId);
                livro.AssuntoID = int.Parse(assuntoId);
                livro.EditoraID = int.Parse(editoraId);

                this.Contexto.Entry(livro).State = EntityState.Modified;
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EditoraID = new SelectList(
               this.Contexto.Editoras.ToList(),
               "EditoraID",
               "Nome",
               editoraId
               );

            ViewBag.CategoriaID = new SelectList(
            this.Contexto.Categorias.ToList(),
            "CategoriaID",
            "Nome",
            categoriaId
            );

            ViewBag.AssuntoID = new SelectList(
            this.Contexto.Assuntos.ToList(),
            "AssuntoID",
            "Nome",
            assuntoId
            );

            return View(livro);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            Livro liv = Contexto.Livros.Find(id);
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

            Livro liv = Contexto.Livros.Find(id);

            this.Contexto.Livros.Remove(liv);
            this.Contexto.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AlterarStatus(int id)
        {
            var livro = this.Contexto.Livros.FirstOrDefault(_ => _.LivroID == id);

            if (livro.Status)
            {
                livro.Status = false;
            }
            else
            {
                livro.Status =  true;
                Reserva reserva = this.Contexto.Reservas.FirstOrDefault(_ => _.LivroID == livro.LivroID);
                this.Contexto.Reservas.Remove(reserva);
            }

            this.Contexto.Entry(livro).State = EntityState.Modified;
            this.Contexto.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}