using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.Entidades
{
    public class Actor:IId
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public List<PeliculasActores> peliculasActores { get; set; }

    }
}
