using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;


namespace WebAPIPeliculas.Tests
{
    public class BasePruebas
    {
        protected ApplicationDbContext ConstruirContext(string nombreDb)
        {
            var opciones = new DbContextOptionBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(nombreDb).Options;

                var dbContext = new ApplicationDbContext(opciones);
                return dbContext;
        }
    }
}