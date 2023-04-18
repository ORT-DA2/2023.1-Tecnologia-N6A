namespace Vidly.Domain.Entities;

public class Session
{
    public int Id { get; set; }
    public Guid Token { get; set; }
    public User User { get; set; }

    public Session()
    {
        Token = Guid.NewGuid();
    }
}