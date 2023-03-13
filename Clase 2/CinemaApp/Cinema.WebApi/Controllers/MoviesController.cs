using Cinema.BusinessLogic;
using Cinema.domain;
using Cinema.WebApi.Controllers.models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController:ControllerBase
{
    private MoviesLogic _moviesLogic;
    public MoviesController() {
        _moviesLogic = new MoviesLogic();
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        List<Movie> movies = _moviesLogic.GetMovies();
        return Ok(movies);
    }
    
    [HttpGet("ageAllowed")]
    public IActionResult GetByAge([FromQuery] int ageAllowed)
    {
        List<Movie> movies = _moviesLogic.GetMoviesByAge(ageAllowed);
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] MovieModel movie)
    {
        
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id,[FromBody] MovieModel movie)
    {
        
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}