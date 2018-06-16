using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class LivroViewModel
    {
        public LivroViewModel(List<Livro> livros, List<Categoria> categorias, List<Editora> editoras, List<Assunto> assuntos)
        {
            this.Livros = livros;
            this.Categorias = categorias;
            this.Editoras = editoras;
            this.Assuntos = assuntos;
        }

        public List<Livro> Livros { get; private set; }
        public List<Categoria> Categorias { get; private set; }
        public List<Editora> Editoras { get; private set; }
        public List<Assunto> Assuntos { get; private set; }
    }
}