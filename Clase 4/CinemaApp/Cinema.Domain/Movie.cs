namespace Cinema.Domain;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int AgeAllowed { get; set; }
    public List<Actor> Actors { get; set; }

    public Movie()
    {
        Actors = new List<Actor>();
    }

    public void ValidOrFail()
    {
        if (String.IsNullOrEmpty(Name))
            throw new ArgumentException("Empty name");
    }
}