namespace Cinema.Domain;

public class Actor
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string FilmGenre { get; set; }

        public Actor()
        {
            Id = Guid.NewGuid();
        }
}