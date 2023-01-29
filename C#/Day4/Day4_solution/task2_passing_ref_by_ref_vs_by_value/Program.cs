namespace task2_passing_ref_by_ref_vs_by_value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArr = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myArr[i]);
            }

            Console.WriteLine("passing ref by val");
            PassByVal(myArr);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myArr[i]);
            }
            


            Console.WriteLine("passing ref by ref");
            PassByRef(ref myArr);
            

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myArr[i]);
            }
            

            //function to pass ref by value 
            void PassByVal(int[] arr)
            {
                arr = new int[5];
                arr[0] = 1;
                arr[1] = 2;
                arr[2] = 3;
                arr[3] = 4;
                arr[4] = 5;
                Console.WriteLine(arr.GetHashCode());
            }
            //function to pass ref by ref
            void PassByRef(ref int[] arr)
            {
                arr = new int[5];
                arr[0] = 10;
                arr[1] = 20;
                arr[2] = 30;
                arr[3] = 40;
                arr[4] = 50;
                Console.WriteLine(arr.GetHashCode());
            }
        }
    }
}