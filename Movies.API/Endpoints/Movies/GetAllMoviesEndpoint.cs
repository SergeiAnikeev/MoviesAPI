using Movies.API.Auth;
using Movies.API.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.API.Endpoints.Movies
{
    public static class GetAllMoviesEndpoint
    {
        public const string Name = "GetMovies";

        public static IEndpointRouteBuilder MapGetAllMovies(this IEndpointRouteBuilder app)
        {
            app.MapGet(ApiEndpoints.Movies.GetAll, async
                ([AsParameters] GetAllMoviesRequest request,
                HttpContext context,
                IMovieService movieService,
                CancellationToken token) =>
            {
                var userId = context.GetUserId();
                var options = request.MapToOptions().WithUser(userId);
                var movies = await movieService.GetAllAsync(options, token);
                var movieCount = await movieService.GetCountAsync(options.Title, options.YearOfRelease, token);
                if (movies is null)
                {
                    return Results.NotFound();
                }

                return TypedResults.Ok(movies.MapToResponse(
                    request.Page.GetValueOrDefault(PagedRequest.DefaultPage), 
                    request.PageSize.GetValueOrDefault(PagedRequest.DefaultPageSize), 
                    movieCount));
            })
                .WithName($"{Name}V1")
                .Produces<MoviesResponse>(StatusCodes.Status200OK)
                .WithApiVersionSet(ApiVersioning.VersionSet)
                .HasApiVersion(1.0);


            app.MapGet(ApiEndpoints.Movies.GetAll, async
               ([AsParameters] GetAllMoviesRequest request,
               HttpContext context,
               IMovieService movieService,
               CancellationToken token) =>
            {
                var userId = context.GetUserId();
                var options = request.MapToOptions().WithUser(userId);
                var movies = await movieService.GetAllAsync(options, token);
                var movieCount = await movieService.GetCountAsync(options.Title, options.YearOfRelease, token);
                if (movies is null)
                {
                    return Results.NotFound();
                }

                return TypedResults.Ok(movies.MapToResponse(
                    request.Page.GetValueOrDefault(PagedRequest.DefaultPage),
                    request.PageSize.GetValueOrDefault(PagedRequest.DefaultPageSize),
                    movieCount));
            })
               .WithName($"{Name}V2")
               .Produces<MoviesResponse>(StatusCodes.Status200OK)
               .WithApiVersionSet(ApiVersioning.VersionSet)
               .CacheOutput("MovieCache")
               .HasApiVersion(2.0);


            return app;
        }
    }
}
