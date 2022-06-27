using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.DTOs
{
    public class ActorCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public IFormFile Foto { get; set; }
    }
}
