using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class LivroViewModel
    {
        

        public LivroViewModel(List<Livro> livros, List<Editora> editoras, List<Categoria> categorias, List<Assunto> assuntos)
        {
            Livros = livros;
            Editoras = editoras;
            Categorias = categorias;
            Assuntos = assuntos;
        }

        public List<Livro> Livros { get; private set; }
        public List<Categoria> Categorias { get; private set; }
        public List<Editora> Editoras { get; private set; }
        public List<Assunto> Assuntos { get; private set; }
    }
}