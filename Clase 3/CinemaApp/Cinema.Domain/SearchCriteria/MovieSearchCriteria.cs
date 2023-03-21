namespace Cinema.Domain.SearchCriteria;

public class MovieSearchCriteria
{
    public int? Age { get; set; }
    public string? Name { get; set; }

    public bool Criteria(Movie movie)
    {
        return MatchesAge(movie) && MatchesName(movie);
    }

    private bool MatchesAge(Movie movie)
    {
        if (Age == null)
            return true;

        return movie.AgeAllowed == Age;
    }
    
    private bool MatchesName(Movie movie)
    {
        if (Name == null)
            return true;

        return movie.Name == Name;
    }
}