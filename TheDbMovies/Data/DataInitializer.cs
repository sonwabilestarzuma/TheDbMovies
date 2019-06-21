using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDbMovies.Models;

namespace TheDbMovies.Data
{
    public class DataInitializer
    {
        private DataContext _context;

        public DataInitializer(DataContext context)
        {
            _context = context; 
        }
        public async Task EnsureSeedData()
        {
            if (!_context.Movies.Any())
            {
                var Movies = new[]
                {
                    new Movie
                    {
                    Id = 0,
                    Title = "Killer",
                    ReleaseDate = new DateTime(2014, 6, 4),
                    Summary = "The Hub of movies",
                    Image = ""
                    },
                    new Movie
                    {
                    Id = 1,
                    Title = "New Born",
                    ReleaseDate = new DateTime(2013, 8, 3),
                    Summary = "The Hub of movies",
                    Image = ""
                    },
                    new Movie
                    {
                    Id = 2,
                    Title = "Life Saver",
                    ReleaseDate = new DateTime(2012, 7, 6),
                    Summary = "The Hub of movies",
                    Image = ""
                    }

            };
            _context.Movies.AddRange(Movies);
            await _context.SaveChangesAsync();
            }
        }
    }
}

