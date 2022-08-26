using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPIPeliculas.Controllers;
using WebAPIPeliculas.Entidades;

namespace WebAPIPeliculas.Tests.PruebasUnitarias
{
    [TestClass]
    public class ReviewsControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task UsuarioNoPuedeCrearDosReviewsParaLaMismaPelicula()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            CrearPreliculas(nombreDB);

            var peliculaId = context.Peliculas.Select(x => x.Id).First();
            var review1 = new Review()
            {
                PeliculaId = peliculaId,
                UsuarioId = usuarioPorDefectoId,
                Puntuacion = 5
            };

            context.Add(review1);
            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var controller = new ReviewController(context2, mapper);
            controller.ControllerContext = ConstruirControllerContext();

            var reviewCreacionDTO = new ReviewCreacionDTO { Puntuacion = 5 };
            var respuesta = await controller.Post(peliculaId, reviewCreacionDTO);

            var valor = respuesta as IStatusCodeActionResult;
            Assert.AreEqual(400, valor.StatusCode.Value);
        }

        [TestMethod]
        public async Task CrearReview()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            CrearPreliculas(nombreDB);

            var peliculaId = context.Peliculas.Select(x => x.Id).First();
            var context2 = ConstruirContext(nombreDB);
            
            var mapper = ConfigurarAutoMapper();
            var controller = new ReviewController(context2, mapper);
            controller.ControllerContext = ConstruirControllerContext();

            var reviewCreacionDTO = new ReviewCreacionDTO() {Puntuacion = 5};
            var respuesta = await controller.Post(peliculaId, reviewCreacionDTO);

            var valor = respuesta as NoContentResult;
            Assert.IsNotNull(valor); 

            var context3 = ConstruirContext(nombreDB);
            var reviewDB = context3.reviews.First();
            Assert.AreEqual(usuarioPorDefectoId, reviewDB.UsuarioId);
        }
        private void CrearPreliculas(string nombreDB)
        {
            var contexto = ConstruirContext(nombreDB);
            contexto.Peliculas.Add(new Pelicula() { Titulo = "pelicula 1" });
            contexto.SaveChanges();
        }
    }
}