using Refit;
using Movies.Api.Sdk;
using System.Text.Json;
using Movies.Contracts.Requests;
using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Sdk.Consumer;

//var moviesApi = RestService.For<IMoviesApi>("https://localhost:5001");

var services = new ServiceCollection();

services
    .AddHttpClient()
    .AddSingleton<AuthTokenProvider>()
    .AddRefitClient<IMoviesApi>(s => new RefitSettings
        {
            AuthorizationHeaderValueGetter = async (message, cancellationToken) => await s.GetRequiredService<AuthTokenProvider>().GetTokenAsync()
        })
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://localhost:5001"));
var provider = services.BuildServiceProvider();
var moviesApi = provider.GetRequiredService<IMoviesApi>();

var newMovie = await moviesApi.CreateMovieAsync(new CreateMovieRequest 
{
    Title = "Spider Man 2",
    YearOfRelease = 2000,
    Genres = new[] {"Comedy", "Action"}
});

await moviesApi.DeleteMovieAsync(newMovie.Id);

//var movie = await moviesApi.GetMovieAsync("movie-1-2023");
var request = new GetAllMoviesRequest
{
    Title = null,
    Year = null,
    SortBy = null,
    Page = 1,
    PageSize = 3

};



var movies = await moviesApi.GetMoviesAsync(request);

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

Console.WriteLine(JsonSerializer.Serialize(movies, options));