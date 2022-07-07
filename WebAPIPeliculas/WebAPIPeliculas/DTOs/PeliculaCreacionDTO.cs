using System.ComponentModel.DataAnnotations;
using WebAPIPeliculas.Validaciones;

namespace WebAPIPeliculas.DTOs
{
    public class PeliculaCreacionDTO:PeliculaPatchDTO
    {
        
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 5)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        public List<int> GenerosIDs { get; set; }
    }
}
