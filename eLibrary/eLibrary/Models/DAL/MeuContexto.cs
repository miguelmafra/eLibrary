using System.Data.Entity;

namespace eLibrary.Models.DAL
{
    public class MeuContexto : DbContext 
    {
        public MeuContexto() : base("strConn")
        {

            Database.SetInitializer<MeuContexto>(new DropCreateDatabaseIfModelChanges<MeuContexto>());

        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        //public DbSet<Reserva> Reservas { get; set; }


    }
}