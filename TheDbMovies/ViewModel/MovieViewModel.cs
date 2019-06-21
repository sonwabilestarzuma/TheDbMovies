using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheDbMovies.ViewModel
{
    public class MovieViewModel
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }


        public string Image { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Summary { get; set; }
    }
}
