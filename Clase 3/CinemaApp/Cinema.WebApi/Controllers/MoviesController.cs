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
    private MoviesLogic _moviesLogic;

    public MoviesController() {
        _moviesLogic = new MoviesLogic();
    }
    
    // GET api/movies?age=14 -> index
    [HttpGet]
    public IActionResult Get([FromQuery] MovieSearchCriteria criteria)
    {
        List<Movie> retrievedMovies = _moviesLogic.GetMoviesBy(criteria);
        List<MovieBasicInfo> mappedMovies = retrievedMovies
            .Select(m => new MovieBasicInfo(m)).ToList(); 

        return Ok(mappedMovies);
    }

    // GET api/movies/{id} -> show
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Movie? retrievedMovie = _moviesLogic.GetMovieById(id);
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
        var createdMovie = _moviesLogic.CreateMovie(movie.ToEntity());
        // 201 - Created - Primer param location, Segundo param responseBody
        return Created($"api/movies/{createdMovie.Id}", new MovieDetail(createdMovie));
    }
    
    // PUT api/movies/{id} -> update
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id, [FromBody] MovieModel movie)
    {
        try
        {
            var updatedMovie = _moviesLogic.UpdateMovie(id, movie.ToEntity());
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
            _moviesLogic.DeleteMovie(id);
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