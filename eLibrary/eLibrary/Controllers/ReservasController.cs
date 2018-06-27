using eLibrary.Models;
using eLibrary.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;

namespace eLibrary.Controllers
{
   
    public class ReservasController : Controller
    {
        public MeuContexto Contexto = new MeuContexto();

        

        public ActionResult Index()
        {
            return View();
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
            this.Contexto.Reservas.Remove(reserva);
            this.Contexto.SaveChanges();
            return RedirectToAction("Index");
             }
            return View();
        }
       
    }
}