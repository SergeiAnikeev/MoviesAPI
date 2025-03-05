using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Movies.API.Auth
{
    public class ApiAuthKeyFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;
        
        public ApiAuthKeyFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName,
                out var extractedApiKey) )
            {
                context.Result = new UnauthorizedObjectResult("API key is missing");
                return;
            }
            var apiKey = _configuration["ApiKey"]!;
            if (apiKey != extractedApiKey)
            {
                context.Result = new UnauthorizedObjectResult("API key is invalid");
            }
        }
    }
}
