using Refit;
using Movies.Api.Sdk;
using System.Text.Json;

var moviesApi = RestService.For<IMoviesApi>("https://localhost:5001");

var movie = await moviesApi.GetMovieAsync("movie-1-2023");

Console.WriteLine(JsonSerializer.Serialize(movie));