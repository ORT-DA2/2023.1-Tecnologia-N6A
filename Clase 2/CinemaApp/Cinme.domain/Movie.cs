namespace Cinema.domain;

public class Movie
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int AgeAllowed { get; set; }
        public List<Actor> Actors { get; set; }

        public Movie()
        {
            Id = Guid.NewGuid();
            Actors = new List<Actor>();
        }
}