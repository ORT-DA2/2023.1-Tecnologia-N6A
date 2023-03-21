using cinema.DataAccess;
using Cinema.Domain;
using Cinema.Domain.SearchCriteria;

namespace Cinema.BusinessLogic;
// "Orquestador"
public class MoviesLogic
{
    private MoviesRepository _moviesRepository;

    public MoviesLogic() {
        _moviesRepository = new MoviesRepository();
    }

    public List<Movie> GetMovies() {
        return _moviesRepository.GetMovies();
    }

    public List<Movie> GetMoviesBy(MovieSearchCriteria criteria)
    {
        return _moviesRepository.GetMoviesByCondition(criteria.Criteria);
    }
    
    public Movie? GetMovieById(int id)
    {
        return _moviesRepository.GetMovieById(id);
    }
    
    public Movie CreateMovie(Movie movie)
    {
        // Validar la pelicula
        movie.ValidOrFail();
        
        // Agregar
        var addedMovie = _moviesRepository.AddMovie(movie);
 
        // llamar a servicio para enviar mail a todos los suscriptos que salio una nueva peli
        // new MovieNotifications().SendNewMovieEmail(movie);

        return addedMovie;
    }

    public Movie? UpdateMovie(int id, Movie updatedMovie)
    {
        var retrievedMovie = _moviesRepository.GetMovieById(id);
        if (retrievedMovie == null)
            throw new InvalidOperationException($"Cant find Movie {id}");

        var movie = _moviesRepository.UpdateMovie(retrievedMovie, updatedMovie);

        return movie;
    }

    public void DeleteMovie(int id)
    {
        var retrievedMovie = _moviesRepository.GetMovieById(id);
        if (retrievedMovie == null)
            throw new InvalidOperationException($"Cant find Movie {id}");

        _moviesRepository.DeleteMovie(retrievedMovie);
    }

}
