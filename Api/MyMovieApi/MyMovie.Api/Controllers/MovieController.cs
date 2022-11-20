using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovie.Library.Models;
using MyMovie.Library.Models.DTO;
using MyMovie.Library.Models.Parameters;
using MyMovie.Library.Repositries;

namespace MyMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieRepository _movieRepository;
        public MovieController(ILogger<MovieController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        [HttpPost]
        [Route("AddMovie")]
        public IActionResult AddMovie([FromBody] MovieAddDTO model)
        {
            try
            {
                _movieRepository.AddMovie(new Movie
                {
                    Title = model.Title,
                    IsActive = true,
                });
                return Ok("Movie Created");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview(ReviewAddDTO model)
        {
            try
            {
                _movieRepository.AddReviewMovie(model);
                return Ok("Movie Created");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet]
        [Route("GetMovie/{id}")]
        public IActionResult GetMovie(int id)
        {
            try
            {
                var data = _movieRepository.GetMovie(id);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        [Route("GetMovies")]
        public IActionResult GetMovies(MovieParameters parameters)
        {
            try
            {
                var data = _movieRepository.GetMovies(parameters);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPost]
        [Route("DisableMovie/{id}")]
        public IActionResult DisableMovie(int id)
        {
            try
            {
                _movieRepository.DisableAMovie(id);
                return Ok("Movie disabled successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
