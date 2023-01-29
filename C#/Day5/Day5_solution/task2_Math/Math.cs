using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_Math
{
    internal class Math
    {
        public static double Sum(int x, int y)
        {
            return x + y;
        }
        public static double Sub(int x, int y)
        {
            return x - y;
        }
        public static double Mul(int x, int y)
        {
            return x * y;
        }
        public static double Div(int x, int y)
        {
            if(y==0)
            {
                return 0;
            }
            return x / y;
        }
    }
}
