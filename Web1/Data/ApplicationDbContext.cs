using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web1.Models;

namespace Web1.Data
{
    public class ApplicationDbContext : IdentityDbContext<AplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TareaModel> tareaModels { get; set; }
        public DbSet<UsuarioModels> usuarioModels { get; set; }
    }
}
