using System.Collections.Generic;

namespace task_one
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] Arr = { 7,0,0, 0, 5,6,7,5,0,7,5,3 };
            //int[] Arr = { 1,1,1,1,1,1,1 };

            Console.WriteLine("Enter the size of the array");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] Arr = new int[n];
            for(int i=0; i<Arr.Length; i++)
            {
                Console.WriteLine("element no {0} ", i+1);
                Arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int first = 0;
            int last = 0;
            bool isfound = false;
            for(int i=0; i<Arr.Length && isfound == false; i++)
            {
                for (int j = 1; j <= Arr.Length && isfound == false; j++)
                {
                    if (Arr[i] == Arr[^j])
                    {
                        first = i;
                        last = j;
                        isfound= true;
                    }
                }
            }
            int distance = Arr.Length - last - first - 1;

            Console.WriteLine("the max distance is {0}", distance);
        }
    }
}