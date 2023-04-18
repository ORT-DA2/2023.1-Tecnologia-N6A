using Vidly.Exceptions;
using Vidly.Domain.Entities;
using Vidly.Domain.SearchCriterias;
using Vidly.IBusinessLogic;
using Vidly.IDataAccess;

namespace Vidly.BusinessLogic;

public class MovieService : IMovieService
{
    private readonly IRepository<Movie> _repository;

    // Si por algun motivo necesito el current user en algun lado, simplemente pido que me inyecten el sessionService
    // y llamo sin parametros a GetCurrentUser()
    public MovieService(IRepository<Movie> repository)
    {
        _repository = repository;
    }

    public List<Movie> GetAllMovies(MovieSearchCriteria searchCriteria)
    {
        return _repository.GetAllBy(searchCriteria.Criteria()).ToList();
    }

    public Movie GetMovieById(int id)
    {
        var movieSaved = _repository.Find(m => m.Id == id);
        
        if (movieSaved == null)
            throw new KeyNotFoundException($"Could not find specified movie {id}");

        return movieSaved;
    }

    public Movie CreateMovie(Movie movie)
    {
        _repository.Add(movie);
        _repository.SaveChanges();
        return movie;
    }

    public Movie UpdateMovie(int id, Movie updatedMovie)
    {
        var movieSaved = _repository.Find(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        _repository.Update(movieSaved);
        _repository.SaveChanges();

        return movieSaved;
    }

    public void DeleteMovie(int id)
    {
        var movieSaved = _repository.Find(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        _repository.Delete(movieSaved);
        _repository.SaveChanges();
    }
}