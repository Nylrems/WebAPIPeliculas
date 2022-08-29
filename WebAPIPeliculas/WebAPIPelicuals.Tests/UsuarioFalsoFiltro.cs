
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebAPIPeliculas.Tests
{
    public class UsuarioFalsoFiltro : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Email, "Prueba@gmail.com"),
                new Claim(ClaimTypes.Name, "Prueba@gmail.com"),
                new Claim(ClaimTypes.NameIdentifier, "0c7232d5-0c93-4566-8a37-062c1e2c4f88"),
            }, "prueba"));

            await next();
        }
    }
}