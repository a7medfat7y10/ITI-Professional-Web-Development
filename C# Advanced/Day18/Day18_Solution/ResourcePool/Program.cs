namespace ResourcePool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RscPool rscPool = new RscPool();
            Console.WriteLine($"rscPool01 {rscPool.GetHashCode()}");

            Resource ? R01 = rscPool.GetResource();
            Console.WriteLine($"R01 {R01.GetHashCode()}");

            R01.UseResource();

            R01.Dispose();

            RscPool rscPool2 = new RscPool();
            Console.WriteLine($"rscPool02 {rscPool2.GetHashCode()}");

            Resource? R02 = rscPool2.GetResource();
            Console.WriteLine($"R02 {R02.GetHashCode()}");

            R02.UseResource();

            R02.Dispose();

        }
    }
}