using Microsoft.AspNetCore.OutputCaching;
using Movies.API.Auth;
using Movies.API.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.API.Endpoints.Movies
{
    public static class DeleteMovieEndpoint
    {
        public const string Name = "DeleteMovie";

        public static IEndpointRouteBuilder MapDeleteMovie(this IEndpointRouteBuilder app)
        {
            app.MapDelete(ApiEndpoints.Movies.Delete, async
                (Guid id, IOutputCacheStore outputCacheStore,
                IMovieService movieService, CancellationToken token) =>
            {
                var deleted = await movieService.DeleteByIdAsync(id, token);
                await outputCacheStore.EvictByTagAsync("movies", token);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return TypedResults.Ok();
            })
                .WithName(Name)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .RequireAuthorization(AuthConstants.AdminUserPolicyName);

            return app;
        }
    }
}
