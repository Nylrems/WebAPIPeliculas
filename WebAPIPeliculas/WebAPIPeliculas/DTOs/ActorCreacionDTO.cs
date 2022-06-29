using System.ComponentModel.DataAnnotations;
using WebAPIPeliculas.Validaciones;

namespace WebAPIPeliculas.DTOs
{
    public class ActorCreacionDTO: ActorPatchDTO
    {        
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 6)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}
