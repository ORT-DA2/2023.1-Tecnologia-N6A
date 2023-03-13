using Cinema.domain;

namespace cinema.DataAccess;
public class MoviesRepository
{
    public List<Movie> GetMovies() {
        List<Movie> movies = new List<Movie>();
            
        Actor firstActor = CreateActor("firstActor", "firstFilmGenre");
        Actor secondActor = CreateActor("secondActor", "firstFilmGenre");

        Movie firstMovie = CreateMovie("firstName","firstDescription", 18,firstActor);
        movies.Add(firstMovie);

        Movie secondMovie = CreateMovie("secondName","secondDescription",10, secondActor);
        movies.Add(secondMovie);

        return movies;
    }

    private Actor CreateActor(String name, string filmGenre) {
        Actor actor = new Actor();
        actor.Name = name;
        actor.FilmGenre = filmGenre;
        return actor;
    }

    private Movie CreateMovie(String name, String description, int ageAllowed, Actor actor) {
        Movie movie = new Movie();
        movie.Actors.Add(actor);
        movie.Name = name;
        movie.Description = description;
        movie.AgeAllowed = ageAllowed;
        return movie;
    }
}
