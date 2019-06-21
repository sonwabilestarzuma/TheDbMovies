using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDbMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string  Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Summary { get; set; }
    }
}
