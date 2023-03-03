using System.Text.RegularExpressions;

namespace task5_builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Director d1 = new Director();
            d1.BuildGround("gallery 3", "ground surface 1", "audience 4");
            Console.WriteLine(d1.Builder.getGround());
        }
    }

    public interface IBuilder
    {
        void StartOperation();
        void ChooseGallery(string gallery);
        void ChooseGroundSurface(string surface);
        void ChooseAudience(string audiecne);
        void EndOperation();
        string getGround();
    }

    public class GroundBuilder : IBuilder
    {
        private Ground _ground;

        public GroundBuilder()
        {
            _ground = new Ground();
        }
        public void StartOperation()
        {
            Console.WriteLine("Please Choose to build your fav ground!"); ;
        }

        public void ChooseGallery(string gallery)
        {
            this._ground.Add(gallery);
        }

        public void ChooseGroundSurface(string surface)
        {
            this._ground.Add(surface);
        }

        public void ChooseAudience(string audience)
        {
            this._ground.Add(audience);
        }

        public void EndOperation()
        {
            Console.WriteLine("You successfully built your team!");
        }

        public class Ground
        {
            private List<object> _parts = new List<object>();
            public List<object> Parts
            {
                get { return _parts; }
            }

            public void Add(string part)
            {
                this._parts.Add(part);
            }
        }

        public string getGround()
        {
            string str = string.Empty;

            for (int i = 0; i < this._ground.Parts.Count; i++)
            {
                str += this._ground.Parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Your ground have: " + str + "\n";

        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            get { return _builder; }
            set { _builder = value; }
        }
        public void BuildGround(string gallery, string surface, string audience)
        {
            _builder = new GroundBuilder();

            this._builder.StartOperation();
            this._builder.ChooseGallery(gallery);
            this._builder.ChooseGroundSurface(surface);
            this._builder.ChooseAudience(audience);
            this._builder.EndOperation();
        }
    }
}