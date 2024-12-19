using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Repositories
{

    internal class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new();

        Task<bool> IMovieRepository.CreateAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.FromResult(true);
        }

        Task<bool> IMovieRepository.DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Movie>> IMovieRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Movie?> IMovieRepository.GetByIdAsync(Guid id)
        {
            var movie = _movies.FirstOrDefault(x => x.id == id);
            return Task.FromResult(movie);
        }

        Task<bool> IMovieRepository.UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
