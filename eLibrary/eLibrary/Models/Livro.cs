using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }
        public string Titulo { get; set; }
        public int ISBN { get; set; }
        public int Paginas { get; set; }
        public int Edicao { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public string Origem { get; set; }
        public string Idioma { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria _Categoria { get; set; }
        public int EditoraID { get; set; }
        public virtual Editora _Editora { get; set; }
        public int AssuntoID { get; set; }
        public virtual Assunto _Assunto { get; set; }
        //public string Assunto { get; set; }
        //public string Editora { get; set; } (Herança)
        //public string Categoria { get; set; } (Herança)

    }
}