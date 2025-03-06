using Refit;
using Movies.Api.Sdk;
using System.Text.Json;
using Movies.Contracts.Requests;

var moviesApi = RestService.For<IMoviesApi>("https://localhost:5001");

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


Console.WriteLine(JsonSerializer.Serialize(movies));