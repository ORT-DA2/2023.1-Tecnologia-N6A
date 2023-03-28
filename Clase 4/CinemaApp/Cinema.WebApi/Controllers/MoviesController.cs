using Cinema.BusinessLogic;
using Cinema.Domain;
using Cinema.Domain.SearchCriteria;
using Cinema.WebApi.Controllers.Models.In;
using Cinema.WebApi.Controllers.Models.Out;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private IMovieLogic _movieLogic;

    public MoviesController(IMovieLogic movieLogic)
    {
        _movieLogic = movieLogic;
    }
    
    // GET api/movies?age=14 -> index
    [HttpGet]
    public IActionResult Get([FromQuery] MovieSearchCriteria criteria)
    {
        List<Movie> retrievedMovies = _movieLogic.GetMoviesBy(criteria);
        List<MovieBasicInfo> mappedMovies = retrievedMovies
            .Select(m => new MovieBasicInfo(m)).ToList(); 

        return Ok(mappedMovies);
    }

    // GET api/movies/{id} -> show
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Movie? retrievedMovie = _movieLogic.GetMovieById(id);
        if (retrievedMovie == null)
            return NotFound(new { Message = $"Could not find movie {id}" });

        // HTTP Status 1:1 mapeo con metodos que vienen de ControllerBase
        // 200 -> Ok(responseBody)
        // 404 -> NotFound(responseBody)

        return Ok(new MovieDetail(retrievedMovie));
    }
    
    // POST api/movies -> create
    [HttpPost]
    // Model Binding
    public IActionResult Post([FromBody] MovieModel movie)
    {
        try
        {
            Movie createdMovie =null;
            if (movie != null)
            {
                createdMovie = _movieLogic.CreateMovie(movie.ToEntity());
            }
            else
            {
                createdMovie = _movieLogic.CreateMovie(null);

            }
            // 201 - Created - Primer param location, Segundo param responseBody
            return Created($"api/movies/{createdMovie.Id}", new MovieDetail(createdMovie));
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }
    
    // PUT api/movies/{id} -> update
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id, [FromBody] MovieModel movie)
    {
        try
        {
            var updatedMovie = _movieLogic.UpdateMovie(id, movie.ToEntity());
            return Ok(new MovieDetail(updatedMovie));
        }
        catch (InvalidOperationException e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
    
    // DELETE /api/movies/{id} -> destroy/delete
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _movieLogic.DeleteMovie(id);
            // 200 -> OK
            // 204 -> No Content
            return NoContent();
        }
        catch (InvalidOperationException e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
}