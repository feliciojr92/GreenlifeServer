using GreenlifeServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenlifeServer.Persistencia
{
    public class Context : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Midia> Midias { get; set; } 
        public DbSet<DocumentoDoador> DocumentosDoador { get; set; }
        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Testemunha> Testemunhas { get; set; }

        public Context(DbContextOptions<Context> options) : base (options)
        {
        }
    }
}
