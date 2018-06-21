using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class EditViewModel
    {
        public EditViewModel(Livro livro, List<Categoria> categorias, List<Editora> editoras, List<Assunto> assuntos)
        {
            this.Livro = livro;
            this.Categorias = categorias;
            this.Editoras = editoras;
            this.Assuntos = assuntos;
        }

        public Livro Livro { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria da lista")]
        public List<Categoria> Categorias { get; set; }
        [Required(ErrorMessage = "Selecione uma editora da lista")]
        public List<Editora> Editoras { get; set; }
        [Required(ErrorMessage = "Selecione um assunto da lista")]
        public List<Assunto> Assuntos { get; set; }
    }
}