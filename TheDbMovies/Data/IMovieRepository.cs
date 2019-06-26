using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDbMovies.Models;

namespace TheDbMovies.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieByTitle(string movieTitle);
        //Task<bool> AddMovieAsync(Movie newMovie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<bool> DeleteMovieAsync(int id);
        Task<bool> SaveChangesAsync();
        void AddMovie(Movie newMovie);
    }
}
