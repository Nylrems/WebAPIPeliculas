using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIPeliculas.Controllers;
using WebAPIPeliculas.DTOs;
using WebAPIPeliculas.Entidades;

namespace WebAPIPeliculas.Tests.PruebasUnitarias
{
    [TestClass]
    public class PeliculasControllerTest : BasePruebas
    {
        private string CrearDataPruba()


        {
            var databaseName = Guid.NewGuid().ToString();
            var context = ConstruirContext(databaseName);
            var genero = new Genero() { Nombre = "genero 1" };

            var peliculas = new List<Pelicula>()
            {
                new Pelicula(){Titulo = "Película 1", FechaEstreno = new DateTime(2010, 1, 1), EnCines = false},
                new Pelicula(){Titulo = "No estrenada", FechaEstreno = DateTime.Today.AddDays(1), EnCines = false},
                new Pelicula(){Titulo = "Película en Cines", FechaEstreno = DateTime.Today.AddDays(-1), EnCines = true}
            };

            var peliculaConGenero = new Pelicula()
            {
                Titulo = "Película con género",
                FechaEstreno = new DateTime(2010, 1, 1),
                EnCines = false
            };

            peliculas.Add(peliculaConGenero);

            context.Add(genero);
            context.AddRange(peliculas);
            context.SaveChanges();

            var peliculaGenero = new PeliculasGeneros() { GeneroId = genero.Id, PeliculaId = peliculaConGenero.Id };
            context.Add(peliculaGenero);
            context.SaveChanges();

            return databaseName;
        }

        [TestMethod]
        public async Task FiltrarPorTitulo()
        {
            var nombreBD = CrearDataPruba();
            var mapper = ConfigurarAutoMapper();
            var context = ConstruirContext(nombreBD);

            var controller = new PeliculasController(context, mapper, null, null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var tituloPelicula = "Película 1";

            var filtroDTO = new FiltroPeliculasDTO()
            {
                Titulo = tituloPelicula,
                CantidadRegistrosPorPagina = 10
            };

            var respuesta = await controller.Filtrar(filtroDTO);
            var peliculas = respuesta.Value;
            Assert.AreEqual(1, peliculas.Count);
            Assert.AreEqual(tituloPelicula, peliculas[0].Titulo);
        }

        [TestMethod]
        public async Task FiltrarEnCines()
        {
            var nombreBD = CrearDataPruba();
            var mapper = ConfigurarAutoMapper();
            var context = ConstruirContext(nombreBD);

            var controller = new PeliculasController(context, mapper, null, null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var filtroDTO = new FiltroPeliculasDTO()
            {
                EnCines = true
            };

            var respuesta = await controller.Filtrar(filtroDTO);
            var peliculas = respuesta.Value;
            Assert.AreEqual(1, peliculas.Count);
            Assert.AreEqual("Película en Cines", peliculas[0].Titulo);
        }
        [TestMethod]
        public async Task FiltrarProximosEstrenos()
        {
            var nombreBD = CrearDataPruba();
            var mapper = ConfigurarAutoMapper();
            var context = ConstruirContext(nombreBD);

            var controller = new PeliculasController(context, mapper, null, null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var filtroDTO = new FiltroPeliculasDTO()
            {
                ProximosEstrenos = true
            };

            var respuesta = await controller.Filtrar(filtroDTO);
            var peliculas = respuesta.Value;
            Assert.AreEqual(1, peliculas.Count);
            Assert.AreEqual("No estrenada", peliculas[0].Titulo);
        }
    }
}