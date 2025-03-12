namespace Movies.API.Endpoints.Movies
{
    public static class MovieEndpointExtensions
    {
        public static IEndpointRouteBuilder MapMovieEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCreateMovie();
            app.MapGetMovie();
            /*
            app.MaoGetAllMovies();
            app.MapUpdateMovie();
            app.MapDeleteMovie();
            */
            return app;
        }
    }
}
