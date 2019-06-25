using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheDbMovies.Data;
using TheDbMovies.Models;
using TheDbMovies.ViewModel;

namespace TheDbMovies.Controllers.Api
{
    [Route("api/movies")]
    [Authorize]
    public class MoviesController : Controller
    {
        private IMovieRepository _repository;
        private ILogger<MovieRepository> _logger;

        public MoviesController(IMovieRepository repository, ILogger<MovieRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllMovies();
                return Ok(Mapper.Map<IEnumerable<MovieViewModel>>(results));
            }
            catch (Exception ex)
            {
                //TODO logging
                _logger.LogError($"Failed to get all Movies:{ex}");

                return BadRequest("Error Occured");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]MovieViewModel theMovie)
        {
            if (ModelState.IsValid)
            {
                // save to the database automap
                var newMovie = Mapper.Map<Movie>(theMovie);
                _repository.AddMovie(newMovie);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/movies/{theMovie.Title}", Mapper.Map<MovieViewModel>(newMovie));
                }

            }
            return BadRequest("Failed to save the Movie");
        }
    }
}


