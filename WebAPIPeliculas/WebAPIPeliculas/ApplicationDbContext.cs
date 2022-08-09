using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPIPeliculas.Entidades;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebAPIPeliculas
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculasActores>()
                .HasKey(x => new { x.ActorId, x.PeliculaId });

            modelBuilder.Entity<PeliculasGeneros>()
                .HasKey(x => new { x.GeneroId, x.PeliculaId });

            modelBuilder.Entity<PeliculasSalasDeCine>()
                .HasKey(x => new { x.PeliculaId, x.SalaDeCineId });

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var rolAdminId = "8f47b495-b296-4080-b1a7-b3bfa0b258a5";
            var usuarioAdminId = "81f775e4-6efa-47de-bbb0-eda8f47c1994";

            var rolAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var username = "Smerlyn@gmail.com";

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                UserName = username,
                NormalizedUserName = username,
                Email = username,
                NormalizedEmail = username,
                PasswordHash = passwordHasher.HashPassword(null, "Aa123456*")
            };

            // modelBuilder.Entity<IdentityUser>()
            //     .HasData(usuarioAdmin);

            // modelBuilder.Entity<IdentityRole >()
            //     .HasData(rolAdmin);

            // modelBuilder.Entity<IdentityUserClaim<string>>()
            //     .HasData(new IdentityUserClaim<string>()
            //     {
            //         Id = 1,
            //         ClaimType = ClaimTypes.Role,
            //         UserId = usuarioAdminId,
            //         ClaimValue = "Admin"
            //     });

               
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculasActores> peliculasActores { get; set; }
        public DbSet<PeliculasGeneros> peliculasGeneros { get; set; }
        public DbSet<SalaDeCine> salaDeCine { get; set; }
        public DbSet<PeliculasSalasDeCine> peliculasSalasDeCines { get; set; }
    }
}
