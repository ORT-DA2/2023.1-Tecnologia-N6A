using cinema.DataAccess;
using Cinema.domain;

namespace Cinema.BusinessLogic;
public class MoviesLogic
{
    private MoviesRepository moviesRepository;

    public MoviesLogic() {
        moviesRepository = new MoviesRepository();
    }

    public List<Movie> GetMovies() {
        return moviesRepository.GetMovies();
    }
    
    public List<Movie> GetMoviesByAge(int ageAllowed) {
        List<Movie> allMovies= moviesRepository.GetMovies();
        return allMovies.FindAll(movie => movie.AgeAllowed>=ageAllowed );
    }
    

}
