using System.ComponentModel.DataAnnotations;

namespace WebAPIPeliculas.Validaciones
{
    public class PesoImagenValidacion : ValidationAttribute
    {
        private readonly int pesoMaximoEnMegaBytes;

        public PesoImagenValidacion(int PesoMaximoEnMegaBytes)
        {
            pesoMaximoEnMegaBytes = PesoMaximoEnMegaBytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if(formFile == null)
            {
                return ValidationResult.Success;
            }

            if(formFile.Length > pesoMaximoEnMegaBytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe de ser mayor a {pesoMaximoEnMegaBytes}mb");
            }

            return ValidationResult.Success;
        }
    }
}
