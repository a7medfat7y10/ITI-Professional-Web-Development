namespace task4_decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player defender1 = new Defender();
            Console.WriteLine(defender1.Role);

            Console.WriteLine("\nStriker got injured and the player is asked to play as Striker");

            defender1= new StrikerDecorator(defender1);
            Console.WriteLine(defender1.Role);
        }
    }

    public class Player
    {
        public virtual string Role { get; protected set; }
    }
    public class Defender : Player
    {
        public Defender()
        {
            this.Role = "Center back";
        }
    }
    public class StrikerDecorator : Player
    {
        private Player _player;
        public StrikerDecorator(Player Player)
        {
            this._player = Player;
        }
        public override string Role
        {
            get { return _player.Role + ", Shadow striker"; }
        }
    }


}