using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDbMovies.Models;

namespace TheDbMovies.Data
{
    public class MovieRepository : IMovieRepository
    {
        private DataContext _context;
        private ILogger<MovieRepository> _logger;

        public MovieRepository(DataContext context ,ILogger<MovieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddMovie(Movie newMovie)
        {
            _context.Add(newMovie);
        }

        //public async Task<bool> AddMovieAsync(Movie newMovie)
        //{
        //    _context.Movies.Add(newMovie);
        //    return (await _context.SaveChangesAsync() > 0);
        //}
        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            if (movie== null)
                return false;
            _context.Movies.Remove(movie);
            return (await _context.SaveChangesAsync() > 0);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            _logger.LogInformation("Getting All Movies from the database");
            return _context.Movies.ToList();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies
                        .Where(v => v.Id == id)
                        .FirstOrDefaultAsync();
        }

        public Movie GetMovieByTitle(string movieTitle)
        {
            return  _context.Movies.Where(x => x.Title == movieTitle).FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            return (await _context.SaveChangesAsync() > 0);
        }
     
    }
}
