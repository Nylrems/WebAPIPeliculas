﻿using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.Entidades
{
    public class Pelicula:IId
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string Poster { get; set; }
        public List<PeliculasActores> peliculasActores { get; set; }
        public List<PeliculasGeneros> peliculasGeneros { get; set; }
        public List<PeliculasSalasDeCine> PeliculasSalasDeCines {get; set;}
    }
}
