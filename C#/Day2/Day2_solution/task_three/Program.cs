using System.Diagnostics;

namespace task_three
{
    internal class Program
    {
        //get the ocurrunce of one in the range from one to hundred millions
        static void Main(string[] args)
        {
            #region convert to string and count 
            Stopwatch sw = new Stopwatch();
            sw.Start();

                int counter = 0;
                for (int i=1; i < Math.Pow(10, 8); i++){
                    string str = i.ToString();
                    //if the number includes 1 
                    if(str.IndexOf("1") != -1)
                    {
                        char[] charachters = str.ToCharArray();
                        for (int j = 0; j < charachters.Length; j++)
                        {
                            if (charachters[j] == '1')
                            {
                                counter++;
                            }
                        }
                    }
                }
                Console.WriteLine(counter);

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            #endregion


            #region divide by 10
            Stopwatch sw3 = new Stopwatch();
            sw3.Start();

            int counter2 = 0;
            for (int i = 1; i < Math.Pow(10, 8); i++)
            {
                int j = i;
                while (j>0)
                {
                    if((j%10) == 1)
                    {
                        counter2++;
                    }
                    j /= 10;
                }
            }
            Console.WriteLine(counter2);

            sw3.Stop();
            Console.WriteLine(sw3.ElapsedMilliseconds);
            #endregion


            #region formula
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

                //the occurunce of one between 1 and 10^n = n*10^(n-1)
                int n = 8;
                Console.WriteLine(n * Math.Pow(10, n - 1));
            
            Console.WriteLine(sw2.ElapsedMilliseconds);
            #endregion
        }
    }
}