using Vidly.Domain.Entities;
using Vidly.Domain.SearchCriterias;

namespace Vidly.IBusinessLogic;

public interface IMovieService
{
    List<Movie> GetAllMovies(MovieSearchCriteria searchCriteria);
    Movie GetMovieById(int id);
    Movie CreateMovie(Movie movie);
    Movie UpdateMovie(int id, Movie updatedMovie);
    void DeleteMovie(int id);
}