using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.DTOs
{
    public class PeliculaPatchDTO
    {
        
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
    }
}
