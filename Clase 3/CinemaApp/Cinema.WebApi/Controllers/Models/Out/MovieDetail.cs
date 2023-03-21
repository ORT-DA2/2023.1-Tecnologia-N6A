using Cinema.Domain;

namespace Cinema.WebApi.Controllers.Models.Out;

public class MovieDetail
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public MovieDetail(Movie movie)
    {
        Id = movie.Id;
        Name = movie.Name;
        Description = movie.Description;
        Date = movie.Date;
    }
}