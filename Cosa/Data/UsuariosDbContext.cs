using Microsoft.EntityFrameworkCore;
using Cosa.Models;

namespace Cosa.Data
{
    public class UsuariosDbContext : DbContext
    {


        private readonly IConfiguration configuration;
        public DbSet<Rusuario> Usuarios { get; set; } = null!;
        public UsuariosDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("serDB"));
        }

    }
}
