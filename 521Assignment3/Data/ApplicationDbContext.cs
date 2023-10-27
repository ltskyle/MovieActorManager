using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webapp.Models;

namespace _521Assignment3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Webapp.Models.Movie>? Movie { get; set; }
        public DbSet<Webapp.Models.Actor>? Actor { get; set; }
        public DbSet<Webapp.Models.ActorMovie>? ActorMovie { get; set; }
    }
}