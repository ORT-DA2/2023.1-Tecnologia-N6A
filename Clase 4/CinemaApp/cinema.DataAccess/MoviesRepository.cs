using Cinema.Domain;

namespace cinema.DataAccess;
public class MoviesRepository :IMovieRepository
{
    private static List<Movie> _movies = new List<Movie>()
    {
        new Movie() { Id = 1, Name = "Minions", Description = "Amarillo", Date = DateTime.Now, AgeAllowed = 3 }
    };

    public List<Movie> GetMovies()
    {
        return _movies;
    }

    public List<Movie> GetMoviesByCondition(Func<Movie, bool> predicate)
    {
        return _movies.Where(predicate).ToList();
    }

    public Movie? GetMovieById(int id)
    {
        return _movies.FirstOrDefault(m => m.Id == id);
    }

    public Movie AddMovie(Movie newMovie)
    {
        newMovie.Id = _movies.Count() + 1;
        _movies.Add(newMovie);

        return newMovie;
    }

    public Movie UpdateMovie(Movie oldMovie, Movie updatedMovie)
    {
        updatedMovie.Id = oldMovie.Id;
        _movies.RemoveAll(m => m.Id == oldMovie.Id);
        _movies.Add(updatedMovie);

        return updatedMovie;
    }

    public void DeleteMovie(Movie movie)
    {
        _movies.RemoveAll(m => m.Id == movie.Id);
    }
}
