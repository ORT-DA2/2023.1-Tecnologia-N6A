using Microsoft.AspNetCore.Mvc;
using Vidly.Domain.Entities;
using Vidly.Exceptions;
using Vidly.IBusinessLogic;
using Vidly.Models.In;
using Vidly.Models.Out;
using Vidly.WebApi.filters;

namespace Vidly.WebApi.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    [ProtectFilter(RoleType.Owner)]
    [Route("api/movies")]
    [ExceptionFilter]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
 
        public MovieController(IMovieService service)
        {
            _movieService = service;
        }

        
        [HttpGet]
        public IActionResult GetMovies([FromQuery] MovieSearchCriteriaModel searchCriteria)
        {
            var retrievedMovies = _movieService.GetAllMovies(searchCriteria.ToEntity());
            return Ok(retrievedMovies.Select(m => new MovieBasicModel(m)));
        }
    
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
                var retrievedMovie = _movieService.GetMovieById(id);
                return Ok(new MovieDetailModel(retrievedMovie));
        }

        [ProtectFilter(RoleType.Admin)]
        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieModel newMovie)
        {
            try
            {
                var createdMovie = _movieService.CreateMovie(newMovie.ToEntity());
                var movieModel = new MovieDetailModel(createdMovie);
                return Ok(movieModel);
            }
            catch (InvalidResourceException e)
            {
                return BadRequest(e.Message);
            }
        }

       
        [HttpPut("{movieId}")]
        public IActionResult Update(int movieId, [FromBody] MovieModel updatedMovie)
        {
            try
            {
                var retrievedMovie = _movieService.UpdateMovie(movieId, updatedMovie.ToEntity());
                return Ok(new MovieDetailModel(retrievedMovie));
            }
            catch (InvalidResourceException e)
            {
                return BadRequest(e.Message);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

       
        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieId)
        {
            try
            {
                _movieService.DeleteMovie(movieId);
                return Ok();
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
