using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPIPeliculas.DTOs;
using WebAPIPeliculas.Entidades;

namespace WebAPIPeliculas.Tests.PruebasDeIntegracion
{
    [TestClass]
    public class GenerosControllerTests : BasePruebas
    {
        private static readonly string url = "/api/generos";
        [TestMethod]
        public async Task ObtenesTodosLosGenerosListadoVacio()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreDB);

            var cliente = factory.CreateClient();
            var respuesta = await cliente.GetAsync(url);

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert
                .DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(0, generos.Count);
        }
        [TestMethod]
        public async Task ObtenesTodosLosGeneros()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreDB);

            var context = ConstruirContext(nombreDB);
            context.Generos.Add(new Genero { Nombre = "Género 1" });
            context.Generos.Add(new Genero { Nombre = "Género 2" });
            await context.SaveChangesAsync();

            var cliente = factory.CreateClient();
            var respuesta = await cliente.GetAsync(url);

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert
                .DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(2, generos.Count);
        }
        [TestMethod]
        public async Task BorrarGenero()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreDB);

            var context = ConstruirContext(nombreDB);
            context.Generos.Add(new Genero() {Nombre = "Género 1"});
            await context.SaveChangesAsync();

            var cliente = factory.CreateClient();
            var respuesta = await cliente.DeleteAsync($"{url}/1");
            respuesta.EnsureSuccessStatusCode();

            var context2 = ConstruirContext(nombreDB);
            var existe = await context2.Generos.AnyAsync();
            Assert.IsFalse(existe);
        }
        [TestMethod]
        public async Task BorrarGeneroRetorna401()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreDB, ignorarSeguridad: false);

            
            var cliente = factory.CreateClient();
            var respuesta = await cliente.DeleteAsync($"{url}/1");
            Assert.AreEqual("Unauthorized", respuesta.ReasonPhrase);
            
        }
    }
}