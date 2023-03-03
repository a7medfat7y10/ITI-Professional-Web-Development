namespace task2_observer_dp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FootBall ball= new FootBall() {MyPosition = new(0,0,0)};
            
            Player p1 = new Player(ball);
            Player p2 = new Player(ball);
            Player p3 = new Player(ball);

            Referee R1 = new Referee(ball);

            Console.WriteLine("Chaning Ball Position");
            ball.MyPosition = new Position(10,20,70);

            Console.WriteLine("\n\n\n");

            Console.WriteLine("p3 got injured and got out");
            ball.RemoveObserver(p3);
            ball.MyPosition = new Position(20, 40, 60);

        }
    }


    #region observable
    public class Position
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Z { get; set; } = 0;
        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public interface IBall
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void NotifyObservers();
    }
    public class FootBall:IBall
    {
        private Position myPosition;
        public Position MyPosition
        {
            get { return myPosition; }
            set 
            { 
                myPosition = value;
                NotifyObservers();
            }
        }
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
    #endregion

    #region Observer
    public interface IObserver
    {
        void Update(FootBall ball);
    }
    public class Player : IObserver
    {
        public Position BallPosition { get; set; }
        public Player (IBall ball)
        {
            ball.AddObserver(this);
        }
        public void Update(FootBall ball)
        {
            Console.WriteLine($"Player is running towards the Football at " +
                $"({ball.MyPosition.X},{ball.MyPosition.Y} ,{ball.MyPosition.Z} )");
        }
    }

    public class Referee : IObserver
    {
        public Position BallPosition { get; set; }
        public Referee(IBall ball)
        {
            ball.AddObserver(this);
        }
        public void Update(FootBall ball)
        {
            Console.WriteLine($"Referee is watching the Football at " +
                $"({ball.MyPosition.X},{ball.MyPosition.Y} ,{ball.MyPosition.Z} )");
        }
    }
    #endregion
}
