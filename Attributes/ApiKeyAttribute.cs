using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Loja.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, 
            ActionExecutionDelegate next)
        {
            
            // Interceptar o request, se esta passado o parametro
            if(!context.HttpContext.Request.Query
                .TryGetValue(Settings.ApiKeyName,
                                out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey não encontrado"
                };

                return;
            }

            // Chave é igual a definina do Settings
            if (!Settings.ApiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Acesso não autorizado"
                };

                return;
            }

            await next();
        }
    }
}
