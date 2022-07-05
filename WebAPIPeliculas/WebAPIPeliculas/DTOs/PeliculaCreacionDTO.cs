using System.ComponentModel.DataAnnotations;
using WebAPIPeliculas.Validaciones;

namespace WebAPIPeliculas.DTOs
{
    public class PeliculaCreacionDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 5)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }
    }
}
