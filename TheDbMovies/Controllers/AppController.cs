using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheDbMovies.Data;

namespace TheDbMovies.Controllers
{
    public class AppController : Controller
    {
        private IMovieRepository _repository;
        private ILogger<MovieRepository> _logger;

        public AppController(IMovieRepository repository, ILogger<MovieRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Movies()
        {
            try
            {
                var movies = _repository.GetAllMovies();
                return View(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get movies in database:{ex.Message}");
                return Redirect("/error");
            }
        }
 
    }
}