using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace WebAPIPeliculas.Controllers
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombrePropiedad = bindingContext.ModelName;
            var proveedorDeValores = bindingContext.ValueProvider.GetValue(nombrePropiedad);

            if(proveedorDeValores == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var valorDesearializado = JsonConvert.DeserializeObject<List<int>>(proveedorDeValores.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(valorDesearializado);
            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(nombrePropiedad, "Valor inválido para tipo List<int>");
            }

            return Task.CompletedTask;
        }
    }
}
