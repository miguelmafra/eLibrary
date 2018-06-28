using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class ReservasViewModel
    {

        public ReservasViewModel(List<Livro> livros, List<Reserva> reservas)
        {
            this.Livros = livros;
            this.Reservas = reservas;
        }

        public List<Livro> Livros { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
}