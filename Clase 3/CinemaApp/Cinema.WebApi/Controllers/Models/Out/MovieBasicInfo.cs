using Cinema.Domain;

namespace Cinema.WebApi.Controllers.Models.Out;

public class MovieBasicInfo
{
    public int Id { get; set; }
    public string Name { get; set; }

    public MovieBasicInfo(Movie movie)
    {
        Id = movie.Id;
        Name = movie.Name;
    }
}