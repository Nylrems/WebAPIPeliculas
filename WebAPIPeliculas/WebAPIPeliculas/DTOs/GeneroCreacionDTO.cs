﻿using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
