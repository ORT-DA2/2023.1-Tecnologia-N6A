using Cinema.Domain;

namespace cinema.DataAccess;

public interface IMovieRepository
{
    public List<Movie> GetMovies();
    public List<Movie> GetMoviesByCondition(Func<Movie, bool> predicate);
    public Movie? GetMovieById(int id);
    public Movie AddMovie(Movie newMovie);
    public Movie UpdateMovie(Movie oldMovie, Movie updatedMovie);
    public void DeleteMovie(Movie movie);
}