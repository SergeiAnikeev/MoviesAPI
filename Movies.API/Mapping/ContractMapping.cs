﻿using Movies.Contracts.Requests;
using Movies.Application.Models;
using Movies.Contracts.Responses;
using static Movies.API.ApiEndpoints;

namespace Movies.API.Mapping
{
    public static class ContractMapping
    {
        public static Movie MapToMovie(this CreateMovieRequest request)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                YearOfRelease = request.YearOfRelease,
                Genres = request.Genres.ToList()
            };
        }
        public static Movie MapToMovie(this UpdateMovieRequest request, Guid id)
        {
            return new Movie
            {
                Id = id,
                Title = request.Title,
                YearOfRelease = request.YearOfRelease,
                Genres = request.Genres.ToList()
            };
        }
        public static MovieResponse MapToResponse(this Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                Slug = movie.Slug,
                YearOfRelease = movie.YearOfRelease,
                Rating = movie.Rating,
                UserRating = movie.UserRating,
                Genres = movie.Genres.ToList()
            };

        }

        public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies)
        {
            return new MoviesResponse
            {
                Items = movies.Select(MapToResponse)
            };

        }

        public static IEnumerable<MovieRatingResponse> MapToResponse(this IEnumerable<MovieRating> ratings)
        {
            return ratings.Select(x => new MovieRatingResponse
            {
                Rating = x.Rating,
                Slug = x.Slug,
                MovieId = x.MovieId
            });
        }
        public static GetAllmoviesOptions MapToOptions(this GetAllMoviesRequest request)
        {
            return new GetAllmoviesOptions
            {
                Title = request.Title,
                YearOfRelease = request.Year
            };
        }
        public static GetAllmoviesOptions WithUser(this GetAllmoviesOptions options,Guid? userId)
        {
            options.userId = userId;
            return options;
        }
    }
}
