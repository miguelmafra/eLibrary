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

        public MeuContexto Contexto { get; set; }

        public LivrosController(MeuContexto contexto)
        {
            this.Contexto = contexto;
        }
    
            // GET: Livros
            public ActionResult Index()
        {

            //MeuContexto contexto = new MeuContexto();

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro liv)
        {
            if (ModelState.IsValid)
            {
                
                this.Contexto.Entry(liv).State = System.Data.Entity.EntityState.Modified;
                this.Contexto.SaveChanges();
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
    }
}
