namespace Task.Models
{
    public enum Gender { Female, Male }
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Salary { get; set; }
        public int MovieId { get; set; }

        public virtual Movie? Movie { get; set; }

    }
}
