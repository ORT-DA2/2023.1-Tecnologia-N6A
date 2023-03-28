using Cinema.Domain;
using Cinema.Domain.SearchCriteria;

namespace Cinema.BusinessLogic;

public interface IMovieLogic
{
    public List<Movie> GetMovies();
    public List<Movie> GetMoviesBy(MovieSearchCriteria criteria);
    public Movie? GetMovieById(int id);
    public Movie CreateMovie(Movie movie);
    public Movie? UpdateMovie(int id, Movie updatedMovie);
    public void DeleteMovie(int id);
}