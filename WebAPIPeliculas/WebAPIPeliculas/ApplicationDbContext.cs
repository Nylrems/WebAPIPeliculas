﻿using Microsoft.EntityFrameworkCore;
using WebAPIPeliculas.Entidades;

namespace WebAPIPeliculas
{
    public class ApplicationDbContext : DbContext
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
                .HasKey(x => new {x.PeliculaId, x.SalaDeCineId});
                
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculasActores> peliculasActores { get; set; }
        public DbSet<PeliculasGeneros> peliculasGeneros { get; set; }
        public DbSet<SalaDeCine> SalaDeCines {get; set;}
        public DbSet<PeliculasSalasDeCine> PeliculasSalasDeCines {get; set;}
    }
}
