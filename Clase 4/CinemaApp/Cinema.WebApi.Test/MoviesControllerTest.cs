using Cinema.BusinessLogic;
using Cinema.Domain;
using Cinema.WebApi.Controllers;
using Cinema.WebApi.Controllers.Models.In;
using Cinema.WebApi.Controllers.Models.Out;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cinema.WebApi.Test;

[TestClass]
public class MoviesControllerTest
{
    
    [TestMethod]
    public void CreateValidMovieTest()
    {
        MovieModel movieModel = new MovieModel()
        {
            Name= "minions",
            Description = "pelicula de minions",
            Age = 5
        };
        
        Movie movie = new Movie()
        {
            Name= "minions",
            Description = "pelicula de minions",
            AgeAllowed = 5
        };
        
        var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
        
        var controller = new MoviesController(mock.Object);
        mock.Setup(o => o.CreateMovie(It.IsAny<Movie>())).Returns(movie);
        var result = controller.Post(movieModel);
        var createdResult = result as CreatedResult;
        var model = createdResult.Value as MovieDetail;
        mock.VerifyAll();
        Assert.IsTrue(movie.Name==model.Name);
        
    }
    
    [TestMethod]
    public void CreateNullMovieTest()
    {
        
        var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
        
        var controller = new MoviesController(mock.Object);
        mock.Setup(o => o.CreateMovie(null)).Throws(new ArgumentException());
        var result = controller.Post(null);
        mock.VerifyAll();
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        
    }
}