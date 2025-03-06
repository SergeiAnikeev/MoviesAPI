using Refit;
using Movies.Api.Sdk;
using System.Text.Json;
using Movies.Contracts.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

//var moviesApi = RestService.For<IMoviesApi>("https://localhost:5001");

var services = new ServiceCollection();
services.AddRefitClient<IMoviesApi>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://localhost:5001"));
var provider = services.BuildServiceProvider();
var moviesApi = provider.GetRequiredService<IMoviesApi>();


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