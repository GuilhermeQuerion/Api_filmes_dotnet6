using Curso_Api6.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Api6.Data {
    public class FilmeContext: DbContext {

        public DbSet<Filme> Filmes { get; set; }

        public FilmeContext(DbContextOptions opt): base(opt) {
        }

    }
}
