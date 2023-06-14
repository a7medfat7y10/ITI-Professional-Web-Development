using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcePool
{
    public class Resource : IDisposable
    {
        public required string Name { get; set; }
        public RscPool rscPool { get; set; }
        public void UseResource() => Console.WriteLine($"Using Resource {Name} ....");
        public void Dispose()
        {
            rscPool.AddToPool(this);
        }

        internal Resource()
        {
            Console.WriteLine($"Creating Resource {Name} Started ....");
            Thread.Sleep(2500);
            Console.WriteLine($"Creating Resource {Name} Ended");
        }
    }
}
