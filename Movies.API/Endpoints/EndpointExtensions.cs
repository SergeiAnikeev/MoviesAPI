using Movies.API.Endpoints.Movies;
using Movies.API.Endpoints.Ratings;

namespace Movies.API.Endpoints
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapMovieEndpoints();
            app.MapRatingEndpoints();
            return app;
        }

    }
}
