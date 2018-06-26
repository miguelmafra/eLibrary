using eLibrary.Models;
using eLibrary.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLibrary.Controllers
{
    public class ReservasController : Controller
    {
        public MeuContexto Contexto = new MeuContexto();

        // GET: Reservas
        public ActionResult Reservar(int LivroId)
        {
            if (ModelState.IsValid) {
                var livro = this.Contexto.Livros.FirstOrDefault(_ => _.LivroID == LivroId);

                Reserva reserva = new Reserva();
                reserva.LivroID = livro.LivroID;
                
                //this.Contexto.Reservas.Add(reserva);
                this.Contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            //var reserva = this.Contexto.Reservas.FirstOrDefault(_ => _.ReservaID == id);
            // if (reserva != null)
             {
            //this.Contexto.Reservas.Remove(reserva);
            this.Contexto.SaveChanges();
            return RedirectToAction("Index");
             }
            return View();
        }
       
    }
}