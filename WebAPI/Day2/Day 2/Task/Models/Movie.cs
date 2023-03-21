namespace Task.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int Rate { get; set; }
        public string Producer { get; set; } = string.Empty;

        public virtual List<Actor>? Actor { get; set; }

    }
}
