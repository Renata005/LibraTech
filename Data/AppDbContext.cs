using Microsoft.EntityFrameworkCore;
using LibraTech.Models;

namespace LibraTech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}