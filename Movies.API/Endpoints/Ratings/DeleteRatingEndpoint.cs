using Microsoft.AspNetCore.OutputCaching;
using Movies.API.Auth;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.API.Endpoints.Ratings
{
    public static class DeleteRatingEndpoint
    {
        public const string Name = "DeleteRating";
        public static IEndpointRouteBuilder MapDeleteRating(this IEndpointRouteBuilder app)
        {
            app.MapDelete(ApiEndpoints.Movies.DeleteRating, async
                (Guid id,
                HttpContext context,
                IRatingService ratingService, 
                CancellationToken token) =>
            {
                var userId = context.GetUserId();
                var result = await ratingService.DeleteRatingAsync(id, userId.Value, token);
                return result ? TypedResults.Ok() : Results.NotFound();
            })
                .WithName(Name);

            return app;
        }
    }
}
