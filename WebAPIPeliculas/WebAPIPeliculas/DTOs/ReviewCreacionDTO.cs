using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.Entidades
{
    public class ReviewCreacionDTO
    {
        
        public string Comentario { get; set; }
        [Range(1, 5)]
        public int Puntuacion { get; set; }
    }
}