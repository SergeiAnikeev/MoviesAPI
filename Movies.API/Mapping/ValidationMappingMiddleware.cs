using System.ComponentModel.DataAnnotations;

namespace Movies.API.Mapping
{
    public class ValidationMappingMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidationMappingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task HandleAsync(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch (ValidationException ex) 
            {

            }
        }
    }
}
