using eLibrary.Models;
using eLibrary.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;

namespace eLibrary.Controllers
{
   
    public class ReservasController : Controller
    {
        public MeuContexto Contexto = new MeuContexto();

        

        public ActionResult Index()
        {
            var listaReservas = this.Contexto.Reservas.ToList();
            return View(listaReservas);
        }
        // GET: Reservas
        public ActionResult Reservar(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.Identity.GetUserId();
                var user = (new ApplicationDbContext()).Users.FirstOrDefault(s => s.Id == userId);

                //var livro = this.Contexto.Livros.FirstOrDefault(_ => _.LivroID == LivroId );

                Reserva reserva = new Reserva();
                reserva.LivroID = id.Value;
                reserva.UserID = userId;
                
                this.Contexto.Reservas.Add(reserva);
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }



        public ActionResult Delete(int id)
        {
            var reserva = this.Contexto.Reservas.FirstOrDefault(_ => _.ReservaID == id);
            if (reserva != null)
            {
                var livro = this.Contexto.Livros.FirstOrDefault(_ => _.LivroID == reserva.LivroID);
                livro.Status = true;
                this.Contexto.Entry(livro).State = EntityState.Modified;
                this.Contexto.Reservas.Remove(reserva);
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult HistoricoReservas()
        {
            var livros = this.Contexto.Livros.ToList();
            var reservas = this.Contexto.Reservas.ToList();
            var model = new ReservasViewModel(livros, reservas);
            return View(model);
        }

    }
}