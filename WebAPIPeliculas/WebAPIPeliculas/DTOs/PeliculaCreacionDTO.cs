using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPIPeliculas.Controllers;
using WebAPIPeliculas.Validaciones;

namespace WebAPIPeliculas.DTOs
{
    public class PeliculaCreacionDTO:PeliculaPatchDTO
    {
        
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 5)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<int> GenerosIDs { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<ActorPeliculasCreacionDTO> MyProperty { get; set; }
    }
}
