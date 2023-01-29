namespace task4_Duration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration D = new Duration(1, 10, 15);
            Console.WriteLine(D.ToString());
            //Output: Hours: 1, Minutes: 10 , Seconds: 15

            Console.WriteLine(D.Equals(D));//true
            

            Duration D1 = new Duration(3600);
            Console.WriteLine(D1.ToString());
            //Output: Hours: 1, Minutes: 0 , Seconds: 0
            

            Duration D2 = new Duration(7800);
            Console.WriteLine(D2.ToString());
            //Output: Hours: 2, Minutes: 10 , Seconds: 0

            Duration D3 = new Duration(666);
            Console.WriteLine(D3.ToString());
            //Output: Minutes: 11 , Seconds: 6

            Duration D_sum = D1 + D2;
            Console.WriteLine(D_sum.ToString());

            Duration D_sum2 = D1 + 7800;
            Console.WriteLine(D_sum2.ToString());

            Duration D_sum3 = 666 + D3;
            Console.WriteLine(D_sum3.ToString());

            Duration D_post = D1++;
            Console.WriteLine(D_post.ToString());
            Duration D_pre = --D2;
            Console.WriteLine(D_pre.ToString());


            Console.WriteLine((D1<D2));//true
            Console.WriteLine((D1>D2));//false
            Console.WriteLine((D1<=D2));//true
            Console.WriteLine((D1>=D2));//flase


            DateTime Obj = (DateTime)D1;
            Console.WriteLine(Obj);


            Duration D_minus =- D1;
            Console.WriteLine(D_minus);

            //if(D1)
        }
    }
}