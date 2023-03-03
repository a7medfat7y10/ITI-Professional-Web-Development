namespace task3_strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ahly ASC = new Ahly();
            
            ASC.Play();

            Console.WriteLine("\nChanging team strategy to Attack");
            ASC.TeamStrategy = new Attack();

            ASC.Play();
        }
    }

    public interface ITeamStrategy
    {
        void PerformStrategy();
    }
    public class Attack : ITeamStrategy
    {
        public void PerformStrategy()
        {
            Console.WriteLine("The team is Attacking");
        }
    }
    public class Defence : ITeamStrategy
    {
        public void PerformStrategy()
        {
            Console.WriteLine("The team is Defending");
        }
    }

    public abstract class Team
    {
        public ITeamStrategy TeamStrategy { get; set; }
        public string Name { get; set; }
        public Team(ITeamStrategy Strategy, string name)
        {
            TeamStrategy = Strategy;
            Name = name;
        }
        public void Play()
        {
            TeamStrategy.PerformStrategy();
        }
        public abstract void Display();

    }

    public class Ahly : Team
    {
        public Ahly() : base(new Defence(), "Ahly")
        {

        }
        public override void Display()
        {
            Console.WriteLine($"{this.Name}");
        }
    }
}