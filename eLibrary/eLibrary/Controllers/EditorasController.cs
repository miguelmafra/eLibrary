using eLibrary.Models;
using eLibrary.Models.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace eLibrary.Controllers
{
    public class EditorasController : Controller
    {
        // GET: Editoras
        public ActionResult Index()
        {

            MeuContexto contexto = new MeuContexto();

            List<Editora> editoras = contexto.Editoras.ToList();

            return View(editoras);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Editora editora)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Editoras.Add(editora);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Editora edi = contexto.Editoras.Find(id);

            if (edi == null)
            {
                return HttpNotFound();
            }

            return View(edi);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Editora edi = contexto.Editoras.Find(id);

            if (edi == null)
            {
                return HttpNotFound();
            }

            return View(edi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Editora edi)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(edi).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edi);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            Editora edi = contexto.Editoras.Find(id);
            if (edi == null)
            {
                return HttpNotFound();
            }

            return View(edi);

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeuContexto contexto = new MeuContexto();
            Editora edi = contexto.Editoras.Find(id);

            contexto.Editoras.Remove(edi);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
