using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcePool
{
    public class RscPool
    {
        internal  Queue<Resource> Pool;
        public  int MaxPoolSize { get; } = 5;
        public  int MinPoolSize { get; } = 2;

        public  int PoolSize { get => Pool.Count; }

        public RscPool()
        {
            Pool = new Queue<Resource>(MinPoolSize);
            for (int i = 0; i < MinPoolSize; i++)
                Pool.Enqueue(new Resource { Name = $"R{Pool.Count + 1}" , rscPool = this});
        }


        internal void AddToPool(Resource R)
        {
            if (Pool.Count < MaxPoolSize)
                Pool.Enqueue(R);
        }

        public Resource GetResource()
        {
            if (Pool.Count > 0)
                return Pool.Dequeue();
            return new Resource() { Name = $"R{Pool.Count + 1}", rscPool = this };
        }


    }
}
