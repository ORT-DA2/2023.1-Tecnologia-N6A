using Cinema.Domain;

namespace Cinema.WebApi.Controllers.Models.In;

public class MovieModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }

    public Movie ToEntity()
    {
        return new Movie()
        {
            Name = Name,
            Description = Description,
            AgeAllowed = Age
        };
    }
}