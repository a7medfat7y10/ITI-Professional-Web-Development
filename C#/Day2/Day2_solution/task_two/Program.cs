namespace task_two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string you want to reverse");

            string str = Console.ReadLine();
            
            string[] str2 = str.Split(" ").Reverse().ToArray();
            
            Console.WriteLine(string.Join(" ", str2));
        }
    }
}