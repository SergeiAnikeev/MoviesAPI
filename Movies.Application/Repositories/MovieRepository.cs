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
        Task<bool> IMovieRepository.CreateAsync(Movie movie)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        Task<bool> IMovieRepository.UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
